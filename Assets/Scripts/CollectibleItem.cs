using MJ;
using MJ.EnumTypes;
using UnityEngine;

namespace MJ.CollectibleItem
{
    [System.Serializable]
    public class CollectibleItem
    {
        public CollectibleItemTypes collectibleItemType; // 타입
        public string itemName; // 이름
        public Sprite itemImage; // 아이템이미지
        
        public CollectibleItemTypes CollectibleItemType {get; set;} // 타입
    }
}