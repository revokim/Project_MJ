using System;
using UnityEngine;

namespace Code.Scripts.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private Inventory inven;

        public Slot[] slots;
        public Transform slotHolder;

        private void Start()
        {
            inven = Inventory.Instance;
            slots = slotHolder.GetComponentsInChildren<Slot>();
            inven.onInventoryItemChanged += RedrawSlotUI;
        }

        private void RedrawSlotUI()
        {
            foreach (var t in slots)
            {
                t.RemoveSlot();
            }

            for (int i = 0; i < inven.inventoryWeapons.Count; i++)
            {
                slots[i].weapon = inven.inventoryWeapons[i];
                slots[i].UpdateSlotUi();
            }
        }
    }
}
