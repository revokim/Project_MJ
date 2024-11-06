using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MJ
{
    public class SpawnEnemyManager : MonoBehaviour
    {
        public Enemy.Enemy[] enemyPrefabs;
        public int poolSize = 20;
        public float spawnInterval = 2f;

        private static List<Enemy.Enemy> enemyPool;
        private float spawnTimer;
        private Vector3 minWorldPoint;
        private Vector3 maxWorldPoint;

        private void Awake()
        {
            InitializePool();
        }

        private void Start()
        {
            minWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            maxWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            spawnTimer = spawnInterval;
        }

        private void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        private void InitializePool()
        {
            enemyPool = new List<Enemy.Enemy>();
            for (int i = 0; i < poolSize; i++)
            {
                Enemy.Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
                enemy.gameObject.SetActive(false);
                enemyPool.Add(enemy);
            }
        }

        private Enemy.Enemy GetPooledOneEnemy()
        {
            foreach (var enemy in enemyPool)
            {
                if (!enemy.gameObject.activeSelf)
                {
                    return enemy;
                }
            }

            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Enemy.Enemy newEnemy = Instantiate(enemyPrefabs[randomIndex]);
            newEnemy.gameObject.SetActive(false);
            enemyPool.Add(newEnemy);

            return newEnemy;
        }

        private void SpawnEnemy()
        {
            Enemy.Enemy enemy = GetPooledOneEnemy();
            var randomX = Random.Range(minWorldPoint.x, maxWorldPoint.x);
            var randomY = Random.Range(minWorldPoint.y, maxWorldPoint.y);
            enemy.transform.position = new Vector3(randomX, randomY, 0);
            enemy.gameObject.SetActive(true);
        }

        public static void ReturnToPool(Enemy.Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}