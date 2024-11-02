using System;
using UnityEngine;

namespace Code.Scripts.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private Inventory _inven;

        public Slot[] inventorySlots;
        public Transform inventorySlotHolder;

        private void Start()
        {
            _inven = Inventory.Instance;
            inventorySlots = inventorySlotHolder.GetComponentsInChildren<Slot>();
            _inven.onInventoryItemChanged += RedrawSlotUI;
            _inven.onInventorySlotCountChanged += InventorySlotChange;
        }

        private void RedrawSlotUI()
        {
            foreach (var t in inventorySlots)
            {
                t.RemoveSlot();
            }

            for (int i = 0; i < _inven.inventoryWeapons.Count; i++)
            {
                inventorySlots[i].weapon = _inven.inventoryWeapons[i];
                inventorySlots[i].UpdateSlotUi();
            }
        }

        private void InventorySlotChange(int val)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i].Slotnum = i;
                
                if (i < val)
                {
                    inventorySlots[i].gameObject.SetActive(true);
                }
                else
                {
                    inventorySlots[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
