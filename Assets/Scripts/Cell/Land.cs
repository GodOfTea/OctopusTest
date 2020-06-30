using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : Cell
{
    [SerializeField] private new SpriteRenderer tag;

    [SerializeField] private Sprite land;
    [SerializeField] private Sprite start;
    [SerializeField] private Sprite end;
    [SerializeField] private Sprite point;

    [SerializeField] private bool isStart;
    [SerializeField] private bool isEnd;
    [SerializeField] private bool isPoint;

    private GameManager gameManager;


    private void Start()
    {
        isObstacle = false;
        isStart    = false;
        isEnd      = false;
        isPoint    = false;
    }

    private void OnMouseDown()
    {
        ActionOnClick();
    }

    public override void ActionOnClick()
    {
        base.ActionOnClick();

        if (GameManager.IsMapEdit == false)
        {
        if (isEnd == false && GameManager.StartEnabled == false)
            SetStartCell();
        else if (isStart == false && GameManager.EndEnabled == false)
            SetEndCell();
        }
    }

    private void SetStartCell()
    {
        if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.mapController.CleanMap();

        Debug.Log("SetStartCell");
        tag.sprite = start;
        
        isStart = true;
        GameManager.StartEnabled = true;
        GameManager.EndEnabled = false;

        gameManager.StartCell = this;
    }

    private void SetEndCell()
    {
        Debug.Log("SetEndCell");
        tag.sprite = end;

        isEnd = true;
        GameManager.EndEnabled = true;
        GameManager.StartEnabled = false;

        if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.EndCell = this;
        gameManager.StartPathfind();
    }

    public void SetPointCell()
    {
        tag.sprite = point;
        isPoint = true;
    }

    public void SetToDefault()
    {
        _fromPointToEndLenght = 0;
        _pathLenght           = 0;
        tag.sprite            = null;
        _cameFrom             = null;
        isStart               = false;
        isEnd                 = false;
        isPoint               = false;
    }
}
