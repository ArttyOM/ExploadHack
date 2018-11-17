using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstaRunAwayCost : MonoBehaviour {

    [SerializeField] private Text _Text;

    private void Awake()
    {
        Messenger<float>.AddListener(MessengerEventsHolder.GameViewVisual.InstaRunAwayCost.ToString(), UpdateText);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(MessengerEventsHolder.GameViewVisual.InstaRunAwayCost.ToString(), UpdateText);
    }

    private void UpdateText(float value)
    {
        _Text.text = value.ToString();
    }
    
}
