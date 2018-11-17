using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeCD : MonoBehaviour {

    [SerializeField] private Image _CooldownIMG;
    //private float _cooldownSeconds; //из-за наличия _cooldownPeriod и записи в статике - это поле не нужно
    private float _cooldownFreq;//обратная величина к _cooldownSeconds

    private void Awake()
    {
        //_cooldownSeconds = StaticSettings.dodgeCooldown;
        _cooldownFreq = 1f / StaticSettings.dodgeCooldown;

        Messenger.AddListener(MessengerEventsHolder.GameViewVisual.StartDodgeCD.ToString(), OnCooldown);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(MessengerEventsHolder.GameViewVisual.StartDodgeCD.ToString(), OnCooldown);
    }

    private void OnCooldown()
    {
        _CooldownIMG.fillAmount = 0;
        StartCoroutine(ImgFiller());
    }

    private IEnumerator ImgFiller()
    {
        float fAm = 0f;
        while (fAm<1)
        {
            fAm+= Time.deltaTime *_cooldownFreq ;
            if (fAm >= 1f) fAm = 1f;

            _CooldownIMG.fillAmount = fAm;

            yield return null;
        }

        Messenger.Broadcast(MessengerEventsHolder.GameViewVisual.EndDodgeCD.ToString());
    }
}
