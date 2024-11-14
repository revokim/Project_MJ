using UnityEngine;

namespace MJ
{
    public class GameManager : MonoBehaviour
    {
        private void Start() // 인게임 시작 시 호출
        {
            StartGame();
        }
        public void StartGame()
        {
            // 게임 시작 이벤트 호출
            GameEvents.TriggerGameStart();
        }
    }
}