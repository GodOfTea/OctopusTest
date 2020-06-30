using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MapController : MonoBehaviour, IMap
{
    [SerializeField] private Land land;
    [SerializeField] private Water water;

    public Transform grid; 

    [SerializeField] private float xStep;
    [SerializeField] private float hStep;

    [SerializeField] private Vector2 startPosition;

    public int rows;
    public int cellsInRow;

    [ShowInInspector] private List<ICell> cells {get; set;}
    public List<ICell> _cells {
        get {return cells;} 
        set {cells = value;}}

    public bool isRandomMap;


    private void Start()
    {
        cells = new List<ICell>();
    }

    public void CleanMap()
    {
        foreach (var cell in cells)
        {
            if (cell._isObstacle == false)
            {
                Land currentLand = (Land)cell;
                currentLand.SetToDefault();
            }
        }
    }

    public void DrawMap()
    {
        /* чистим сетку и list*/
        if (grid.transform.childCount > 0)
        {
            grid.transform.DestroyChildren();
            cells.RemoveRange(0, cells.Count);
        }

        var position = startPosition;

        for (int i = 0; i < rows; i++)
        {
            var lenght = i % 2 == 0 ? cellsInRow : cellsInRow - 1;
            
            for (int j = 0; j < lenght; j++)
            {
                bool isLand = true;

                if (isRandomMap == true)
                {
                    var value = Random.Range(0, 10);
                    isLand = value < 7 ? true : false;
                }

                /* подлежит оптимизации */
                if (isLand)
                {
                    land.Spawn(i, j, position, grid);
                }
                else
                    water.Spawn(i, j, position, grid);

                position.x += xStep;
            }

            position.x = i % 2 == 0 ? startPosition.x + xStep/2 : 
                                      startPosition.x;
            position.y -= hStep; 
        }

        foreach (Transform child in grid)
        {
            cells.Add(child.GetComponent<Cell>());
        }
    }

    /*public void SwitchCellState(bool isObstacle, int rowNumber, int cellInRowNumber)
    {
        // добавить бинарный поиск или линку
        for (int i = 0; i < cells.Count; i++)
        {   
            if (cells[i]._isObstacle != isObstacle) 
                continue;
            else if (cells[i]._rowNumber == rowNumber && 
                     cells[i]._cellInRowNumber == cellInRowNumber)
            {
                if (isObstacle == true)
                    land.Spawn(rowNumber, cellInRowNumber, cells[i]._cellPosition, grid);
                else
                    water.Spawn(rowNumber, cellInRowNumber, cells[i]._cellPosition, grid);

                ICell newCell = cells[i];
                cells.RemoveAt(i);
                newCell.Destroy();

                break;
            }
        }

        cells.Add(grid.GetChild(cells.Count-1).GetComponent<Cell>());
        Debug.Log("SwitchCellState complete");
    }*/
}
