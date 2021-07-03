using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Container : MonoBehaviour
{
    [SerializeField]
    private Text title;

    public void Focus()
    {
        GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void Resize(Vector2 delta)
    {
        GetComponent<RectTransform>().sizeDelta += delta * new Vector2(1.0f, -1.0f);
    }

    public void Drag(Vector2 delta)
    {
        GetComponent<RectTransform>().anchoredPosition += delta;
    }

    public void SetTitle(string text)
    {
        title.text = text;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void ClampToCanvas()
    {
    }
}
