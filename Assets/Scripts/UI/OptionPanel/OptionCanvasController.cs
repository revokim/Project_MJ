using UnityEngine;

namespace MJ.UI
{
    public class OptionCanvasController : MonoBehaviour
    {
        private void Awake()
        {
            // 씬 전환 후에도 유지되도록 설정
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
