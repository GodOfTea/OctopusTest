using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SetDataInUI : MonoBehaviour
{
    [Title("Scripts")]
    [SerializeField] private GameManager gameManager;

    [Title("UILabels")]
    [SerializeField] private UILabel startLabel;
    [SerializeField] private UILabel endLabel;
    [SerializeField] private UILabel lengthLabel;


    public void SetData()
    {
        startLabel.text  = string.Format("[{0};{1}]", gameManager.StartCell._rowNumber, gameManager.StartCell._cellInRowNumber);
        endLabel.text    = string.Format("[{0};{1}]", gameManager.EndCell._rowNumber, gameManager.EndCell._cellInRowNumber);
        lengthLabel.text = string.Format("{0}", gameManager.pathLength);
    }
}
