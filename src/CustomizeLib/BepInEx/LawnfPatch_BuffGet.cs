using System;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Lawnf))]
public static class LawnfPatch_BuffGet
{
	[HarmonyPatch("TravelAdvanced", new System.Type[] { typeof(AdvBuff) })]
	[HarmonyPrefix]
	public static void PreTravelAdvanced_1(ref AdvBuff buff)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomBuffIDMapping.ContainsKey(new ValueTuple<BuffType, int>((BuffType)1, (int)buff)))
		{
			buff = (AdvBuff)CustomCore.CustomBuffIDMapping[new ValueTuple<BuffType, int>((BuffType)1, (int)buff)];
		}
	}

	[HarmonyPatch("TravelUltimate", new System.Type[] { typeof(UltiBuff) })]
	[HarmonyPrefix]
	public static void PreTravelUltimate_1(ref UltiBuff buff)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomBuffIDMapping.ContainsKey(new ValueTuple<BuffType, int>((BuffType)2, (int)buff)))
		{
			buff = (UltiBuff)CustomCore.CustomBuffIDMapping[new ValueTuple<BuffType, int>((BuffType)2, (int)buff)];
		}
	}

	[HarmonyPatch("TravelDebuff", new System.Type[] { typeof(TravelDebuff) })]
	[HarmonyPrefix]
	public static void PreTravelDebuff_1(ref TravelDebuff buff)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomBuffIDMapping.ContainsKey(new ValueTuple<BuffType, int>((BuffType)3, (int)buff)))
		{
			buff = (TravelDebuff)CustomCore.CustomBuffIDMapping[new ValueTuple<BuffType, int>((BuffType)3, (int)buff)];
		}
	}
}
