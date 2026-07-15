using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CustomizeLib.BepInEx;

public class JsonSkinObject
{
	[field: CompilerGenerated]
	public Dictionary<int, int> CustomBulletType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, int>();

	[field: CompilerGenerated]
	public CustomPlantData CustomPlantData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public CustomPlantAlmanac PlantAlmanac
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public CustomTypeMgrExtraSkin TypeMgrExtraSkin
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
