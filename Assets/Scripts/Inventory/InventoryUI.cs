using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MJ.InventoryUI
{
    public class InventoryUI : MonoBehaviour
    {
        private Inventory.Inventory _inven;

        public Slot.Slot[] inventorySlots;
        public Slot.Slot[] bagSlots;
        public Transform inventorySlotHolder;
        public Transform bagSlotHolder;
        public Sprite selectedSlotImage;
        public Sprite defaultSlotImage;

        private void Start()
        {
            _inven = Inventory.Inventory.Instance;
            inventorySlots = inventorySlotHolder.GetComponentsInChildren<Slot.Slot>();
            bagSlots = bagSlotHolder.GetComponentsInChildren<Slot.Slot>();
            
            _inven.onInventoryItemChanged += RedrawSlotUI;
            _inven.onInventorySlotCountChanged += InventorySlotChange;
            _inven.onInvetoryCursorChanged += RedrawCursorUI;
        }

        private void RedrawSlotUI() //가방이나 인벤토리의 무기 리스트가 변경되면 다시 그려줌
        {
            foreach (var t in inventorySlots)
            {
                t.RemoveSlot();
            }

            foreach (var t in bagSlots)
            {
                t.RemoveSlot();
            }

            for (int i = 0; i < _inven.inventoryWeapons.Count; i++)
            {
                inventorySlots[i].weapon = _inven.inventoryWeapons[i];
                inventorySlots[i].UpdateSlotItemUi();
            }

            for (int i = 0; i < _inven.bagWeapons.Count; i++)
            {
                bagSlots[i].weapon = _inven.bagWeapons[i];
                bagSlots[i].UpdateSlotItemUi();
            }
        }

        private void InventorySlotChange(int val) // 슬롯의 개수가 변경되면 개수만큼만 활성화해준다
        {
            for (var i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i].Slotnum = i;
                inventorySlots[i].gameObject.SetActive(i < val);
            }
        }

        private void RedrawCursorUI(int selectedSlotNum, int preSelectedSlotNum) // 커서가 지정하는 슬롯이 변경되면 슬롯 커서 다시 그려줌
        {
            var preSlot = (preSelectedSlotNum >= 0) ? inventorySlots[preSelectedSlotNum] : bagSlots[0];
            preSlot.UpdateSlotUi(defaultSlotImage);
            var selectedSlot = (selectedSlotNum >= 0) ? inventorySlots[selectedSlotNum] : bagSlots[0];
            selectedSlot.UpdateSlotUi(selectedSlotImage);
        }
    }
}