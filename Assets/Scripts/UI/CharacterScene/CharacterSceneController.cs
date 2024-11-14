using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MJ.UI
{
    public class CharacterSceneController : MonoBehaviour
    {
        // ButtonBackward 버튼을 할당할 변수
        public Button buttonBackward;

        private void Start()
        {
            // ButtonBackward가 설정되었으면 클릭 이벤트를 추가
            if (buttonBackward != null)
            {
                buttonBackward.onClick.AddListener(OnBackwardButtonClicked);
            }
        }

        // ButtonBackward 클릭 시 TitleScene으로 이동하는 함수
        private void OnBackwardButtonClicked()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
