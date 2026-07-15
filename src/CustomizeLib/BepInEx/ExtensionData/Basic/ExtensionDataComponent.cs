using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CustomizeLib.BepInEx.ExtensionData.Basic;

public class ExtensionDataComponent : MonoBehaviour
{
	[field: CompilerGenerated]
	public Dictionary<string, object> data
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, object>();

	public object GetData(string name)
	{
		if (data.ContainsKey(name))
		{
			return data[name];
		}
		return null;
	}

	public void SetData(string name, object data)
	{
		if (this.data.ContainsKey(name))
		{
			this.data[name] = data;
		}
		else
		{
			this.data.Add(name, data);
		}
	}
}
