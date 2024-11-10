using UnityEngine;

// INHERITANCE
public class Dot : Figure
{
    // POLYMORPHISM
    public override void applyWinnerMaterial()
    {
        transform.GetChild(0).GetComponent<Renderer>().material = winnerMaterial;
    }
}
