using UnityEngine;

namespace CustomizeLib.BepInEx.ExtensionData.Unity;

public static class ExtensionDataUnity
{
	public static ExtDataRef<T> GetData<T>(this Object obj, string name)
	{
		if (obj is GameObject obj2)
		{
			return obj2.GetData<T>(name);
		}
		if (obj is Component obj3)
		{
			return obj3.GetData<T>(name);
		}
		return null;
	}

	public static ExtDataRef<T> GetData<T>(this GameObject obj, string name)
	{
		DataComponent orAddComponent = obj.GetOrAddComponent<DataComponent>();
		return new ExtDataRef<T>(obj, name);
	}

	public static ExtDataRef<T> GetData<T>(this Component obj, string name)
	{
		DataComponent orAddComponent = obj.gameObject.GetOrAddComponent<DataComponent>();
		return new ExtDataRef<T>(obj, name);
	}

	public static void SetData(this Object obj, string name, object value)
	{
		if (obj is GameObject obj2)
		{
			obj2.SetData(name, value);
		}
		if (obj is Component obj3)
		{
			obj3.SetData(name, value);
		}
	}

	public static void SetData(this GameObject obj, string name, object value)
	{
		DataComponent orAddComponent = obj.GetOrAddComponent<DataComponent>();
		orAddComponent.SetData(name, value);
	}

	public static void SetData(this Component obj, string name, object value)
	{
		DataComponent orAddComponent = obj.gameObject.GetOrAddComponent<DataComponent>();
		orAddComponent.SetData(name, value);
	}
}
