using UnityEngine;
using System.Collections.Generic;


namespace MJ.Weapon
{ 
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    
    // List로 변경하여 인스펙터에서 수동으로 등록
    [System.Serializable]
    public class BulletPrefab
    {
        public int weaponID;
        public GameObject bulletPrefab;
        public int initialPoolSize;  // 초기 풀 크기
    }
    
    // 각 무기 ID에 따른 총알 프리팹을 저장하는 list
    public List<BulletPrefab> bulletPrefabsList = new List<BulletPrefab>();

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
        foreach (var bulletPrefab in bulletPrefabsList)
        {
            bulletPools[bulletPrefab.weaponID] = new Queue<GameObject>();
            for (int i = 0; i < bulletPrefab.initialPoolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab.bulletPrefab);
                bullet.SetActive(false);  // 처음엔 비활성화
                bulletPools[bulletPrefab.weaponID].Enqueue(bullet);  // 풀에 추가
            }
        }
    }

    public GameObject GetBullet(int weaponID)
    {
        if (bulletPools.TryGetValue(weaponID, out Queue<GameObject> pool) && pool.Count > 0)
        {
            GameObject bullet = pool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            Debug.Log($"No bullets available in the pool for weapon ID {weaponID}");
            return null;  // 풀에 총알이 없을 경우
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