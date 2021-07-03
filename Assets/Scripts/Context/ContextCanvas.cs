using UnityEngine;

public class ContextCanvas : ContextBase
{
    [SerializeField]
    public Texture2D texture;
    [SerializeField]
    public RenderTexture canvasTexture;
    [SerializeField]
    public RenderTexture effectTexture;

    public override void Awake()
    {
        base.Awake();
        CreateTextures();
    }

    public void CreateTextures()
    {
        // Match formats and disable mipmaps
        texture = new Texture2D(640, 480, TextureFormat.ARGB32, false);
        canvasTexture = new RenderTexture(640, 480, 16, RenderTextureFormat.ARGB32, 0);
        effectTexture = new RenderTexture(640, 480, 16, RenderTextureFormat.ARGB32, 0);

        texture.anisoLevel = 0;
        texture.filterMode = FilterMode.Point;
        canvasTexture.filterMode = FilterMode.Point;
        effectTexture.filterMode = FilterMode.Point;

        // White
        Graphics.Blit(Texture2D.whiteTexture, effectTexture);
        Graphics.CopyTexture(effectTexture, canvasTexture);
        Graphics.CopyTexture(effectTexture, texture);
    }

    public void ApplyEffect(Material effect)
    {
        Graphics.Blit(canvasTexture, effectTexture, effect);
        Graphics.CopyTexture(effectTexture, canvasTexture);
        Graphics.CopyTexture(effectTexture, texture);
    }

    public void PaintBrush(ColorExt primary, Sprite brush, Vector2 position)
    {
        var brushTexture = brush.texture;
        RenderTexture.active = canvasTexture;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, 640, 480, 0);

        Graphics.DrawTexture(new Rect(position.x - brushTexture.width / 2, position.y - brushTexture.height / 2, brushTexture.width, brushTexture.height), brushTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, primary.color);

        GL.PopMatrix();
        RenderTexture.active = null;
    }
}