using System;
using MJ;
using UnityEngine;

namespace MJ.FieldItems
{
    public class FieldItems : MonoBehaviour 
    {
        public CollectibleItem.CollectibleItem collectibleItem; //아이템 변수 왜 이거를 프라이빗으로 하면 오류가 나죠!!! ㅜㅜ
        public SpriteRenderer spriteRenderer;

        public void SetItem(CollectibleItem.CollectibleItem collectibleItem) //드롭 아이템 생성시 초기화
        {
            this.collectibleItem.itemName = collectibleItem.itemName;
            this.collectibleItem.itemImage = collectibleItem.itemImage;
            this.collectibleItem.collectibleItemType = collectibleItem.collectibleItemType;
            
            spriteRenderer.sprite = this.collectibleItem.itemImage;
        }

        public CollectibleItem.CollectibleItem GetItem() //아이템 획득 시 아이템 변수 반환
        {
            return collectibleItem;
        }

        public void DestroyItem() //아이템 획득 시 드롭된 아이템 필드에서 삭제
        {
            Destroy(gameObject);
        }
    }
}
