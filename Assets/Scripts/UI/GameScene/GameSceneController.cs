using UnityEngine;
using UnityEngine.UI;

namespace MJ.UI
{
    public class GameSceneController : MonoBehaviour
    {
        // ButtonOption을 할당할 변수
        public Button buttonOption;

        private void Start()
        {
            // ButtonOption이 설정되었으면 클릭 이벤트를 추가
            if (buttonOption != null)
            {
                buttonOption.onClick.AddListener(OnOptionButtonClicked);
            }
        }

        // ButtonOption 클릭 시 OptionPanel을 활성화하는 함수
        private void OnOptionButtonClicked()
        {
            // OptionPanel이 null이 아니면 활성화
            if (OptionPanelController.OptionPanel != null)
            {
                OptionPanelController.OptionPanel.SetActive(true);
            }
        }
    }
}
