using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroHPXPManager : MonoBehaviour {

    [SerializeField] private Slider _HPBar;
    [SerializeField] private Slider _XPBar;

    private void Awake()
    {
        Messenger<float>.AddListener(MessengerEventsHolder.GameViewVisual.HPChanged.ToString(), UpdateHP);
        Messenger<float>.AddListener(MessengerEventsHolder.GameViewVisual.XPChanged.ToString(), UpdateXP);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(MessengerEventsHolder.GameViewVisual.HPChanged.ToString(), UpdateHP);
        Messenger<float>.RemoveListener(MessengerEventsHolder.GameViewVisual.XPChanged.ToString(), UpdateXP);
    }



    private void UpdateHP(float HP)
    {
        _HPBar.value = HP;
    }
    private void UpdateXP(float XP)
    {
        _XPBar.value = XP;
    }

}
