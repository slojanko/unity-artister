using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextManager : Manager<ContextManager>
{
    private Dictionary<ContextType, ContextBase> contexts = new Dictionary<ContextType, ContextBase>();

    public void LateUpdate()
    {
        foreach (var context in contexts)
        {
            context.Value.ResetDirty();
        }
    }

    public void RegisterContext(ContextType type, ContextBase context) {
        contexts.Add(type, context);
    }

    public void UnregisterContext(ContextType type)
    {
        contexts.Remove(type);
    }

    public ContextBase GetContext(ContextType type)
    {
        return contexts[type];
    }

    public void MarkContextDirty(ContextType type)
    {
        GetContext(type).MarkDirty();
    }

    public void ResetContextDirty(ContextType type)
    {
        GetContext(type).ResetDirty();
    }

    public bool IsContextDirty(ContextType type)
    {
        return GetContext(type).IsDirty();
    }
}
