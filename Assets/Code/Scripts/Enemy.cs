using Code.Scripts;
using UnityEngine;

namespace MJ.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private float _enemyAttackPower; // 적 공격력
        private float _enemyHp; // 적 체력
        private float _enemyMoveSpeed; // 적 이동속도

        public void killEnemy()
        {
            SpawnEnemyManager.ReturnToPool(this);
            // TODO: 적 죽음 이벤트 발행
        }
    }
}