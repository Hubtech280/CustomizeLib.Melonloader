using System;
using System.Collections;
using System.Collections.Generic;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.Utils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace CustomizeLib.BepInEx;

public static class Extensions
{
	public static void SetLayer(this Transform transform, string layerName)
	{
		if (!(transform == null))
		{
			if (transform.TryGetComponent<SortingGroup>(out var component))
			{
				component.sortingLayerName = layerName;
			}
			if (transform.TryGetComponent<SpriteRenderer>(out var component2))
			{
				component2.sortingLayerName = layerName;
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).SetLayer(layerName);
			}
		}
	}

	public static T? GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		if (gameObject != null && gameObject.TryGetComponent<T>(out var component) && component != null)
		{
			return component;
		}
		if (gameObject != null)
		{
			return gameObject.AddComponent<T>();
		}
		return null;
	}

	public static T? GetOrAddComponent<T>(this Transform gameObject) where T : Component
	{
		if (gameObject != null && gameObject.TryGetComponent<T>(out var component) && component != null)
		{
			return component;
		}
		if (gameObject != null)
		{
			return gameObject.AddComponent<T>();
		}
		return null;
	}

	public static T? GetOrAddComponent<T>(this Component gameObject) where T : Component
	{
		if (gameObject != null && gameObject.TryGetComponent<T>(out var component) && component != null)
		{
			return component;
		}
		if (gameObject != null)
		{
			return gameObject.AddComponent<T>();
		}
		return null;
	}

	public static Coroutine StartCoroutine(this MonoBehaviour self, System.Collections.IEnumerator routine)
	{
		return MonoBehaviourExtensions.StartCoroutine(self, routine);
	}

	public static bool TryGetAsset<T>(this AssetBundle ab, string name, out T obj) where T : UnityEngine.Object
	{
		System.Collections.Generic.IEnumerator<UnityEngine.Object> enumerator = ab.LoadAllAssetsAsync().allAssets.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				UnityEngine.Object current = enumerator.Current;
				if (current.TryCast<T>()?.name == name)
				{
					obj = current.Cast<T>();
					return true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		obj = null;
		return false;
	}

	public static T GetAsset<T>(this AssetBundle ab, string name) where T : UnityEngine.Object
	{

		System.Collections.Generic.IEnumerator<UnityEngine.Object> enumerator = ab.LoadAllAssetsAsync().allAssets.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				UnityEngine.Object current = enumerator.Current;
				if (current.TryCast<T>()?.name == name)
				{
					return current.Cast<T>();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		throw new ArgumentException("Could not find " + name + " from " + ab.name);
	}

	public static Sprite ToSprite(this Texture2D texture2D)
	{
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
	}

	public static List<string> GetAssetBundleAssetNames(this AssetBundle assetBundle)
	{
		if (assetBundle == null)
		{
			((BasePlugin)CustomCore.Instance.Value).Log.LogError((object)"Failed to get AssetBundle!");
			return new List<string>();
		}
		List<string> val = new List<string>();
		System.Collections.Generic.IEnumerator<Object> enumerator = assetBundle.LoadAllAssets().GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Object current = enumerator.Current;
				val.Add(current.name);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return val;
	}

	public static void AddLayer(this Transform transform, int level)
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			if (transform.GetChild(i).IsObjExist() && transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
			{
				transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder += level;
				transform.GetChild(i).AddLayer(level);
			}
		}
	}
}
