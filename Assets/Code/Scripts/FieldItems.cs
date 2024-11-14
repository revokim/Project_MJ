using MJ;
using MJ.EnumTypes;
using MJ.Player;
using UnityEngine;

namespace MJ.FieldItems
{
    public class FieldItems : MonoBehaviour
    {
        public CollectibleItem.CollectibleItem collectibleItem; //아이템 변수 왜 이거를 프라이빗으로 하면 오류가 나죠!!! ㅜㅜ
        public SpriteRenderer spriteRenderer;

        private int expValue = 5;

        public void SetItem(CollectibleItem.CollectibleItem item) //드롭 아이템 생성시 초기화
        {
            collectibleItem = item;
            spriteRenderer.sprite = item.itemImage;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Player.Player player = other.GetComponent<Player.Player>();
                if (player != null)
                {
                    if (collectibleItem.collectibleItemType == CollectibleItemTypes.Exp)
                    {
                        player.AddExp(expValue);
                        DestroyItem();
                    }
                }
            }
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