using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private static Inventory _instance = null; //singleton

        //델리게이트들
        public delegate void OnInventorySlotCountChanged(int val); //인벤토리 슬롯 개수가 변경되면 실행

        public OnInventorySlotCountChanged onInventorySlotCountChanged;

        public delegate void OnInventoryItemChanged(); //인베토리 아이템이 추가되거나 제거되면 실행

        public OnInventoryItemChanged onInventoryItemChanged;

        public delegate void OnInventoryCursorChanged(int val1, int val2);//슬롯 지정하는 커서가 바뀌면 실행

        public OnInventoryCursorChanged onInvetoryCursorChanged;

        public List<CollectibleItem> inventoryWeapons = new List<CollectibleItem>(); //인벤토리 무기 리스트
        public List<CollectibleItem> bagWeapons = new List<CollectibleItem>(); //가방 무기 리스트

        private int _bagSlotCount; // 가방 슬롯의 개수
        private int _inventorySlotCount; //인벤토리 슬롯의 개수
        private int _selectedSlotNum; //커서로 선택된 슬롯 인덱스
        private int _preSelectedItemNum; //이전에 선택된 슬롯 인덱스

        private InventoryInputSystem _inventoryInputSystem;

        private void OnEnable()
        {
            _inventoryInputSystem.Enable();
        }

        private void OnDisable()
        {
            _inventoryInputSystem.Disable();
        }

        public int InventorySlotCount //인벤토리 슬롯 프로퍼티
        {
            get => _inventorySlotCount;
            set
            {
                _inventorySlotCount = value;
                onInventorySlotCountChanged.Invoke(_inventorySlotCount);
            }
        }

        public int SelectedSlotNum // 선택된 슬롯 번호 프로퍼티
        {
            get => _selectedSlotNum;
            set
            {
                _selectedSlotNum = value;
                onInvetoryCursorChanged?.Invoke(_selectedSlotNum, _preSelectedItemNum);
            }
        }

        public static Inventory Instance => _instance;

        private void Awake()
        {
            _inventoryInputSystem = new InventoryInputSystem();
            _inventoryInputSystem.Inventory.DropWeapon.performed += OnDropWeaponPerformed;
            _inventoryInputSystem.Inventory.MoveInventoryCursor.performed += OnMoveInventoryCursorPerformed;
            _inventoryInputSystem.Inventory.SwapWeapon.performed += OnSwapWeaponPerformed;

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
            SelectedSlotNum = 0;
            InventorySlotCount = 3;
            _bagSlotCount = 1;
        }

        private bool AddItemToInventory(CollectibleItem weapon) //무기 인벤토리 리스트에 추가
        {
            if (inventoryWeapons.Count < _inventorySlotCount) //인벤토리 슬롯 남으면 추가
            {
                inventoryWeapons.Add(weapon);
                onInventoryItemChanged.Invoke(); //델리게이트로 ui쪽에 리스트 변경유무 알려줌
                return true;
            }

            if (bagWeapons.Count < _bagSlotCount) //가방 슬롯 남으면 추가
            {
                bagWeapons.Add(weapon);
                onInventoryItemChanged.Invoke(); //델리게이트로 ui쪽에 리스트 변경유무 알려줌
                return true;
            }
            return false; //남는 슬롯이 없어서 추가 실패
        }

        private void RemoveItemFromInventory(int index) //무기 인벤토리 리스트에서 제거
        {
            inventoryWeapons.RemoveAt(index);
            BagToInventory();
            onInventoryItemChanged.Invoke(); //델리게이트로 ui쪽에 리스트 변경유무 알려줌
        }

        private void RemoveItemFromBag(int index) //무기 가방 리스트에서 제거
        {
            bagWeapons.RemoveAt(index);
            onInventoryItemChanged.Invoke();
        }

        private void BagToInventory() //인벤토리에 빈 공간이 생기면 가방에서 인벤토리로 이동
        {
            if (bagWeapons.Count <= 0) return;
            AddItemToInventory(bagWeapons[0]);
            bagWeapons.RemoveAt(0);
        }

        private void SwapWeapons() //인벤토리 아이템과 가방의 무기 교체
        {
            (inventoryWeapons[_selectedSlotNum], bagWeapons[0]) = (bagWeapons[0], inventoryWeapons[_selectedSlotNum]);
            onInventoryItemChanged.Invoke();
        }

        private void OnDropWeaponPerformed(InputAction.CallbackContext context) //무기 버리기 입력 받기
        {
            if(_selectedSlotNum >= 0) RemoveItemFromInventory(_selectedSlotNum);
            else RemoveItemFromBag(_selectedSlotNum);
        }

        private void OnMoveInventoryCursorPerformed(InputAction.CallbackContext context) //상하좌우 인벤토리 커서 변경 입력 받기
        {
            var input = context.ReadValue<Vector2>();
            _preSelectedItemNum = SelectedSlotNum;
            
            switch (input.y)
            {
                case > 0:
                    SelectedSlotNum = (SelectedSlotNum < 0)?0:SelectedSlotNum; ;
                    break;
                case < 0:
                    SelectedSlotNum = -1;
                    break;
            }

            switch (input.x)
            {
                case > 0:
                    SelectedSlotNum += (SelectedSlotNum + 1 < InventorySlotCount)? 1 : 0;
                    Debug.Log(SelectedSlotNum);
                    break;
                case < 0:
                    SelectedSlotNum += (SelectedSlotNum + 1 > 1)? -1 : 0;
                    Debug.Log(SelectedSlotNum);
                    break;
            }
            Debug.Log(SelectedSlotNum);
        }

        private void OnSwapWeaponPerformed(InputAction.CallbackContext context) // 무기 변경 키가 눌러지면 무기 교체
        {
            if(_selectedSlotNum >= 0) SwapWeapons();
        }

        private void OnTriggerEnter2D(Collider2D collision) //(임시: 무기 줍기 구현안함) 무기에 닿으면 리스트에 추가
        {
            if (!collision.CompareTag("FieldWeapon")) return;

            var fielditems = collision.GetComponent<FieldItems>();
            if (AddItemToInventory(fielditems.GetItem()))
            {
                fielditems.DestroyItem();
            }
        }
    }
}