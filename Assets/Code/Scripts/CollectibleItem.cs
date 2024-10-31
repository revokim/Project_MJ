// 맵 상에 드랍되는 경험치, 재화, 장비를 다루는 클래스입니다.

using MJ;
using UnityEngine;

namespace Code.Scripts
{
    [System.Serializable]
    public class CollectibleItem
    {
        public CollectibleItemTypes collectibleItemType; // 타입
        public string itemName; // 이름
        public Sprite itemImage; // 아이템이미지
    }
}