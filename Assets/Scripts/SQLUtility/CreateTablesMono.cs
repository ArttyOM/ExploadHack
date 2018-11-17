using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTablesMono : MonoBehaviour {

    public void CreateTables()
    {
        DataService ds = DataService.MAINDB;
        ds.CreateLazyTables();

        Debug.Log("Таблицы созданы");
    }

}
