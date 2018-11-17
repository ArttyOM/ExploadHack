using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOnMapGenerator : MonoBehaviour {

    [SerializeField] private Transform _mapTransform;
    [SerializeField] private GameObject _questPrefab;

    private float _minQuestGenPeriod;
    private float _maxQuestGetPeriod;

    //ToDO убрать хардкод
    private float maxWidth = 512;
    private float maxHeigh = 360;


    private void Awake()
    {
        _minQuestGenPeriod = StaticSettings.minQuestGenPeriod;
        _maxQuestGetPeriod = StaticSettings.maxQuestGetPeriod;

        StartCoroutine(QuestGenerator());
    }

    private IEnumerator QuestGenerator()
    {
        for (int i =0; ; )
        {
            yield return new WaitForSeconds(_minQuestGenPeriod);

            Debug.Log("Quest ID=" + i + " generated");
            i++;

            Vector2 rndVec = new Vector2(
                Random.Range(-maxWidth/2, maxWidth / 2), Random.Range(-maxHeigh / 2, maxHeigh / 2));
            QuestOnMap.CreateInstance(_questPrefab, _mapTransform, rndVec);

            yield return new WaitForSeconds(Random.Range(0f, _maxQuestGetPeriod - _minQuestGenPeriod));

        }
    }
}
