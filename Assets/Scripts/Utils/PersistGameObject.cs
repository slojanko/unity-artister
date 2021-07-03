using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistGameObject : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
