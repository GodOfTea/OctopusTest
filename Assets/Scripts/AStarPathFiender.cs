using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarPathFiender : MonoBehaviour, IPathFinder
{
    [SerializeField] private MapController mapController;


    public IList<ICell> FindPathOnMap(ICell cellStart, ICell cellEnd, IMap map)
    {
        //Debug.Log("Старт FindPathOnMap");
        
        var closedCells = new List<ICell>();
        var openCells = new List<ICell>();

        //Debug.Log("Создание начальной координаты");

        cellStart._cameFrom = null;
        cellStart._pathLenght = 0;
        cellStart._fromPointToEndLenght = GetFromPointToEnd(cellStart, cellEnd);

        openCells.Add(cellStart);

        //Debug.Log("Запуск цикла поиска пути");
        while (openCells.Count > 0)
        {
            ICell currentCell = openCells[0];
            foreach (var c in openCells)
            {
                if (c._fullLength < currentCell._fullLength)
                    currentCell = c;
            }
            
            
            if (currentCell == cellEnd)
            {
                //Debug.Log("Путь найден!!!");
                return GetPath(currentCell);
            }

            openCells.Remove(currentCell);
            closedCells.Add(currentCell);

            //Debug.Log("Поиск соседей");
            foreach (var neighbourCell in GetNeighbourCells(cellStart, currentCell, cellEnd, map))
            {
                if (closedCells.Count(c => 
                c._rowNumber == neighbourCell._rowNumber &&
                c._cellInRowNumber == neighbourCell._cellInRowNumber) > 0)
                {
                    continue;
                }
                
                var openCell = openCells.FirstOrDefault(c => 
                c._rowNumber == neighbourCell._rowNumber &&
                c._cellInRowNumber == neighbourCell._cellInRowNumber);

                if (openCell == null)
                {
                    openCells.Add(neighbourCell);
                }
                else if (openCell._pathLenght > neighbourCell._pathLenght)
                {
                    openCell._cameFrom = currentCell;
                    openCell._pathLenght = neighbourCell._pathLenght;
                }
            }
        }

        //Debug.LogWarning("Путь не найден!");
        return null;
    }

    /* расчет пути от точки до конца */
    private int GetFromPointToEnd(ICell cellStart, ICell cellEnd)
    {
        Debug.Log("Старт GetFromPointToEnd");
        int startRow = cellStart._rowNumber;
        int startCell = cellStart._cellInRowNumber;

        int endRow = cellEnd._rowNumber;
        int endCell = cellEnd._cellInRowNumber;

        if (startCell == endCell ||
            startCell == endCell + 1 ||
            startCell == endCell - 1)
            {
                return Mathf.Abs(startRow - endRow);
            }
        else
        {
            return Mathf.Abs(startCell - endCell - 1) +
                Mathf.Abs (startRow - endRow);
        }
    }

    /* получение пути */ /* тут виснет намертво (пофикшено)*/
    private List<ICell> GetPath(ICell cell)
    {
        Debug.Log("Старт GetPath");
        var result = new List<ICell>();
        var currenCell = cell;

        while (currenCell != null)
        {
            result.Add(currenCell);
            currenCell = currenCell._cameFrom;

        }
        result.Reverse();

        Land point;
        for (int i = 1; i <result.Count - 1; i++)
        {
            point = (Land)result[i];
            point.SetPointCell();
        }

        return result;
    }

    /* поиск соседей */
    private List<ICell> GetNeighbourCells (ICell startCell, ICell cell, ICell cellEnd, IMap map)
    {
        Debug.Log("Старт GetNeighbourCells");
        var result = new List<ICell>();

        /* соседи */ /* макс. 6 */
        List<ICell> neighbourCells = new List<ICell>();

#region добавление соседей
        /* правая */
        neighbourCells.Add(map._cells.FirstOrDefault(
            c => c._rowNumber == cell._rowNumber && 
            c._cellInRowNumber == cell._cellInRowNumber + 1));
        /* левая */
        neighbourCells.Add(map._cells.FirstOrDefault(
            c => c._rowNumber == cell._rowNumber && 
            c._cellInRowNumber == cell._cellInRowNumber - 1));

        if (cell._rowNumber % 2 == 0) /* четная */
        {
            /* право верх */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber - 1 && 
                c._cellInRowNumber == cell._cellInRowNumber));
            /* лево верх */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber - 1 && 
                c._cellInRowNumber == cell._cellInRowNumber - 1));
            /* лево низ */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber + 1 && 
                c._cellInRowNumber == cell._cellInRowNumber - 1));
            /* право низ */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber + 1 && 
                c._cellInRowNumber == cell._cellInRowNumber));
        }
        else /* нечетная */
        {
            /* право верх */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber - 1 && 
                c._cellInRowNumber == cell._cellInRowNumber + 1));
            /* лево верх */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber - 1 && 
                c._cellInRowNumber == cell._cellInRowNumber));
            /* лево низ */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber + 1 && 
                c._cellInRowNumber == cell._cellInRowNumber));
            /* право низ */
            neighbourCells.Add(map._cells.FirstOrDefault(
                c => c._rowNumber == cell._rowNumber + 1 && 
                c._cellInRowNumber == cell._cellInRowNumber + 1));
        }
#endregion
        
        neighbourCells = neighbourCells.Where(c => c != null).ToList();        

        foreach (var nCell in neighbourCells)
        {
            if (nCell._isObstacle == true)
                continue;
            
            if (nCell._cameFrom == null && nCell != startCell) /* Поможет? */ /* ДА! */
                nCell._cameFrom = cell;
            nCell._pathLenght = cell._pathLenght + 
                                        GetDistanceBetweenNeighboursCell();
            nCell._fromPointToEndLenght = 
                                        GetFromPointToEnd(nCell, cellEnd);

            result.Add(nCell);
        }

        return result;
    }

    private int GetDistanceBetweenNeighboursCell()
    {
        return 1;
    }
}
