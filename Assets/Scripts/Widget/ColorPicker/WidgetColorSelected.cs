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
        primaryImage.color = primary.color;
        secondaryImage.color = secondary.color;
    }
}