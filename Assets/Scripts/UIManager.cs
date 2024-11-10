using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text currentMoveText;
    [SerializeField] private Text winnerText;
    [SerializeField] private Text drawText;
    [SerializeField] private Figure crossFigure;
    [SerializeField] private Figure dotFigure;

    public void SwapFigure()
    {
        bool showDot = crossFigure.gameObject.activeSelf;
        crossFigure.gameObject.SetActive(!showDot);
        dotFigure.gameObject.SetActive(showDot);
    }

    public void ShowWinner()
    {
        currentMoveText.gameObject.SetActive(false);
        winnerText.gameObject.SetActive(true);
    }

    public void ShowDraw()
    {
        currentMoveText.gameObject.SetActive(false);
        crossFigure.gameObject.SetActive(false);
        dotFigure.gameObject.SetActive(false);
        drawText.gameObject.SetActive(true);
    }
}
