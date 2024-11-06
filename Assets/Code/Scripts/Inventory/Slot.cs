using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Code.Scripts.Inventory
{
    public class Slot : MonoBehaviour
    {
        public CollectibleItem weapon;
        public Image weaponIcon;
        private Image _slotImage;
        private int _slotNum;

        private void Awake()
        {
            _slotImage = GetComponent<Image>();
        }

        public int Slotnum
        {
            get { return _slotNum; }
            set { _slotNum = value; }
        }
        
        public void UpdateSlotItemUi()
        {
            weaponIcon.sprite = weapon.itemImage;
            Color color = weaponIcon.GetComponent<Image>().color;
            color.a = 1.0f;
            weaponIcon.GetComponent<Image>().color = color;
            weaponIcon.gameObject.SetActive(true);
        }

        public void UpdateSlotUi(Sprite slotImage)
        {
            _slotImage.sprite = slotImage;
        }
        
        public void RemoveSlot()
        {
            weapon = null;
            weaponIcon.gameObject.SetActive(false);
            Color color = weaponIcon.GetComponent<Image>().color;
            color.a = 0.0f;
            weaponIcon.GetComponent<Image>().color = color;
        }
    
    }
}
