using UnityEngine;

namespace CustomizeLib.MelonLoader;

public class UltimateWinterMelonSkin : MonoBehaviour
{
	public UltimateWinterMelon plant;

	public void ResetSummon()
	{
		plant.summoning = false;
	}
}
