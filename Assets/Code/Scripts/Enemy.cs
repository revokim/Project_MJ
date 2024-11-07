using UnityEngine;

namespace MJ.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float EnemyAttackPower { get; set; } // 적 공격력
        public float EnemyHp { get; set; } // 적 체력
        public float EnemyMoveSpeed { get; set; } // 적 이동속도
        
        // 드랍 확률 (예시: 0.5는 50% 확률)
        [SerializeField] private float expDropRate = 0.7f;
        [SerializeField] private float creditDropRate = 0.3f;
        [SerializeField] private float weaponDropRate = 0.1f;

        // 드랍할 아이템의 프리팹
        [SerializeField] private GameObject collectibleExpPrefab;
        [SerializeField] private GameObject collectibleCreditPrefab;
        [SerializeField] private GameObject collectibleWeaponPrefab;

        // 적이 데미지를 받고 사망하는 로직
        public void EnemyTakeDamage(int damage)
        {
            EnemyHp -= damage;
            if (EnemyHp <= 0)
            {
                EnemyDie();
            }
        }

        // 적 사망 처리
        private void EnemyDie()
        {
            EnemyDropItem();
            Destroy(gameObject); // 적을 제거
        }

        // 아이템 드랍 처리
        private void EnemyDropItem()
        {
            float randomValue = Random.value; // 0.0에서 1.0 사이의 난수 생성

            if (randomValue <= expDropRate)
            {
                Instantiate(collectibleExpPrefab, transform.position, Quaternion.identity);
            }
            else if (randomValue <= expDropRate + creditDropRate)
            {
                Instantiate(collectibleCreditPrefab, transform.position, Quaternion.identity);
            }
            else if (randomValue <= expDropRate + creditDropRate + weaponDropRate)
            {
                Instantiate(collectibleWeaponPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}