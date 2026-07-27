using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CustomizeLib.MelonLoader;

public struct SkinConfig
{
	[field: CompilerGenerated]
	public bool SaveMaterial
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;

	public SkinConfig()
	{
	}
}
