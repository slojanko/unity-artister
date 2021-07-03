using UnityEditor;
using UnityEngine;

public enum ColorChannel
{
    Red = 0,
    Green = 1,
    Blue = 2,
    Alpha = 3,
    Hue = 4,
    Saturation = 5,
    Value = 6
}

[System.Serializable]
public class ColorExt
{
    public Color color;
    public float h, s, v;

    public ColorExt(float h, float s, float v)
    {
        SetHSV(h, s, v);
    }

    public void SetHSV(float h, float s, float v)
    {
        var newColor = Color.HSVToRGB(h, s, v);
        color.r = newColor.r;
        color.g = newColor.g;
        color.b = newColor.b;

        this.h = h;
        this.s = s;
        this.v = v;
    }

    public float GetColorChannel(ColorChannel channel)
    {
        return channel switch
        {
            ColorChannel.Red => color.r,
            ColorChannel.Green => color.g,
            ColorChannel.Blue => color.b,
            ColorChannel.Alpha => color.a,
        };
    }

    public void SetColorChannel(ColorChannel channel, float value)
    {
        switch (channel)
        {
            case ColorChannel.Red:
                color.r = value;
                break;
            case ColorChannel.Green:
                color.g = value;
                break;
            case ColorChannel.Blue:
                color.b = value;
                break;
            case ColorChannel.Alpha:
                color.a = value;
                break;
        }

        Color.RGBToHSV(color, out h, out s, out v);
    }
}