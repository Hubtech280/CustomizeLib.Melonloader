using UnityEngine;

namespace CustomizeLib.BepInEx;

public class UltimateWinterMelonSkin : MonoBehaviour
{
	public UltimateWinterMelon plant;

	public void ResetSummon()
	{
		plant.summoning = false;
	}
}
