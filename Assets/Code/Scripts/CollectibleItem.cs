// 맵 상에 드랍되는 경험치, 재화, 장비를 다루는 클래스입니다.
using UnityEngine;

namespace MJ.CollectibleItem
{
    public class CollectibleItem : MonoBehaviour
    {
        public CollectibleItemTypes _collectibleItemType {get; set;} // 타입

        // 아이템이 수집될 때 호출되는 메서드
        public void Collect()
        {
            // 수집 처리 로직 (예: 플레이어의 경험치 증가, 재화 증가 등) : todo
            Destroy(gameObject);
        }
    }
}