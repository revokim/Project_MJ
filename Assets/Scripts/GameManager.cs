using System;
using TMPro;
using UnityEngine;

namespace MJ
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Game Control")] public float gameTime;

        public GameObject expItemPrefab;
        public Transform expGenArea;
        public Player.Player player;

        private int _totalCoins;
        private int _roundCoins;
        
        private bool _isGamePaused;
        
        public int RoundCoins => _roundCoins;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start() // 인게임 시작 시 호출
        {
            _totalCoins = 0;//임시 초기화
            _roundCoins = 0;//임시 초기화
            StartGame();
        }

        private void Update()
        {
            if (!_isGamePaused)
            {
                gameTime += Time.deltaTime;
            }
        }

        public void StartGame()
        {
            // 게임 시작 이벤트 호출
            GameEvents.TriggerGameStart();
            gameTime = 0f;
            _isGamePaused = false;
        }

        public void PauseGame()
        {
            _isGamePaused = true;
            Time.timeScale = 0f;
            
        }

        public void ResumeGame()
        {
            _isGamePaused = false;
            Time.timeScale = 1f;
        }

        public void GenerateExpItem()
        {
            Vector3 randomViewportPosition = new Vector3(
                UnityEngine.Random.Range(0.1f, 0.9f),
                UnityEngine.Random.Range(0.1f, 0.9f),
                Camera.main.nearClipPlane + 1
            );

            Vector3 worldPosition = Camera.main.ViewportToWorldPoint(randomViewportPosition);

            Instantiate(expItemPrefab, worldPosition, Quaternion.identity);
        }

        public void OnPlayerLevelUp()
        {
            _isGamePaused = true;
            ShowLevelUpOptions();
        }

        private void ShowLevelUpOptions()
        {
            // 레벨업 옵션 UI를 활성화
        }

        public void OnOptionSelected()
        {
            _isGamePaused = false;
            // 선택 후 레벨업 UI 비활성화
        }
    }
}