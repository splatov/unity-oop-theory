using UnityEngine;

// INHERITANCE
public class Cross : Figure
{
    // POLYMORPHISM
    public override void applyWinnerMaterial()
    {
        Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer.gameObject.CompareTag("Paintable"))
            {
                renderer.material = winnerMaterial;
            }
        }
    }
}
