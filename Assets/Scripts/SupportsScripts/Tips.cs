using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] private UILabel tipLabel;

    /* Оптимизировать если будет время */ /* Времени не нашлось */
    private Dictionary<string, string> tips = new Dictionary<string, string>()
    {
        {"StartGameTip", "Первое нажатие ЛКМ - установить начальную позицию, " +
        "второе нажатие установить конечную позицию"},

        {"MapEditTip", "Нажмите Generate Map для создания игрового поля. " +
        "Для создания случайного игрового поля, поменяйте знаение у параметра Random Generate " +
        "(на данный момент работает только рандомная генерация)."},

        {"StartWithoutMap", "Нельзя начать игру, пока не сгенерированна карта, нажмите кнопку Generate Map"}
    }; 

    private void Start()
    {
        ShowTip("MapEditTip");
    }

    public void ShowTip(string text)
    {
        tipLabel.text = tips[text];
    }
}
