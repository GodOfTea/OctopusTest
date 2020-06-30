using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameStateButton : MonoBehaviour
{
    [SerializeField] private MapController mapController;
    [SerializeField] private Tips tips;

    [SerializeField] private GameObject gameMenu;

    [SerializeField] private UILabel switchGameStateLabel;
    [SerializeField] private string startGame = "Start Game";
    [SerializeField] private string editMap = "Edit Map";
    public void SwitchGameState()
    {
        if (mapController.grid.transform.childCount == 0)
                {
                    tips.ShowTip("StartWithoutMap");
                    return;
                }

        GameManager.IsMapEdit = !GameManager.IsMapEdit;

        switchGameStateLabel.text = 
                    GameManager.IsMapEdit == true ? startGame : editMap;

        if (GameManager.IsMapEdit == false)
        {
            tips.ShowTip("StartGameTip");
            gameMenu.SetActive(true);
        }
        else 
        {
           tips.ShowTip("MapEditTip");
           gameMenu.SetActive(false);
        }
    }
}
