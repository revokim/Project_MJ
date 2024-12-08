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
                myText.text = string.Format("Lv. {0:D3}", GameManager.Instance.player.playerLevel);
                break;
            case InfoType.Kill: ;
                break;
            case InfoType.Time:
                TimeSpan timeSpan = TimeSpan.FromSeconds(GameManager.Instance.gameTime);
                myText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                break;
            case InfoType.Health:
                break;
        }
    }
}
