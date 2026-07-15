using UnityEngine;

namespace CustomizeLib.BepInEx;

public class CoreBehaviour : MonoBehaviour
{
	public static CoreBehaviour? Instance;

	public void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
		}
		Instance = this;
	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKeyDown(KeyCode.R))
		{
		}
	}
}
