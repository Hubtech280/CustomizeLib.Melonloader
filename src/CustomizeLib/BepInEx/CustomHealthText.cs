using System;
using System.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public class CustomHealthText : MonoBehaviour
{
	public Dictionary<TextMeshProUGUI, Func<string>> registedTexts = new Dictionary<TextMeshProUGUI, Func<string>>();

	public void Update()
	{




		var enumerator = registedTexts.GetEnumerator();
		try
		{
			TextMeshProUGUI val = default(TextMeshProUGUI);
			Func<string> val2 = default(Func<string>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val, out val2);
				TextMeshProUGUI val3 = val;
				Func<string> val4 = val2;
				((TMP_Text)val3).text = val4.Invoke();
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
