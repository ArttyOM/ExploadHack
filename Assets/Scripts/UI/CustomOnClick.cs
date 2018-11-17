using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// С параметром Auto кнопка будет передавать в качестве сообщения свое имя
/// </summary>
public class CustomOnClick : MonoBehaviour {

    //public int armor = 75;
    //public int damage = 25;
    

    [SerializeField]
    private ButtonOwner window = ButtonOwner.Auto;
    [SerializeField]
    private MessengerEventsHolder.UIButtons _gameViewEvent = MessengerEventsHolder.UIButtons.NotSelected;
    [SerializeField]
    private MessengerEventsHolder.QuestInfoViewButtons _questInfoViewEvent = MessengerEventsHolder.QuestInfoViewButtons.NotSelected;
    //[SerializeField]
    //private GameEvents1.UICityEvent onCityViewEvent;
    //private GameEvents

    private void Awake()
    {

        Enum myGameEvent = _gameViewEvent;

        switch (window)
        {
            case ButtonOwner.Auto:
                //Debug.Log(name);

                //пытаемся преобразовать имя нашего Gameobject-а в Enum
                MessengerEventsHolder.UIButtons tmpGameEvent;
                MessengerEventsHolder.QuestInfoViewButtons tmpQuestInfoEvent;
                //GameEvents1.UICityEvent tmpCityEvent;

                // if (TryParse<MessengerEventsHolder.UIButtons>(name, out tmpGameEvent))
                if (Enum.TryParse<MessengerEventsHolder.UIButtons>(name, out tmpGameEvent))
                {
                    //Если получается преобразовать в UIGameEvent - кешируем в myGameEvent, потом отдадим его в OnBtn
                    myGameEvent = tmpGameEvent;
                }
                else if (Enum.TryParse<MessengerEventsHolder.QuestInfoViewButtons>(name, out tmpQuestInfoEvent))
                {
                    //Если получается преобразовать в UIGameEvent - кешируем в myGameEvent, потом отдадим его в OnBtn
                    myGameEvent = tmpQuestInfoEvent;
                }
                //else//если не получается, пробуем преобразовать в UICityEvent
                //{
                //    if (TryParse<GameEvents1.UICityEvent>("ON_" + name, out tmpCityEvent))
                //    {
                //        //Если получается преобразовать в UICityEvent - кешируем в myGameEvent, потом отдадим его в OnBtn
                //        myGameEvent = tmpCityEvent;
                //    }
                //    else return;//если опять не получилось -> не является нашим энум, не вешаем на кнопку
                //}

                break;

            case ButtonOwner.GameView:
                myGameEvent = _gameViewEvent;
                break;

            case ButtonOwner.QuestInfo:
                myGameEvent = _questInfoViewEvent;
                break;
            //case ButtonOwner.CityView:
            //    myGameEvent = onCityViewEvent;
            //    break;
            default: break;
        }

        //Debug.Log(myGameEvent.ToString());
        GetComponent<Button>().onClick.AddListener(delegate { OnBtn(myGameEvent); });
    }

    private void OnBtn (Enum onClickEvent)
    {
        Debug.Log(onClickEvent.ToString());
        Messenger.Broadcast(onClickEvent.ToString());
    }

    /// <summary>
    /// В .Net 3.5 нет Enum.TryParse, пришлось стырить c тырнетов
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    //public static bool TryParse<TEnum>(string value, out TEnum result)
    //where TEnum : struct, IConvertible
    //{
    //    var retValue = value == null ?
    //                false :
    //                Enum.IsDefined(typeof(TEnum), value);
    //    result = retValue ?
    //                (TEnum)Enum.Parse(typeof(TEnum), value) :
    //                default(TEnum);
    //    return retValue;
    //}

}



/// <summary>
/// Режим Авто передает в качестве сообщения по клику ("ON_"+имя объекта)
/// </summary>
public enum ButtonOwner { Auto, GameView, QuestInfo /*, CityView*/ }
