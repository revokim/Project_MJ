using System;
using MJ;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Exp, Level, Kill, Time, Health}
    public InfoType type;
    
    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.Instance.player.playerExp;
                float maxExp = GameManager.Instance.player.nextExp[GameManager.Instance.player.playerLevel];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = $"Lv. {GameManager.Instance.player.playerLevel}";
                break;
            case InfoType.Kill: ;
                break;
            case InfoType.Time:
                break;
            case InfoType.Health:
                break;
        }
    }
}
