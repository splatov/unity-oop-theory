using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Figure Figure { get; private set; }
    private bool isCollisionTriggered;

    void OnMouseDown()
    {
        if (Figure != null) return;

        Figure maybeFigure = GameManager.Instance.SpawnFigure(this);
        if (maybeFigure != null)
        {
            Figure = maybeFigure;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (!isCollisionTriggered)
        {
            GameManager.Instance.CheckWinner(this);
            isCollisionTriggered = true;
        }
    }
}
