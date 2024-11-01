using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Code.Scripts.Inventory
{
    public class Slot : MonoBehaviour
    {
        public CollectibleItem weapon;
        public Image weaponIcon;

        public void UpdateSlotUi()
        {
            weaponIcon.sprite = weapon.itemImage;
            weaponIcon.gameObject.SetActive(true);
        }

        public void RemoveSlot()
        {
            weapon = null;
            weaponIcon.gameObject.SetActive(false);
        }
    
    }
}
