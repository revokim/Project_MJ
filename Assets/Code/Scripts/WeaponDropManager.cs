using System;
using System.Collections.Generic;
using MJ;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MJ.WeaponDropManager
{
    public class WeaponDropManager: MonoBehaviour //테스트용으로 무기 드랍
    {
        public static WeaponDropManager instance;
        
        public GameObject fieldItemPrefab;
        public List<CollectibleItem.CollectibleItem> weaponDB = new List<CollectibleItem.CollectibleItem>();
        public Vector3[] pos;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            for (var i = 0; i < 7; i++)
            {
                GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
                go.GetComponent<FieldItems.FieldItems>().SetItem(weaponDB[Random.Range(0, 2)]);
            }
        }
    }
}
