using System;
using Il2CppSystem.Collections.Generic;

namespace CustomizeLib.BepInEx.Internal;

internal static class HookCall
{
	internal static bool load;

	internal static void SetBuffArr()
	{










































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
			((System.IDisposable)enumerator2).Dispose();
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
			((System.IDisposable)enumerator4).Dispose();
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
			((System.IDisposable)enumerator6).Dispose();
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
			((System.IDisposable)enumerator8).Dispose();
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
			((System.IDisposable)enumerator10).Dispose();
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
			((System.IDisposable)enumerator12).Dispose();
		}
		TravelDictionary.UnlockToPlant = dictionary6;
	}

	internal static void RegisterTypes()
	{
	}
}
