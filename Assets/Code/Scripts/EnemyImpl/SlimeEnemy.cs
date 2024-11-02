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
            // TODO: 실제 Player 객체의 태그로 변경 필요
            if (!other.gameObject.CompareTag("Player")) return;
            
            var player = other.gameObject.GetComponent<Player.Player>();
            Debug.Log("Player Hit!");
            // player의 체력에서 _enemyAttackPower 만큼 차감
        }
    }
}