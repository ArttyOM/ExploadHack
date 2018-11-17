using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_XP_RunAwayCost_TestBroadcaster : MonoBehaviour {


    private void Start()
    {
        Messenger<float>.Broadcast(MessengerEventsHolder.GameViewVisual.InstaRunAwayCost.ToString(), 659f);
        Messenger<float>.Broadcast(MessengerEventsHolder.GameViewVisual.HPChanged.ToString(), 0.8f);
        Messenger<float>.Broadcast(MessengerEventsHolder.GameViewVisual.XPChanged.ToString(), 0.8f);
    }
    


}
