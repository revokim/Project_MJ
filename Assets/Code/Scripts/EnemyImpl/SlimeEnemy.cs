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
    }
}