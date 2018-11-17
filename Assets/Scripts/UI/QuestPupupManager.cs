using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuestPupupManager : MonoBehaviour {

    [SerializeField] private GameObject _questInfoView;

    private void Awake()
    {
        Messenger.AddListener(MessengerEventsHolder.QuestInfoViewButtons.DeclineFight.ToString(), OnDeclineFight);
        Messenger.AddListener(MessengerEventsHolder.QuestInfoViewButtons.AcceptFight.ToString(), OnAcceptFight);
        Messenger.AddListener(MessengerEventsHolder.QuestInfoViewButtons.ShowQuestInfoView.ToString(), OnQuestSelected);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(MessengerEventsHolder.QuestInfoViewButtons.DeclineFight.ToString(), OnDeclineFight);
        Messenger.RemoveListener(MessengerEventsHolder.QuestInfoViewButtons.AcceptFight.ToString(), OnAcceptFight);
        Messenger.RemoveListener(MessengerEventsHolder.QuestInfoViewButtons.ShowQuestInfoView.ToString(), OnQuestSelected);
    }

    private void  OnDeclineFight()
    {
        _questInfoView.SetActive(false);
    }
    private void OnAcceptFight()
    {
        //Debug.Log("Challenge accepted");
        SceneManager.LoadScene(1);
    }
    
    private void OnQuestSelected()
    {
        _questInfoView.SetActive(true);
    }
}
