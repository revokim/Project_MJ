using UnityEngine;
using System.Collections.Generic;


namespace MJ.Weapon
{ 
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    // 각 무기 ID에 따른 총알 프리팹을 저장하는 Dictionary
    public Dictionary<int, GameObject> bulletPrefabs = new Dictionary<int, GameObject>();

    // 각 무기 ID에 따른 총알 풀을 저장하는 Dictionary
    private Dictionary<int, Queue<GameObject>> bulletPools = new Dictionary<int, Queue<GameObject>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterBulletPrefab(int weaponID, GameObject bulletPrefab, int poolSize = 20)
    {
        if (!bulletPrefabs.ContainsKey(weaponID))
        {
            bulletPrefabs[weaponID] = bulletPrefab;

            // 풀 생성
            Queue<GameObject> bulletPool = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
            bulletPools[weaponID] = bulletPool;
        }
    }

    public GameObject GetBullet(int weaponID)
    {
        if (bulletPools.ContainsKey(weaponID) && bulletPools[weaponID].Count > 0)
        {
            GameObject bullet = bulletPools[weaponID].Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else if (bulletPrefabs.ContainsKey(weaponID))
        {
            GameObject bullet = Instantiate(bulletPrefabs[weaponID]);
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            Debug.Log($"Bullet prefab for weapon ID '{weaponID}' not found!");
            return null;
        }
    }

    public void ReturnBullet(int weaponID, GameObject bullet)
    {
        bullet.SetActive(false);
        if (bulletPools.ContainsKey(weaponID))
        {
            bulletPools[weaponID].Enqueue(bullet);
        }
    }
}
}