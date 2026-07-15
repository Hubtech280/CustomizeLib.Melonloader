using System;
using System.Collections;
using System.Collections.Generic;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(CreateBullet))]
public static class CreateBulletPatch
{
	[HarmonyPatch("SetBullet")]
	[HarmonyPrefix]
	public static void PreSetBullet(float x, float y, ref BulletType theBulletType, out ValueTuple<bool, BulletType, BulletType, PlantType> __state)
	{
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected I4, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected I4, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected I4, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		Il2CppReferenceArray<Collider2D> il2CppReferenceArray = Physics2D.OverlapCircleAll(new Vector2(x - 0.1f, y), 0.2f, LayerMask.GetMask("Plant"));
		System.Collections.Generic.IEnumerator<Collider2D> enumerator = il2CppReferenceArray.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Collider2D current = enumerator.Current;
				if (current == null || current.gameObject == null || current.IsDestroyed() || current.gameObject.IsDestroyed() || !current.TryGetComponent<Plant>(out var component) || (Object)(object)component == null || ((Object)(object)component).IsDestroyed() || !CustomCore.CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>(component.thePlantType, theBulletType)))
				{
					continue;
				}
				BulletType val = theBulletType;
				List<BulletType> val2 = CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(component.thePlantType, theBulletType)];
				theBulletType = (BulletType)(int)val2[Random.Range(0, val2.Count)];
				__state = new ValueTuple<bool, BulletType, BulletType, PlantType>(true, val, theBulletType, component.thePlantType);
				return;
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		Il2CppReferenceArray<Collider2D> il2CppReferenceArray2 = Physics2D.OverlapCircleAll(new Vector2(x - 0.1f, y), 0.2f, LayerMask.GetMask("Bullet"));
		System.Collections.Generic.IEnumerator<Collider2D> enumerator2 = il2CppReferenceArray2.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				Collider2D current2 = enumerator2.Current;
				if (!(current2 == null) && !(current2.gameObject == null) && !current2.IsDestroyed() && !current2.gameObject.IsDestroyed() && current2.TryGetComponent<Bullet>(out var component2) && !((Object)(object)component2 == null) && !((Object)(object)component2).IsDestroyed() && ((Component)(object)component2).GetData("SkinFromType") != null && ((Component)(object)component2).GetData("SkinData") != null)
				{
					PlantType data = ((Component)(object)component2).GetData<PlantType>("SkinFromType");
					if (CustomCore.CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>(data, theBulletType)))
					{
						BulletType val3 = theBulletType;
						List<BulletType> val4 = CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(data, theBulletType)];
						theBulletType = (BulletType)(int)val4[Random.Range(0, val4.Count)];
						__state = new ValueTuple<bool, BulletType, BulletType, PlantType>(true, val3, theBulletType, data);
						return;
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		List<PositionRecorder.RecordPosition> recordPositions = PositionRecorder.GetRecordPositions(new Vector2(x - 0.1f, y), 0.1f);
		var enumerator3 = recordPositions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				PositionRecorder.RecordPosition current3 = enumerator3.Current;
				if (CustomCore.CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>(current3.plantType, theBulletType)))
				{
					BulletType val5 = theBulletType;
					List<BulletType> val6 = CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(current3.plantType, theBulletType)];
					theBulletType = (BulletType)(int)val6[Random.Range(0, val6.Count)];
					__state = new ValueTuple<bool, BulletType, BulletType, PlantType>(true, val5, theBulletType, current3.plantType);
					PositionRecorder.RemovePosition(current3.index);
					return;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
		}
		__state = new ValueTuple<bool, BulletType, BulletType, PlantType>(false, (BulletType)(-1), (BulletType)(-1), (PlantType)(-1));
	}

	[HarmonyPatch("SetBullet")]
	[HarmonyPostfix]
	public static void PostSetBullet(ref Bullet __result, ValueTuple<bool, BulletType, BulletType, PlantType> __state)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (__state.Item1)
		{
			__result.theBulletType = __state.Item2;
			((Component)(object)__result).SetData("SkinData", __state.Item3);
			((Component)(object)__result).SetData("SkinFromType", __state.Item4);
		}
	}
}
