using System;
using TMPro;
using UnityEngine;

namespace MJ
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Control")]
        public static GameManager Instance;
        
        [Header("Game Data")]
        public float gameTime;

        [Header("UI Elements")]
        public TextMeshProUGUI timerText;
        public GameObject expItemPrefab;
        public Transform expGenArea;
        public Player.Player player;
        
        private bool _isGamePaused;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            if (!_isGamePaused)
            {
                gameTime += Time.deltaTime;
                UpdateTimerUI();
            }
        }

        private void UpdateTimerUI()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(gameTime);
            timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        public void StartGame()
        {
            GameEvents.TriggerGameStart();
            gameTime = 0f;
            _isGamePaused = false;
        }

        public void PauseGame()
        {
            _isGamePaused = true;
        }

        public void ResumeGame()
        {
            _isGamePaused = false;
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
