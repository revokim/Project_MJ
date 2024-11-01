using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Code.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        
        private static Inventory _instance = null;
        public delegate void OnInventoryItemChanged();
        public OnInventoryItemChanged onInventoryItemChanged;

        private int slotCount;
        
        public List<CollectibleItem> inventoryWeapons = new List<CollectibleItem>();
        private void Awake()
        {
            if (null == _instance)
            {   
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            slotCount = 3;
        }

        public static Inventory Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool AddItemToInventory(CollectibleItem weapon)
        {
            if (inventoryWeapons.Count >= slotCount) return false;
            inventoryWeapons.Add(weapon);
            Debug.Log(weapon.itemName + " added to Inventory");
            onInventoryItemChanged.Invoke();
            return true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("FieldWeapon"))
            {
                FieldItems fielditems = collision.GetComponent<FieldItems>();
                if (AddItemToInventory(fielditems.GetItem()))
                {
                    fielditems.DestroyItem();
                }
            }
        }
    }
}
