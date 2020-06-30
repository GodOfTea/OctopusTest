using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Cell
{
    [SerializeField] private Sprite water;
    

    private void Start()
    {
        isObstacle = true;
    }
}
