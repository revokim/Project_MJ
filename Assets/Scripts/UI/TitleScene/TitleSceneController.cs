using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // SceneManager를 사용하려면 이 네임스페이스가 필요

namespace MJ.UI
{
    public class TitleSceneController : MonoBehaviour
    {
        // GameStartButton을 할당할 변수
        public GameObject GameStartButton;

        // ButtonQuit을 할당할 변수
        public Button ButtonQuit;
        
        private void Start()
        {
            // GameStartButton이 설정되었으면 클릭 이벤트를 추가
            if (GameStartButton != null)
            {
                // 버튼의 클릭 이벤트에 메서드 연결
                GameStartButton.GetComponent<Button>().onClick.AddListener(OnGameStartButtonClicked);
            }
            
            // ButtonQuit이 설정되었으면 클릭 이벤트를 추가
            if (ButtonQuit != null)
            {
                ButtonQuit.onClick.AddListener(OnQuitButtonClicked);
            }
        }

        // GameStartButton 클릭 시 CharacterScene으로 이동하는 함수
        private void OnGameStartButtonClicked()
        {
            // CharacterScene으로 전환
            SceneManager.LoadScene("CharacterScene");
        }
        
        private void OnQuitButtonClicked()
        {
            // 게임 종료
            Debug.Log("게임 종료");
            Application.Quit();

            // 에디터에서 실행 중일 때는 게임을 종료하는 대신 플레이 모드를 종료하는 코드
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
