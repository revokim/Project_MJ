using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace MJ.Player
{
    public class Player : MonoBehaviour
    {
        private float _playerAttackPower; // 공격력
        private float _playerHp; //체력
        private int _playerLevel; // 레벨
        private float _playerExp; // 경험치

        private Rigidbody2D _rigidbody2D;
        private Vector3 _inputVec; // 인풋매니저 move 값
        private float _playerMoveSpeed; // 플레이어 이동 속도
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerMoveSpeed = 5.0f;
        }

        private void FixedUpdate()
        {
            Vector2 nextMoveVec = _inputVec * (_playerMoveSpeed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(_rigidbody2D.position + nextMoveVec);
        }

        private void OnMove(InputValue value) // InputManager wasd 값 벡터로 받기
        {
            _inputVec = value.Get<Vector2>();
        }

        public PlayerStat playerStat;

        // 플레이어 스탯 관련 프로퍼티
        public float playerAttackPower { get; set; }
        public float playerHp
        {
            get { return _playerHp; }
            set
            {
                _playerHp = value; 
                // 체력이 0 이하일 경우 사망 이벤트 호출
                if (_playerHp <= 0)
                {
                    HandleDeath();
                }
            }
        }
        public int playerLevel { get; set; }
        public float playerExp { get; set; }
        public float playerMoveSpeed { get; set; }

        private void InitializePlayerStats()
        {
            _playerHp = playerStat.playerHp;
            _playerAttackPower = playerStat.playerAttackPower;
            _playerLevel = playerStat.playerLevel;
            _playerExp = playerStat.playerExp;
            _playerMoveSpeed = playerStat.playerMoveSpeed;
        }

        private void OnEnable()
        {
            // 게임 시작 이벤트 구독
            GameEvents.OnGameStart.AddListener(InitializePlayerStats);
        }
        private void OnDisable()
        {
            // 게임 시작 이벤트 구독 해제
            GameEvents.OnGameStart.RemoveListener(InitializePlayerStats);
        }
        
        // 플레이어 사망 이벤트 호출
        private void HandleDeath()
        {
            GameEvents.OnPlayerDeath.Invoke(); // 사망 이벤트 호출
        }
        
        public void TakeDamage(int damage)
        {
            // 체력 감소
            playerHp -= damage;
        }
    }
}