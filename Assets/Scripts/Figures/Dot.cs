using UnityEngine;

public class Dot : Figure
{
    public override void applyWinnerMaterial()
    {
        transform.GetChild(0).GetComponent<Renderer>().material = winnerMaterial;
    }
}
