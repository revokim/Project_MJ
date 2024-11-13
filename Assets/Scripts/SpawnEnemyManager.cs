using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MJ
{
    public class SpawnEnemyManager : MonoBehaviour
    {
        public Enemy.Enemy[] enemyPrefabs;
        public int poolSize = 20;
        public int maxPoolSize = 30;
        public float spawnInterval = 2f;

        private static List<Enemy.Enemy> _enemyPool;
        private float _spawnTimer;
        private Vector3 _minWorldPoint;
        private Vector3 _maxWorldPoint;

        private void Awake()
        {
            InitializePool();
        }

        private void Start()
        {
            _minWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            _maxWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            _spawnTimer = spawnInterval;
        }

        private void Update()
        {
            SpawnEnemyEveryFrame();
        }
        
        private void SpawnEnemyEveryFrame()
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0;
            }
        }   

        private void InitializePool()
        {
            _enemyPool = new List<Enemy.Enemy>();
            for (int i = 0; i < poolSize; i++)
            {
                Enemy.Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
                enemy.gameObject.SetActive(false);
                _enemyPool.Add(enemy);
            }
        }

        private Enemy.Enemy GetPooledOneEnemy()
        {
            foreach (var enemy in _enemyPool)
            {
                if (!enemy.gameObject.activeSelf)
                {
                    return enemy;
                }
            }
          
            if (_enemyPool.Count >= maxPoolSize)
            {
                return null;
            }
            
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Enemy.Enemy newEnemy = Instantiate(enemyPrefabs[randomIndex]);
            newEnemy.gameObject.SetActive(false);
            _enemyPool.Add(newEnemy);

            return newEnemy;
        }

        private void SpawnEnemy()
        {
            Enemy.Enemy enemy = GetPooledOneEnemy();
            if ((object) enemy == null) return;
            var randomX = Random.Range(_minWorldPoint.x, _maxWorldPoint.x);
            var randomY = Random.Range(_minWorldPoint.y, _maxWorldPoint.y);
            enemy.transform.position = new Vector3(randomX, randomY, 0);
            enemy.gameObject.SetActive(true);
        }

        public static void ReturnToPool(Enemy.Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}