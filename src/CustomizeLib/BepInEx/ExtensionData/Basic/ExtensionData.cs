using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CustomizeLib.BepInEx.ExtensionData.Basic;

public static class ExtensionData
{
	[field: CompilerGenerated]
	public static Dictionary<System.Type, Dictionary<string, object>> staticData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<System.Type, Dictionary<string, object>>();

	[field: CompilerGenerated]
	public static Dictionary<System.Type, Dictionary<object, Dictionary<string, object>>> instanceData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<System.Type, Dictionary<object, Dictionary<string, object>>>();

	public static object GetData(this Component component, string name)
	{
		if (component == null)
		{
			return null;
		}
		return component.gameObject.GetData(name);
	}

	public static T GetData<T>(this Component component, string name)
	{
		if (component == null)
		{
			return default(T);
		}
		try
		{
			if (component.gameObject.GetData(name) == null)
			{
				return default(T);
			}
			return (T)component.gameObject.GetData(name);
		}
		catch (System.Exception ex)
		{
			CustomCore.CLogger.LogInfo((object)("Error on convert type (at Get Extension Data), \nMessage   : " + ex.Message + "\nStackTrace: " + ex.StackTrace + "\n"));
			return default(T);
		}
	}

	public static void SetData(this Component component, string name, object data)
	{
		if (!(component == null))
		{
			component.gameObject.SetData(name, data);
		}
	}

	public static object GetData(this GameObject gameObject, string name)
	{
		if (gameObject == null)
		{
			return null;
		}
		if (gameObject.TryGetComponent<ExtensionDataComponent>(out var component))
		{
			return component.GetData(name);
		}
		gameObject.AddComponent<ExtensionDataComponent>();
		return null;
	}

	public static T GetData<T>(this GameObject gameObject, string name)
	{
		if (gameObject == null)
		{
			return default(T);
		}
		try
		{
			if (gameObject.GetData(name) == null)
			{
				return default(T);
			}
			return (T)gameObject.GetData(name);
		}
		catch (System.Exception ex)
		{
			CustomCore.CLogger.LogInfo((object)("Error on convert type (at Get Extension Data), \nMessage   : " + ex.Message + "\nStackTrace: " + ex.StackTrace + "\n"));
			return default(T);
		}
	}

	public static void SetData(this GameObject gameObject, string name, object data)
	{
		if (!(gameObject == null))
		{
			if (gameObject.TryGetComponent<ExtensionDataComponent>(out var component))
			{
				component.SetData(name, data);
				return;
			}
			ExtensionDataComponent extensionDataComponent = gameObject.AddComponent<ExtensionDataComponent>();
			extensionDataComponent.SetData(name, data);
		}
	}

	public static object GetData<T>(string name)
	{
		return GetData(typeof(T), name);
	}

	public static TData GetData<TClass, TData>(string name)
	{
		return GetData<TData>(typeof(TClass), name);
	}

	public static object GetData(System.Type type, string name)
	{
		if (staticData.ContainsKey(type))
		{
			if (staticData[type].ContainsKey(name))
			{
				return staticData[type][name];
			}
			return null;
		}
		return null;
	}

	public static TData GetData<TData>(System.Type type, string name)
	{
		if (staticData.ContainsKey(type))
		{
			if (staticData[type].ContainsKey(name))
			{
				return (TData)staticData[type][name];
			}
			return default(TData);
		}
		return default(TData);
	}

	public static void SetData<T>(string name, object data)
	{
		SetData(typeof(T), name, data);
	}

	public static void SetData(System.Type type, string name, object data)
	{
		if (staticData.ContainsKey(type))
		{
			if (staticData[type].ContainsKey(name))
			{
				staticData[type][name] = data;
			}
			else
			{
				staticData[type].Add(name, data);
			}
		}
		else
		{
			Dictionary<System.Type, Dictionary<string, object>> obj = staticData;
			Dictionary<string, object> obj2 = new Dictionary<string, object>();
			obj2.Add(name, data);
			obj.Add(type, obj2);
		}
	}

	public static object GetData(this object obj, string name)
	{
		if (obj == null)
		{
			return null;
		}
		if (instanceData.ContainsKey(obj.GetType()) && instanceData[obj.GetType()].ContainsKey(obj) && instanceData[obj.GetType()][obj].ContainsKey(name))
		{
			return instanceData[obj.GetType()][obj][name];
		}
		return null;
	}

	public static T GetData<T>(this object obj, string name)
	{
		if (obj == null)
		{
			return default(T);
		}
		if (instanceData.ContainsKey(obj.GetType()) && instanceData[obj.GetType()].ContainsKey(obj) && instanceData[obj.GetType()][obj].ContainsKey(name))
		{
			return (T)instanceData[obj.GetType()][obj][name];
		}
		return default(T);
	}

	public static void SetData(this object obj, string name, object data)
	{
		if (obj == null)
		{
			return;
		}
		if (instanceData.ContainsKey(obj.GetType()))
		{
			if (instanceData[obj.GetType()].ContainsKey(obj))
			{
				if (instanceData[obj.GetType()][obj].ContainsKey(name))
				{
					instanceData[obj.GetType()][obj][name] = data;
				}
				else
				{
					instanceData[obj.GetType()][obj].Add(name, data);
				}
			}
			else
			{
				Dictionary<object, Dictionary<string, object>> obj2 = instanceData[obj.GetType()];
				Dictionary<string, object> obj3 = new Dictionary<string, object>();
				obj3.Add(name, data);
				obj2.Add(obj, obj3);
			}
		}
		else
		{
			Dictionary<System.Type, Dictionary<object, Dictionary<string, object>>> obj4 = instanceData;
			System.Type type = obj.GetType();
			Dictionary<object, Dictionary<string, object>> obj5 = new Dictionary<object, Dictionary<string, object>>();
			Dictionary<string, object> obj6 = new Dictionary<string, object>();
			obj6.Add(name, data);
			obj5.Add(obj, obj6);
			obj4.Add(type, obj5);
		}
	}

	public static void WriteMethod<T>(this T comp, string name, Action<T> action) where T : Component
	{
		comp.SetData(name, action);
	}

	public static void InvokeMethod<T>(this T comp, string name) where T : Component
	{
		comp.GetData<Action<T>>(name).Invoke(comp);
	}

	public static void WriteMethod(this GameObject comp, string name, Action<GameObject> action)
	{
		comp.SetData(name, action);
	}

	public static void InvokeMethod(this GameObject comp, string name)
	{
		comp.GetData<Action<GameObject>>(name).Invoke(comp);
	}
}
