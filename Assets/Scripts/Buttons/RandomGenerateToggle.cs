using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerateToggle : MonoBehaviour
{
    [SerializeField] private MapController mapController; 
    public void OnOffRandomMapGenerate()
    {
        mapController.isRandomMap = !mapController.isRandomMap;
    }
}
