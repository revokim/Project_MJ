using System;
using UnityEngine;

namespace MJ
{
    public class GameManager : MonoBehaviour
    {
        
        public static GameManager Instance;
        [Header("Game Control")]
        public float gameTime;
        
        [Header("Player Info")]
        public int level;
        public float exp;
        public float[] nextExp = {10, 30 ,60, 100, 150, 210, 280, 360, 450, 600};

        [Header("Game Object")]
        public Player.Player player; //풀레이어 게임오브젝트는 게임매니저를 통해 가져오기
        private void Awake()
        {
            Instance = this;
        }

        private void Start() // 인게임 시작 시 호출
        {
            StartGame();
        }
        public void StartGame()
        {
            // 게임 시작 이벤트 호출
            GameEvents.TriggerGameStart();
        }

        public void GetExp()
        {
            exp++;
            
            if (exp == nextExp[level])
            {
                level++;
                exp = 0;
            }
        }
    }
}
