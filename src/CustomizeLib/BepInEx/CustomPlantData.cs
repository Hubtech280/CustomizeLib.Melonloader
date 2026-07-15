using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public struct CustomPlantData
{
	[field: CompilerGenerated]
	public int ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public PlantData PlantData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public GameObject Prefab
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public GameObject Preview
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public List<ValueTuple<BulletType, List<GameObject?>>>? BulletList
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
