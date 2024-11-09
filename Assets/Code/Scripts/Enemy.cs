using UnityEngine;

namespace MJ.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float EnemyAttackPower { get; set; } // 적 공격력
        public float EnemyHp { get; set; } // 적 체력
        public float EnemyMoveSpeed { get; set; } // 적 이동속도
        private GameObject _targetPlayer;
        private bool _isFacingRight = true;
        
        // 드랍 확률 (예시: 0.5는 50% 확률)
        [SerializeField] private float expDropRate = 0.7f;
        [SerializeField] private float creditDropRate = 0.3f;
        [SerializeField] private float weaponDropRate = 0.1f;

        // 드랍할 아이템의 프리팹
        [SerializeField] private GameObject collectibleExpPrefab;
        [SerializeField] private GameObject collectibleCreditPrefab;
        [SerializeField] private GameObject collectibleWeaponPrefab;
        
        private float _dropRadius = 1.0f;  // 아이템을 찾을 반경
        private int _maxAttempts = 10; // 최대 빈 공간 탐색 횟수
        
        private void Awake()
        {
            // 드랍할 아이템 프리팹 연결
            if (collectibleExpPrefab == null)
                collectibleExpPrefab = Resources.Load("Prefabs/CollectibleExpPrefab") as GameObject;
            if (collectibleCreditPrefab == null)
                collectibleCreditPrefab = Resources.Load("Prefabs/CollectibleCreditPrefab") as GameObject;
            if (collectibleWeaponPrefab == null)
                collectibleWeaponPrefab = Resources.Load("Prefabs/CollectibleWeaponPrefab") as GameObject;
        }
        
        // 아이템 드랍 처리
        private void EnemyDropItem()
        {
            float randomValue = Random.value; // 0.0에서 1.0 사이의 난수 생성

            if (randomValue <= expDropRate)
            {
                Vector3 expPosition = GetNonOverlappingPosition();
                Instantiate(collectibleExpPrefab, expPosition, Quaternion.identity);
            }
            if (randomValue <= creditDropRate)
            {
                Vector3 creditPosition = GetNonOverlappingPosition();
                Instantiate(collectibleCreditPrefab, creditPosition, Quaternion.identity);
            } 
            if (randomValue <= weaponDropRate)
            {
                Vector3 weaponPosition = GetNonOverlappingPosition();
                Instantiate(collectibleWeaponPrefab, weaponPosition, Quaternion.identity);
            }
        }
        
        // 겹치지 않는 위치 찾기
        private Vector3 GetNonOverlappingPosition()
        {
            Vector3 basePosition = transform.position;

            for (int attempt = 0; attempt < _maxAttempts; attempt++)
            {
                // 무작위 위치 생성
                Vector3 randomPosition = basePosition + Random.insideUnitSphere * _dropRadius;
                randomPosition.y = basePosition.y;  // Y축을 기준으로 평면에 고정

                // 반경 내 다른 CollectibleItem이 있는지 검사
                Collider[] colliders = Physics.OverlapSphere(randomPosition, 0.5f);
                bool hasCollectibleItem = false;

                foreach (Collider collider in colliders)
                {
                    if (collider.GetComponent<CollectibleItem.CollectibleItem>() != null)
                    {
                        hasCollectibleItem = true;
                        break;
                    }
                }

                // 다른 CollectibleItem이 없으면 위치 반환
                if (!hasCollectibleItem)
                {
                    return randomPosition;
                }
            }

            // 적절한 위치를 찾지 못하면 범위 안 랜덤 위치 반환
            return basePosition + Random.insideUnitSphere * _dropRadius;
        }

        private void Start()
        {
            _targetPlayer = GameObject.FindWithTag("Player");
        }

        protected void MoveToPlayer(float speed)
        {
            if ((object)_targetPlayer != null)
            {
                var targetPosition = _targetPlayer.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                var dir = targetPosition.x - transform.position.x;
                if (dir < 0 && _isFacingRight) Flip();
                if (dir > 0 && !_isFacingRight) Flip();
            }
        }

        protected void KillEnemy()
        {
            EnemyDropItem();
            SpawnEnemyManager.ReturnToPool(this);
            // TODO: 적 죽음 이벤트 발행
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}