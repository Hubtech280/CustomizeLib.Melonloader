using System;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class TravelExtensions
{
	public const string BUFF_TYPEDATA = "CustomizeLib_BuffOptionType";

	public const string BUFF_IDDATA = "CustomizeLib_BuffOptionID";

	public static ValueTuple<BuffType, int> TryGetTypeAndID(this TravelBuffOptionButton option)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)(object)option).GetData("CustomizeLib_BuffOptionType") != null && ((Component)(object)option).GetData("CustomizeLib_BuffOptionID") != null)
		{
			return new ValueTuple<BuffType, int>(((Component)(object)option).GetData<BuffType>("CustomizeLib_BuffOptionType"), ((Component)(object)option).GetData<int>("CustomizeLib_BuffOptionID"));
		}
		throw new InvalidOperationException("Option data is not exist");
	}

	public static void SetTypeAndID(this TravelBuffOptionButton option, BuffType type, int id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Component)(object)option).SetData("CustomizeLib_BuffOptionType", type);
		((Component)(object)option).SetData("CustomizeLib_BuffOptionID", id);
	}

	public static ValueTuple<BuffType, int> TryGetTypeAndID(this TravelStoreWindow option)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)(object)option).GetData("CustomizeLib_BuffOptionType") != null && ((Component)(object)option).GetData("CustomizeLib_BuffOptionID") != null)
		{
			return new ValueTuple<BuffType, int>(((Component)(object)option).GetData<BuffType>("CustomizeLib_BuffOptionType"), ((Component)(object)option).GetData<int>("CustomizeLib_BuffOptionID"));
		}
		throw new InvalidOperationException("Option data is not exist");
	}

	public static void SetTypeAndID(this TravelStoreWindow option, BuffType type, int id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Component)(object)option).SetData("CustomizeLib_BuffOptionType", type);
		((Component)(object)option).SetData("CustomizeLib_BuffOptionID", id);
	}

	public static ValueTuple<BuffType, int> GetTypeAndID(Il2CppSystem.Object buff)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected I4, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected I4, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected I4, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected I4, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected I4, but got Unknown
		BuffType val = (BuffType)(-1);
		int num = -1;
		if (buff.IsTypeOf<AdvBuff>())
		{
			val = (BuffType)1;
			num = (int)((Il2CppObjectBase)buff).Unbox<AdvBuff>();
		}
		else if (buff.IsTypeOf<UltiBuff>())
		{
			val = (BuffType)2;
			num = (int)((Il2CppObjectBase)buff).Unbox<UltiBuff>();
		}
		else if (buff.IsTypeOf<TravelDebuff>())
		{
			val = (BuffType)3;
			num = (int)((Il2CppObjectBase)buff).Unbox<TravelDebuff>();
		}
		else if (buff.IsTypeOf<InvestBuff>())
		{
			val = (BuffType)4;
			num = (int)((Il2CppObjectBase)buff).Unbox<InvestBuff>();
		}
		else if (buff.IsTypeOf<TravelUnlocks>())
		{
			val = (BuffType)0;
			num = (int)((Il2CppObjectBase)buff).Unbox<TravelUnlocks>();
		}
		return new ValueTuple<BuffType, int>(val, num);
	}

	public static ValueTuple<BuffType, int> GeneralSet(this TravelBuffOptionButton option, Il2CppSystem.Object buff)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<BuffType, int> typeAndID = GetTypeAndID(buff);
		option.SetTypeAndID(typeAndID.Item1, typeAndID.Item2);
		return typeAndID;
	}

	public static ValueTuple<BuffType, int> GeneralSet(this TravelStoreWindow window, Il2CppSystem.Object buff)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<BuffType, int> typeAndID = GetTypeAndID(buff);
		window.SetTypeAndID(typeAndID.Item1, typeAndID.Item2);
		return typeAndID;
	}

	public static System.Type GetBuffType(BuffType buffType)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected I4, but got Unknown
		return (int)buffType switch
		{
			1 => typeof(AdvBuff), 
			2 => typeof(UltiBuff), 
			3 => typeof(TravelDebuff), 
			4 => typeof(InvestBuff), 
			0 => typeof(TravelUnlocks), 
			_ => null, 
		};
	}

	public static GameObject SetSaveMaterial(this GameObject gameObject)
	{
		gameObject.AddComponent<SaveMaterial>();
		return gameObject;
	}
}
