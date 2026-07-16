using System;
using HarmonyLib;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(AlmanacPlantMenu))]
public static class AlmanacPlantMenuPatch
{
	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	public static void PostAwake(AlmanacPlantMenu __instance)
	{


		GameObject gameObject = ((Component)(object)__instance).transform.FindChild("Scroll View/Viewport/Content/LookRedCard").gameObject;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, ((Component)(object)__instance).transform.FindChild("Scroll View/Viewport/Content"));
		Action val = (Action)delegate
		{
			Func<PlantType, bool> val2 = (PlantType plantType) => !System.Enum.IsDefined<PlantType>(plantType);
			__instance.ShowPlants((Func<PlantType, bool>)val2);
		};
		UnityEvent unityEvent = new UnityEvent();
		unityEvent.AddListener(val);
		gameObject2.GetComponent<UIButton>().clickEvent = unityEvent;
		gameObject2.name = "LookCustom";
		((TMP_Text)gameObject2.transform.FindChild("TextShadow").gameObject.GetComponent<TextMeshProUGUI>()).text = "二创植物";
		gameObject2.transform.localPosition = new Vector3(0f, -44f * (float)gameObject2.transform.childCount + 72f, 0f);
		RectTransform component = ((Component)(object)__instance).transform.FindChild("Scroll View/Viewport/Content").GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y + 80f);
	}
}
