using UnityEngine;
using UnityEngine.SceneManagement;

namespace MJ.UI
{
    public class GameStartButton : MonoBehaviour
    {
        private void OnMouseDown()
        {
            // CharacterScene으로 씬 전환
            SceneManager.LoadScene("CharacterScene");
        }
    }
}
