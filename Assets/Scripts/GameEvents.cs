using UnityEngine;
using UnityEngine.Events;

namespace MJ
{
    public class GameEvents : MonoBehaviour
    {
        // 인게임 시작 이벤트
        public static UnityEvent OnGameStart = new UnityEvent();
        public static UnityEvent OnPlayerDeath = new UnityEvent();
    
        // 인게임 시작 이벤트를 호출하는 함수
        public static void TriggerGameStart()
        {
            OnGameStart?.Invoke();
        }
    }
}