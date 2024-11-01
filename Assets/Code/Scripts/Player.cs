using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts
{
    public class Player : MonoBehaviour
    {
	    private float _playerAttackPower; // 공격력
		private float _playerHp; //체력
		private int _playerLevel; // 레벨
		private float _playerExp; // 경험치
	
	    private Rigidbody2D _rigidbody2D;
		private Vector3 _inputVec;// 인풋매니저 move 값
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
    }
}