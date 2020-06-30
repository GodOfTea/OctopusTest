using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Cell : MonoBehaviour, ICell
{
    /* небольшой беспорядок в переменных */
    public SpriteRenderer spriteRenderer;

    [ShowInInspector] private ICell cameFrom;

    [SerializeField] private Vector2 cellPosition;

    [SerializeField] private int pathLenght;
    [SerializeField] private int fromPointToEndLenght;
    [SerializeField] private int rowNumber;
    [SerializeField] public int cellInRowNumber;
    
    [SerializeField] public bool isObstacle;
    
    public int _pathLenght {
        get {return pathLenght;} 
        set {pathLenght = value;}}
    public int _fromPointToEndLenght {
        get {return fromPointToEndLenght;} 
        set {fromPointToEndLenght = value;}}
    public int _fullLength {
        get { return _pathLenght + fromPointToEndLenght; }
    }
    public ICell _cameFrom {
        get {return cameFrom;}
        set {cameFrom = value;}}
    
    public Vector2 _cellPosition {
        get {return cellPosition;} 
        set {cellPosition = value;}}
    public int _rowNumber {
        get {return rowNumber;} 
        set {rowNumber = value;}}
    public int _cellInRowNumber {
        get {return cellInRowNumber;} 
        set {cellInRowNumber = value;}}
    public bool _isObstacle {
        get {return isObstacle;} 
        set {isObstacle = value;}}


    public Cell Spawn(int i, int j, Vector2 pos, Transform parent)
    {
        rowNumber = i;
        cellInRowNumber = j;
        cellPosition = pos;

        Instantiate(gameObject, pos, Quaternion.identity, parent);

        return this;
    }

    private void OnMouseDown()
    {
        ActionOnClick();
    }

    public virtual void ActionOnClick()
    {
        /*if (GameManager.IsMapEdit == true)
            SwitchState();*/
    }

    public void Destroy()
    {
        Debug.Log("Destroy");

        Destroy(gameObject);
    }

    /*public void SwitchState()
    { 
        Debug.Log("SwitchState");

        MapController mapController = GameObject.FindGameObjectWithTag(
            "MapController").GetComponent<MapController>();

        mapController.SwitchCellState(isObstacle, rowNumber, cellInRowNumber);
    }*/
}
