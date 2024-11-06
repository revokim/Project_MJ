using System;
using UnityEngine;

namespace Code.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private float _attackDamage; // 무기 데미지
        private int _piercing; // 관통 횟수
        private float _bulletSpeed = 10.0f; // 총알 속도
        private Rigidbody2D _rigidbody;
        public void Init(float attackDamage, int piercing, Vector3 dir)
        {
            this._attackDamage = attackDamage;
            this._piercing = piercing;
            _rigidbody.velocity = dir * _bulletSpeed;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy") || _piercing == -1)
                return;

            _piercing--;

            if (_piercing == -1) {
                _rigidbody.velocity = Vector2.zero;
                gameObject.SetActive(false);
            }
        }
    }
}