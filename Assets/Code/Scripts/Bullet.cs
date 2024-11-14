using System;
using UnityEngine;

namespace MJ.Weapon
{
    public class Bullet : MonoBehaviour
    {
        private int _weaponID; // 무기 아이디랑 같음
        private float _attackDamage; // 무기 데미지
        private int _piercing; // 관통 횟수
        private float _bulletSpeed; // 총알 속도
        private Rigidbody2D _rigidbody;
        
        public void Init(int weaponID, float attackDamage, int piercing, float bulletSpeed, Vector3 direction)
        {
            this._weaponID = weaponID;
            this._attackDamage = attackDamage;
            this._piercing = piercing;
            this._bulletSpeed = bulletSpeed;
            if (_rigidbody == null)
            {
                throw new NullReferenceException("Rigidbody가 할당되지 않았습니다! 게임을 멈춥니다.");
            }
            _rigidbody.linearVelocity = direction * _bulletSpeed; // 방향과 속도를 곱하여 이동   
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;
        }
        
        private void ReturnToPool()
        {
            BulletPool.Instance.ReturnBullet(_weaponID, gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy") || _piercing == -1)
                return;
            _piercing--;
            if (_piercing == -1)
            {
                ReturnToPool();
            }
        }
    }
}