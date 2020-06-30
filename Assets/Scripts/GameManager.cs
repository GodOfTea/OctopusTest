using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static bool IsMapEdit;
    public static bool StartEnabled;
    public static bool EndEnabled;

    [SerializeField] private AStarPathFiender pathFiender;
    public MapController mapController;

    [ShowInInspector] public ICell EndCell;
    [ShowInInspector] public ICell StartCell;

    public string pathLength;

    public UnityEvent SetDataInUI;

    private void Start()
    {
        StartEnabled = false;
        EndEnabled   = false;
        IsMapEdit    = true;
    }

    public void StartPathfind()
    {
        Debug.Log("StartPathfind");

        IList<ICell> result = new List<ICell>();
        result = pathFiender.FindPathOnMap(StartCell, EndCell, mapController);

        pathLength = result == null ? "Пути нет" : (result.Count - 1).ToString();

        SetDataInUI.Invoke();

        Debug.Log("Результат: ");

        int i = 0;
        if (result != null)
        {
            foreach (var cell in result)
            {
                Debug.LogFormat("Клетка {0}, строка {1}, клетка {2}",
                                i, cell._rowNumber, cell._cellInRowNumber);
                i += 1;
            }   
        }     
    }
}
