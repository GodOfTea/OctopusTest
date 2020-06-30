using UnityEngine;

public interface ICell
{
    int _pathLenght {get; set;}
    int _fromPointToEndLenght {get; set;}
    ICell _cameFrom {get; set;}
    int _fullLength {get;}

    
    Vector2 _cellPosition {get; set;}
    int _rowNumber {get; set;}
    int _cellInRowNumber {get; set;}
    bool _isObstacle {get; set;}

    void ActionOnClick();
    /* void SwitchState(); */ /* не реализовано */
    void Destroy();
}
