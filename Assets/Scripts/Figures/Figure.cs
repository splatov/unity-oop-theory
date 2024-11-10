using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    [field: SerializeField] public Material winnerMaterial {get; private set;}
    
    public abstract void applyWinnerMaterial();

    void OnMouseDown()
    {
        applyWinnerMaterial();
    }
}
