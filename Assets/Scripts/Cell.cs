using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Figure Figure {get; private set;}

    void OnMouseDown()
    {
        if (Figure != null) return;

        Figure maybeFigure = GameManager.Instance.SpawnNextFigure(this);
        if (maybeFigure != null) {
            Figure = maybeFigure;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        GameManager.Instance.CheckWinner(this);
    }
}
