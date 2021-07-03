using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextBase : MonoBehaviour
{
    [SerializeField]
    public ContextType type = ContextType.None;
    [SerializeField]
    private bool isDirty = false;

    public virtual void Awake()
    {
        ContextManager.Instance.RegisterContext(type, this);
    }

    public void MarkDirty()
    {
        isDirty = true;
    }

    public void ResetDirty()
    {
        isDirty = false;
    }

    public bool IsDirty()
    {
        return isDirty;
    }
}
