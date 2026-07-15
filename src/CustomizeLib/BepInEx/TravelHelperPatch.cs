using System;
using System.Collections.Generic;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelHelper))]
public static class TravelHelperPatch
{
	[HarmonyPatch("GetAllUltimatePlantTypes")]
	[HarmonyPostfix]
	public static void PostGetAllUltimatePlantTypes(ref Il2CppSystem.Collections.Generic.List<PlantType> __result, ref bool isStrongUltimate)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (isStrongUltimate)
		{
			var enumerator = CustomCore.CustomStrongUltimatePlants.GetEnumerator();
			try
			{
				PlantType val = default(PlantType);
				int num = default(int);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out val, out num);
					PlantType item = val;
					__result.Add(item);
				}
				return;
			}
			finally
			{
				((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
			}
		}
		var enumerator2 = CustomCore.CustomUltimatePlants.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				PlantType current = enumerator2.Current;
				if (!CustomCore.CustomStrongUltimatePlants.ContainsKey(current))
				{
					__result.Add(current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
