internal static class _003CPrivateImplementationDetails_003E
{
	internal static uint ComputeStringHash(string text)
	{
		uint hash = 2166136261u;
		if (text != null)
		{
			foreach (char character in text)
			{
				hash = (character ^ hash) * 16777619u;
			}
		}
		return hash;
	}
}
