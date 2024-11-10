using System;
using System.Collections.Generic;
using UnityEngine;

namespace MJ.ItemPickupManager
{
    public class ItemPickupManager : MonoBehaviour
    {
        private List<FieldItems.FieldItems> _itemsInScope; //주울 수 있는 범위 내에 들어온 무기 리스트
        private GameObject _letterEIcon; //무기 
        private Inventory.Inventory _inven;
        
        private InventoryInputSystem _inventoryInputSystem;
        
        private void OnEnable()
        {
            _inventoryInputSystem.Enable();
        }

        private void OnDisable()
        {
            _inventoryInputSystem.Disable();
        }

        private void Awake()
        {
            _itemsInScope = new List<FieldItems.FieldItems>();
            _letterEIcon = gameObject.transform.Find("LetterEIcon").gameObject;
            _inventoryInputSystem = new InventoryInputSystem();
        }

        private void Start()
        {
            _inven = Inventory.Inventory.Instance;
        }

        private void Update()
        {
            // 인식 범위 내에 아이템이 없을 경우
            if (_itemsInScope.Count == 0)
            {
                if (_letterEIcon.activeSelf)
                    _letterEIcon.SetActive(false);
            }
            // 인식 범위 내에 아이템이 하나라도 있을 경우
            else
            {
                if (!_letterEIcon.activeSelf)
                    _letterEIcon.SetActive(true);
            
                // F키를 누르면
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // 가장 가까운 아이템을 찾아 그 아이템을 획득한다.
                    var playerPos = gameObject.transform.position;
                    var nearestItem = _itemsInScope[0];
                    for (var i = 1; i < _itemsInScope.Count; ++i)  
                    {
                        if (Vector3.Distance(playerPos, nearestItem.transform.position) >
                            Vector3.Distance(playerPos, _itemsInScope[i].transform.position))
                        {
                            nearestItem = _itemsInScope[i];
                        }
                    }
                    
                    if (_inven.AddItemToInventory(nearestItem.GetItem()))
                    {
                        _itemsInScope.Remove(nearestItem);
                        nearestItem.DestroyItem();
                    }
                }
            }
        }

        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var item = collision.GetComponent<FieldItems.FieldItems>();
            if (item != null && !_itemsInScope.Contains(item))
            {
                _itemsInScope.Add(item);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var item = collision.GetComponent<FieldItems.FieldItems>();
            if (item != null && _itemsInScope.Contains(item))
            {
                _itemsInScope.Remove(item);
            }
        }
    }
}
