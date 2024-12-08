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
                float curExp = GameManager.Instance.player.PlayerExp;
                float maxExp = GameManager.Instance.player.nextExp[GameManager.Instance.player.PlayerLevel];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv. {0:D3}", GameManager.Instance.player.PlayerLevel);
                break;
            case InfoType.Kill: ;
                break;
            case InfoType.Time:
                TimeSpan timeSpan = TimeSpan.FromSeconds(GameManager.Instance.gameTime);
                myText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                break;
            case InfoType.Health:
                float curHp = GameManager.Instance.player.PlayerHp;
                float maxHp = GameManager.Instance.player.PlayerMaxHp;
                mySlider.value = curHp / maxHp;
                break;
        }
    }
}
