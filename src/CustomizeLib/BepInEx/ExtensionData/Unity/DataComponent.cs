using System.Collections.Generic;
using UnityEngine;

namespace CustomizeLib.BepInEx.ExtensionData.Unity;

public class DataComponent : MonoBehaviour
{
	public Dictionary<string, object> datas = new Dictionary<string, object>();

	public object? GetData(string name)
	{
		if (!datas.ContainsKey(name))
		{
			datas.Add(name, (object)null);
		}
		return datas[name];
	}

	public void SetData(string name, object value)
	{
		datas[name] = value;
	}
}
