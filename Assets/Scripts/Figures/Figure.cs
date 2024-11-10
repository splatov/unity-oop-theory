using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    // ENCAPSULATION
    [field: SerializeField] protected Material winnerMaterial { get; private set; }

    // POLYMORPHISM
    public abstract void applyWinnerMaterial();
}
