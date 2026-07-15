using System;
using Il2CppSystem.Collections.Generic;

namespace CustomizeLib.BepInEx.Internal;

internal static class HookCall
{
	internal static bool load;

	internal static void SetBuffArr()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<AdvBuff, string> dictionary = new Dictionary<AdvBuff, string>();
		var enumerator = TravelDictionary.advancedBuffsText.GetEnumerator();
		while (enumerator.MoveNext())
		{
			var current = enumerator.Current;
			dictionary[current.Key] = current.Value;
		}
		var enumerator2 = CustomCore.CustomAdvancedBuffs.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				var current2 = enumerator2.Current;
				dictionary[(AdvBuff)current2.Key] = current2.Value.Item2;
			}
		}
		finally
		{
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.advancedBuffsText = dictionary;
		Dictionary<AdvBuff, PlantType> dictionary2 = new Dictionary<AdvBuff, PlantType>();
		var enumerator3 = TravelDictionary.AdvBuffPlantPairs.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			var current3 = enumerator3.Current;
			dictionary2[current3.Key] = current3.Value;
		}
		var enumerator4 = CustomCore.CustomAdvancedBuffs.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				var current4 = enumerator4.Current;
				dictionary2[(AdvBuff)current4.Key] = current4.Value.Item1;
			}
		}
		finally
		{
			((System.IDisposable)enumerator4/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.AdvBuffPlantPairs = dictionary2;
		Dictionary<UltiBuff, string> dictionary3 = new Dictionary<UltiBuff, string>();
		var enumerator5 = TravelDictionary.ultimateBuffsText.GetEnumerator();
		while (enumerator5.MoveNext())
		{
			var current5 = enumerator5.Current;
			dictionary3[current5.Key] = current5.Value;
		}
		var enumerator6 = CustomCore.CustomUltimateBuffs.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				var current6 = enumerator6.Current;
				dictionary3[(UltiBuff)current6.Key] = current6.Value.Item2;
			}
		}
		finally
		{
			((System.IDisposable)enumerator6/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.ultimateBuffsText = dictionary3;
		Dictionary<TravelUnlocks, string> dictionary4 = new Dictionary<TravelUnlocks, string>();
		var enumerator7 = TravelDictionary.unlocksText.GetEnumerator();
		while (enumerator7.MoveNext())
		{
			var current7 = enumerator7.Current;
			dictionary4[current7.Key] = current7.Value;
		}
		var enumerator8 = CustomCore.CustomUnlockBuffs.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				var current8 = enumerator8.Current;
				dictionary4[(TravelUnlocks)current8.Key] = current8.Value.Item2;
			}
		}
		finally
		{
			((System.IDisposable)enumerator8/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.unlocksText = dictionary4;
		Dictionary<PlantType, TravelUnlocks> dictionary5 = new Dictionary<PlantType, TravelUnlocks>();
		var enumerator9 = TravelDictionary.PlantToUnlock.GetEnumerator();
		while (enumerator9.MoveNext())
		{
			var current9 = enumerator9.Current;
			dictionary5[current9.Key] = current9.Value;
		}
		var enumerator10 = CustomCore.CustomUnlockBuffs.GetEnumerator();
		try
		{
			while (enumerator10.MoveNext())
			{
				var current10 = enumerator10.Current;
				dictionary5[current10.Value.Item1] = (TravelUnlocks)current10.Key;
			}
		}
		finally
		{
			((System.IDisposable)enumerator10/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.PlantToUnlock = dictionary5;
		Dictionary<TravelUnlocks, PlantType> dictionary6 = new Dictionary<TravelUnlocks, PlantType>();
		var enumerator11 = TravelDictionary.UnlockToPlant.GetEnumerator();
		while (enumerator11.MoveNext())
		{
			var current11 = enumerator11.Current;
			dictionary6[current11.Key] = current11.Value;
		}
		var enumerator12 = CustomCore.CustomUnlockBuffs.GetEnumerator();
		try
		{
			while (enumerator12.MoveNext())
			{
				var current12 = enumerator12.Current;
				dictionary6[(TravelUnlocks)current12.Key] = current12.Value.Item1;
			}
		}
		finally
		{
			((System.IDisposable)enumerator12/*cast due to constrained. prefix*/).Dispose();
		}
		TravelDictionary.UnlockToPlant = dictionary6;
	}

	internal static void RegisterTypes()
	{
	}
}
