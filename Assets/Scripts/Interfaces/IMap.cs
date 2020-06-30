using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMap
{
    List<ICell> _cells {get; set;}
    void DrawMap();
    
    /* void SwitchCellState(bool isObstacle, int rowNumber, int cellInRowNumber); */
    /* к сожалению, не успел реализовать */
}
