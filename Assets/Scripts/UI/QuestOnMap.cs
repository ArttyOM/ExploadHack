using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum QuestType { usual, tutorial }

[RequireComponent (typeof (RectTransform))]
public class QuestOnMap : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="questPrefab"></param>
    /// <param name="parent"></param>
    /// <param name="pos">позиция относительно центра</param>
    /// <returns></returns>
    public static GameObject CreateInstance(GameObject questPrefab, Transform parent,Vector2 pos)
    {
        GameObject result = Instantiate(questPrefab, parent); //спавним в центре
        Vector3 tmp = result.transform.localPosition;
        tmp.x += pos.x;
        tmp.y += pos.y;

        result.transform.localPosition += tmp;

        return result;
    }

    [SerializeField] private QuestType qType = QuestType.usual;


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(delegate { OnBtn(MessengerEventsHolder.QuestInfoViewButtons.ShowQuestInfoView); });
    }


    // Use this for initialization
    void Start () {
        if (qType == QuestType.usual)
        {
            StartCoroutine(SelfDestroy());
        }
	}

    private void OnBtn(Enum onClickEvent)
    {
        Debug.Log(onClickEvent.ToString());
        Messenger.Broadcast(onClickEvent.ToString());
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(StaticSettings.questLifetime);
        Debug.Log("Quest destroyed");
        Destroy(this.gameObject);
    }
}
