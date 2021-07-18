using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBase : MonoBehaviour
{
    [SerializeField]
    private List<ContextType> contextDependency = new List<ContextType>();
    [SerializeField]
    private string title;

    public virtual void Awake()
    {
        UpdateValues();
    }

    public virtual void Update()
    {
        if (IsAnyContextDirty())
        {
            UpdateValues();
        }
    }

    protected virtual void UpdateValues()
    {
    }

    protected bool IsAnyContextDirty()
    {
        foreach(var context in contextDependency)
        {
            if (ContextManager.Instance.IsContextDirty(context))
            {
                return true;
            }
        }

        return false;
    }
}
