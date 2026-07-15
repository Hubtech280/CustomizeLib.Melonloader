using Il2CppInterop.Runtime.Injection;

namespace CustomizeLib.BepInEx;

public static class SkinBehaviourMgr
{
	public static void Init()
	{
		ClassInjector.RegisterTypeInIl2Cpp<UltimateWinterMelonSkin>();
	}
}
