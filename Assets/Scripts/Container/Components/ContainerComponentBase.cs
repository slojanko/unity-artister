using System.Collections;
using UnityEngine;

public class ContainerComponentBase : MonoBehaviour
{
    protected Container container;

    public virtual void Awake()
    {
        container = GetComponentInParent<Container>();
    }
}