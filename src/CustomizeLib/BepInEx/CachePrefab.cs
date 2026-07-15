using UnityEngine;

namespace CustomizeLib.BepInEx;

public class CachePrefab<T> where T : Object
{
	public T? value;

	public string path = "";

	public T GetValue()
	{
		if (value == null)
		{
			value = Resources.Load<T>(path);
		}
		return value;
	}

	public CachePrefab(string path)
	{
		this.path = path;
	}

	public static implicit operator T(CachePrefab<T> cache)
	{
		return cache.GetValue();
	}
}
