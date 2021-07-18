using UnityEngine;

public class ContextCanvas : ContextBase
{
    [SerializeField]
    public Texture2D texture;
    [SerializeField]
    public RenderTexture canvasTexture;
    [SerializeField]
    public RenderTexture editTexture;
    [SerializeField]
    [Range(1.0f, 100.0f)]
    public float distanceBeforePaintHappens = 5.0f;

    private Vector2 previousPaintPosition;
    private Vector2 positionPrevious;
    private float distanceCurrent;

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
        editTexture = new RenderTexture(640, 480, 16, RenderTextureFormat.ARGB32, 0);

        texture.anisoLevel = 0;
        texture.filterMode = FilterMode.Point;
        canvasTexture.filterMode = FilterMode.Point;
        editTexture.filterMode = FilterMode.Point;

        // White
        Graphics.Blit(Texture2D.whiteTexture, editTexture);
        Graphics.CopyTexture(editTexture, canvasTexture);
        Graphics.CopyTexture(editTexture, texture);
    }

    public void ApplyEffect(Material effect)
    {
        Graphics.Blit(canvasTexture, editTexture, effect);
        Graphics.CopyTexture(editTexture, canvasTexture);
        Graphics.CopyTexture(editTexture, texture);
    }

    public void PaintStart(Vector2 position) {
        distanceCurrent = 0.0f;
        previousPaintPosition = position;
        positionPrevious = position;

        Paint(position);
    }

    public void PaintUpdate(Vector2 position)
    {
        distanceCurrent += Vector2.Distance(positionPrevious, position);
        positionPrevious = position;

        Vector2 step = position - previousPaintPosition;
        step = step.normalized * distanceBeforePaintHappens;

        while (distanceCurrent > distanceBeforePaintHappens)
        {
            distanceCurrent -= distanceBeforePaintHappens;
            previousPaintPosition += step;
            Paint(previousPaintPosition);
        }
    }

    public void Paint(Vector2 position)
    {
        var brushPickerContext = ContextManager.Instance.GetContext(ContextType.BrushPicker) as ContextBrushPicker;
        var contextColorPicker = ContextManager.Instance.GetContext(ContextType.ColorPicker) as ContextColorPicker;

        var brushTexture = brushPickerContext.selectedBrush.texture;
        var color = contextColorPicker.primaryColor.color;
        RenderTexture.active = canvasTexture;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, 640, 480, 0);

        Graphics.DrawTexture(new Rect(position.x - brushTexture.width / 2, position.y - brushTexture.height / 2, brushTexture.width, brushTexture.height), brushTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, color);

        GL.PopMatrix();
        RenderTexture.active = null;
    }
}