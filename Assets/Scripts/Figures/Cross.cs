using UnityEngine;

public class Cross : Figure
{
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
