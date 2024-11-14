using UnityEngine;
using UnityEngine.UI;

namespace MJ.UI
{
    public class OptionPanelController : MonoBehaviour
    {
        // Static으로 선언하여 여러 씬에서 접근할 수 있도록 함
        public static GameObject OptionPanel;
    
        // ButtonQuit 버튼을 할당할 변수
        public Button ButtonQuit;

        // GameOption 버튼을 할당할 변수
        public Button GameOptionButton;
        
        private void Start()
        {
            // OptionPanel이 없으면 찾고, 찾아서 static 변수에 할당
            if (OptionPanel == null)
            {
                OptionPanel = GameObject.Find("OptionPanel");
            }

            // 게임 시작 시 OptionPanel을 비활성화
            if (OptionPanel != null)
            {
                OptionPanel.SetActive(false);  // OptionPanel을 비활성화
            }

            // GameOptionButton이 설정되었으면 클릭 이벤트를 추가
            if (GameOptionButton != null)
            {
                GameOptionButton.onClick.AddListener(OnGameOptionButtonClicked);
            }

            // ButtonQuit이 설정되었으면 클릭 이벤트를 추가
            if (ButtonQuit != null)
            {
                ButtonQuit.onClick.AddListener(OnQuitButtonClicked);
            }
        }

        // 버튼 클릭 시 OptionPanel을 비활성화하는 함수
        private void OnQuitButtonClicked()
        {
            if (OptionPanel != null)
            {
                OptionPanel.SetActive(false);
            }
        }
        
        private void OnGameOptionButtonClicked()
        {
            if (OptionPanel != null)
            {
                OptionPanel.SetActive(true);
            }
        }
    }
}
