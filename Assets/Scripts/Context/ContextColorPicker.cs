using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextColorPicker : ContextBase
{
    [SerializeField]
    public ColorExt primaryColor;
    [SerializeField]
    public ColorExt secondaryColor;

    public void Swap()
    {
        ColorExt temp = primaryColor;
        primaryColor = secondaryColor;
        secondaryColor = temp;

        MarkDirty();
    }

    public void SetPrimaryColorHSV(float h, float s, float v)
    {
        primaryColor.SetHSV(h, s, v);

        MarkDirty();
    }

    public void SetPrimaryColorChannel(ColorChannel channel, float value)
    {
        primaryColor.SetColorChannel(channel, value);

        MarkDirty();
    }
}
