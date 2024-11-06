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
                killEnemy();
            }
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
        }

        private void onCollisionWithWeapon(Weapon.Weapon weapon)
        {
        }
    }
}