using UnityEngine;

namespace CustomizeLib.BepInEx;

public class EmptyDoom : MonoBehaviour
{
	public void Die()
	{
		Object.Destroy(base.gameObject);
	}
}
