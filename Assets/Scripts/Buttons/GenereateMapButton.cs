using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenereateMapButton : MonoBehaviour
{
    [SerializeField] private MapController mapController;
    [SerializeField] private Tips tips;

    public void GenerateMap()
    {
        if (GameManager.IsMapEdit == true)
        {
            mapController.DrawMap();
            tips.ShowTip("MapEditTip");
        }
    }
}
