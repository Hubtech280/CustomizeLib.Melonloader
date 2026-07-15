using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx.ExtensionData.Unity;

public class ExtDataRef<T>
{
	public string name = "";

	public Object? parent = null;

	public T? val
	{
		get
		{
			return (T)((parent.GetOrAddComponent<DataComponent>().GetData(name) == null) ? ((object)default(T)) : parent.GetOrAddComponent<DataComponent>().GetData(name));
		}
		set
		{
			parent.GetOrAddComponent<DataComponent>().SetData(name, value);
		}
	}

	public ExtDataRef(Object parent, string name)
	{
		this.parent = parent;
		this.name = name;
	}

	public static implicit operator T(ExtDataRef<T> extDataRef)
	{
		return extDataRef.val;
	}
}
