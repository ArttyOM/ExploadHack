using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD_TestBroadcaster : MonoBehaviour {

    private void Awake()
    {
        Messenger.AddListener(MessengerEventsHolder.GameViewVisual.EndDodgeCD.ToString(), OnEndCD);

        StartCoroutine(BroadcastWithPeriod(StaticSettings.dodgeCooldown+2f));
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(MessengerEventsHolder.GameViewVisual.EndDodgeCD.ToString(), OnEndCD);
    }

    private IEnumerator BroadcastWithPeriod (float seconds)
    {
        for (; ; )
        {
            Messenger.Broadcast(MessengerEventsHolder.GameViewVisual.StartDodgeCD.ToString());
            yield return new WaitForSeconds(seconds);
        }
    }

    private void  OnEndCD()
    {
        Debug.Log("Dodge is active now");
    }
}
