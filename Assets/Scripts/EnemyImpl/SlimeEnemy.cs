using UnityEngine;

namespace MJ.Enemy
{
    public class SlimeEnemy : Enemy
    {
        private float _enemyAttackPower = 5.0f;
        private float _enemyHp = 20.0f;
        private float _enemyMoveSpeed = 2.0f;

        private void Update()
        {
            var isEnemyDead = _enemyHp <= 0;
            if (isEnemyDead)
            {
                KillEnemy();
            }

            MoveToPlayer(_enemyMoveSpeed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // TODO: 실제 객체의 태그로 변경 필요
            if (other.gameObject.CompareTag("Player"))
            {
                onCollisionWithPlayer(other.gameObject.GetComponent<Player.Player>());
            }
            else if (other.gameObject.CompareTag("Weapon"))
            {
                onCollisionWithWeapon(other.gameObject.GetComponent<Weapon.Weapon>());
            }
        }

        private void onCollisionWithPlayer(Player.Player player)
        {
            // 나의 _enemyAttackPower만큼 플레이어 체력 차감
        }

        private void onCollisionWithWeapon(Weapon.Weapon weapon)
        {
            // weapon의 데미지만큼 나의 _enemyHp 차감
        }
    }
}