using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WidgetColorSelected : WidgetBase
{
    [SerializeField]
    private Image primaryImage;
    [SerializeField]
    private Image secondaryImage;

    public override void Awake()
    {
        base.Awake();

        primaryImage.material = Instantiate(primaryImage.material);
        primaryImage.material = Instantiate(secondaryImage.material);
    }

    public void UpdateValue(ColorExt primary, ColorExt secondary)
    {
        // Discard alpha and apply it in shader
        Color primaryNoAlpha = new Color(primary.color.r, primary.color.g, primary.color.b, 1.0f);
        Color secondaryNoAlpha = new Color(secondary.color.r, secondary.color.g, secondary.color.b, 1.0f);

        primaryImage.color = primaryNoAlpha;
        secondaryImage.color = secondaryNoAlpha;

        primaryImage.material.SetFloat("_Alpha", primary.color.a);
        secondaryImage.materialForRendering.SetFloat("_Alpha", secondary.color.a);
    }
}