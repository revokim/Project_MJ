using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Code.Scripts.Inventory
{
    public class Slot : MonoBehaviour
    {
        public CollectibleItem weapon;
        public Image weaponIcon;
        private int _slotNum;

        public int Slotnum
        {
            get { return _slotNum; }
            set { _slotNum = value; }
        }
        
        public void UpdateSlotUi()
        {
            weaponIcon.sprite = weapon.itemImage;
            Color color = weaponIcon.GetComponent<Image>().color;
            color.a = 1.0f;
            weaponIcon.GetComponent<Image>().color = color;
            weaponIcon.gameObject.SetActive(true);
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
