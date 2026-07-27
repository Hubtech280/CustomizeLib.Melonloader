using UnityEngine;

namespace CustomizeLib.MelonLoader;

public class EmptyDoom : MonoBehaviour
{
	public void Die()
	{
		Object.Destroy(base.gameObject);
	}
}
