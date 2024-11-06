using UnityEngine;

namespace MJ.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private float _enemyAttackPower; // 적 공격력
        private float _enemyHp; // 적 체력
        private float _enemyMoveSpeed; // 적 이동속도
        private GameObject _targetPlayer;
        private bool _isFacingRight = true;

        private void Start()
        {
            _targetPlayer = GameObject.FindWithTag("Player");
        }

        protected void MoveToPlayer(float speed)
        {
            if ((object)_targetPlayer != null)
            {
                var targetPosition = _targetPlayer.transform.position;
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

                var dir = targetPosition.x - transform.position.x;
                if (dir < 0 && _isFacingRight) Flip();
                if (dir > 0 && !_isFacingRight) Flip();
            }
        }

        protected void KillEnemy()
        {
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