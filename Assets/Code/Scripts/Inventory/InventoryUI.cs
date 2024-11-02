using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Scripts.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private Inventory _inven;

        public Slot[] inventorySlots;
        public Slot[] bagSlots;
        public Transform inventorySlotHolder;
        public Transform bagSlotHolder;

        private void Start()
        {
            _inven = Inventory.Instance;
            inventorySlots = inventorySlotHolder.GetComponentsInChildren<Slot>();
            bagSlots = bagSlotHolder.GetComponentsInChildren<Slot>();
            _inven.onInventoryItemChanged += RedrawSlotUI;
            _inven.onInventorySlotCountChanged += InventorySlotChange;
        }

        private void RedrawSlotUI()
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
                inventorySlots[i].UpdateSlotUi();
            }
            
            for (int i = 0; i < _inven.bagWeapons.Count; i++)
            {
                bagSlots[i].weapon = _inven.bagWeapons[i];
                bagSlots[i].UpdateSlotUi();
            }
        }

        private void InventorySlotChange(int val)
        {
            for (var i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i].Slotnum = i;

                inventorySlots[i].gameObject.SetActive(i < val);
            }
        }
    }
}
