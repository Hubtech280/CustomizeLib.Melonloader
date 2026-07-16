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





		if (((Component)(object)option).GetData("CustomizeLib_BuffOptionType") != null && ((Component)(object)option).GetData("CustomizeLib_BuffOptionID") != null)
		{
			return new ValueTuple<BuffType, int>(((Component)(object)option).GetData<BuffType>("CustomizeLib_BuffOptionType"), ((Component)(object)option).GetData<int>("CustomizeLib_BuffOptionID"));
		}
		throw new InvalidOperationException("Option data is not exist");
	}

	public static void SetTypeAndID(this TravelBuffOptionButton option, BuffType type, int id)
	{

		((Component)(object)option).SetData("CustomizeLib_BuffOptionType", type);
		((Component)(object)option).SetData("CustomizeLib_BuffOptionID", id);
	}

	public static ValueTuple<BuffType, int> TryGetTypeAndID(this TravelStoreWindow option)
	{





		if (((Component)(object)option).GetData("CustomizeLib_BuffOptionType") != null && ((Component)(object)option).GetData("CustomizeLib_BuffOptionID") != null)
		{
			return new ValueTuple<BuffType, int>(((Component)(object)option).GetData<BuffType>("CustomizeLib_BuffOptionType"), ((Component)(object)option).GetData<int>("CustomizeLib_BuffOptionID"));
		}
		throw new InvalidOperationException("Option data is not exist");
	}

	public static void SetTypeAndID(this TravelStoreWindow option, BuffType type, int id)
	{

		((Component)(object)option).SetData("CustomizeLib_BuffOptionType", type);
		((Component)(object)option).SetData("CustomizeLib_BuffOptionID", id);
	}

	public static ValueTuple<BuffType, int> GetTypeAndID(Il2CppSystem.Object buff)
	{




















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








		ValueTuple<BuffType, int> typeAndID = GetTypeAndID(buff);
		option.SetTypeAndID(typeAndID.Item1, typeAndID.Item2);
		return typeAndID;
	}

	public static ValueTuple<BuffType, int> GeneralSet(this TravelStoreWindow window, Il2CppSystem.Object buff)
	{








		ValueTuple<BuffType, int> typeAndID = GetTypeAndID(buff);
		window.SetTypeAndID(typeAndID.Item1, typeAndID.Item2);
		return typeAndID;
	}

	public static System.Type GetBuffType(BuffType buffType)
	{






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
