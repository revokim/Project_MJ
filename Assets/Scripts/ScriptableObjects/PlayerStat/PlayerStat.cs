using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace MJ.Player
{
    // 인게임에 처음 들어갈 때 플레이어의 스탯을 지정하는 역할을 합니다.
    // 즉, 인게임 요소로는 해당 값은 변하지 않고, 상점 화면의 강화를 통해서만 변경됩니다.
    
    [CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]
    public class PlayerStat : ScriptableObject
    {
        public float playerAttackPower = 10f;
        public float playerHp = 100f;
        public int playerLevel = 1;
        public float playerExp = 0;
        public float playerMoveSpeed = 5.0f; // [test]초기 이동속도, 테스트 필요
    }
}