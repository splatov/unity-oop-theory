using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    [field: SerializeField] protected Material winnerMaterial {get; private set;}
    
    public abstract void applyWinnerMaterial();
}
