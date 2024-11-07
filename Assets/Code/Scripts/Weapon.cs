﻿using System;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.TextCore.Text;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace MJ.Weapon
{
    // 모든 종류의 무기에 공통적으로 들어가는 요소들을 지정합니다.
    public class Weapon : MonoBehaviour
    {
        private int _weaponCategory; // 무기 유형
        private int _weaponID; // 무기 id
        private int _prefabID; // 프리팹 id
        private float _attackDamage; // 공격력
        public float AttackInterval { get; set; } // 공격속도
        private float _weaponDurability; // 내구도
        private int _weaponLevel; // 무기 레벨 (강화 레벨)
        public float timer = 0;
        
        public void Awake()
        {
            _attackDamage = 1.0f;
            _weaponID = 1;
            AttackInterval = 1.0f;
        }

        public void Update()
        {
            switch (_weaponID)
            {
                case 0 : // 무기가 롱소드 인 경우
                    timer += Time.deltaTime;
                    if (timer > AttackInterval)
                    {
                        timer = 0;
                        LongswordAttack();
                    }

                    break;
                case 1 : // 무기가 대포인 경우
                    timer += Time.deltaTime;
                    if (timer > AttackInterval)
                    {
                        timer = 0;
                        CannonAttack();
                    }
                    break;
            }
            // foreach() 무기 list C.Attack()
        }
        public void LongswordAttack()
        {
            const int piercing = -1; //근접무기이므로 관통수 무한
            const float bulletSpeed = 0.0f; // 근접무기 이므로 속도없음
            GameObject bullet = BulletPool.Instance.GetBullet(_weaponID);
            bullet.GetComponent<Bullet>().Init(_weaponID, _attackDamage, piercing, bulletSpeed, new Vector3(0,0,0));
            bullet.transform.position = new Vector2(0,0); // 플레이어 코드랑 합칠때 수정해야함 플레이어 위치로
            float attackTime = 0.3f; // 애니메이션 재생시간, 추후 수정
            timer += Time.deltaTime;
            if (timer > attackTime)
            {
                gameObject.SetActive(false);
                timer = 0;
            }
        }

        public void CannonAttack()
        {
            const int piercing = 5;
            const float bulletSpeed = 10.0f;
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized; // 랜덤 방향으로 발사
            GameObject bullet = BulletPool.Instance.GetBullet(_weaponID);
            bullet.GetComponent<Bullet>().Init(_weaponID, _attackDamage, piercing, bulletSpeed, randomDirection); // 총알 정보 전달
            bullet.transform.position = new Vector3(0,0,0); // 플레이어 코드랑 합칠때 수정해야함 플레이어 위치로// 총알이 무작위 방향으로 발사
        }
    }
}