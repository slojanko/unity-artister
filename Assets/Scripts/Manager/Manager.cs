using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : Component
{
	public static T Instance
	{
		get
		{
			if (cachedInstance == null)
			{
				FindInstance();
			}

			return cachedInstance;
		}
	}

	private static T cachedInstance = null;

	private static void FindInstance()
    {
		cachedInstance = FindObjectOfType<T>();
		if (cachedInstance == null) { 
			Debug.LogError(typeof(T).Name + " instance is missing!");
		}
	}

	protected virtual void Awake()
	{
		if (cachedInstance == null)
		{
			FindInstance();
		} else if (cachedInstance != this) 
		{
			Debug.LogError(typeof(T).Name + " duplicate instance!");
			Destroy(gameObject);
		}
	}
}