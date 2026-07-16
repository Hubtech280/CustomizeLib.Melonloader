using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomizeLib.BepInEx;

public class StringFormatter
{
	public static readonly HashSet<char> NumberCharset;

	public static string Format(string input)
	{


		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		string[] array = input.Split(new string[3] { "\r\n", "\r", "\n" }, (StringSplitOptions)0);
		StringBuilder val = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			bool flag = i == array.Length - 1;
			if (i == 0)
			{
				val.Append(text);
			}
			else if (flag)
			{
				val.Append(ProcessLastLine(text));
			}
			else
			{
				val.Append(ProcessNormalLine(text));
			}
			if (i != array.Length - 1)
			{
				val.Append(Environment.NewLine);
			}
		}
		return ((object)val).ToString();
	}

	private static string ProcessNormalLine(string line)
	{
		if (string.IsNullOrEmpty(line))
		{
			return line;
		}
		int num = FindFirstSerialNumber(line);
		if (num != -1)
		{
			return $"<color=#3D1400>{line.Substring(0, num + 1)}</color><color=red>{line.Substring(num + 1)}</color>";
		}
		int num2 = FindFirstColon(line);
		if (num2 != -1)
		{
			return $"<color=#3D1400>{line.Substring(0, num2 + 1)}</color><color=red>{line.Substring(num2 + 1)}</color>";
		}
		return line;
	}

	private static string ProcessLastLine(string line)
	{
		if (string.IsNullOrEmpty(line))
		{
			return line;
		}
		return "<color=#3D1400>" + line + "</color>";
	}

	private static int FindFirstSerialNumber(string line)
	{
		for (int i = 0; i < line.Length; i++)
		{
			if (NumberCharset.Contains(line[i]))
			{
				return i;
			}
		}
		return -1;
	}

	private static int FindFirstColon(string line)
	{
		for (int i = 0; i < line.Length; i++)
		{
			switch (line[i])
			{
			case '：':
				return i;
			case ':':
			{
				string text = line.Substring(0, i);
				if (Regex.IsMatch(text, "词条\\d+$"))
				{
					return i;
				}
				break;
			}
			}
		}
		return -1;
	}

	private static bool IsSpecialEnglishColon(string line, int colonIndex)
	{
		if (colonIndex <= 0)
		{
			return false;
		}
		string text = line.Substring(0, colonIndex);
		return Regex.IsMatch(text, "词条\\d+$");
	}

	static StringFormatter()
	{
		HashSet<char> obj = new HashSet<char>();
		obj.Add('①');
		obj.Add('②');
		obj.Add('③');
		obj.Add('④');
		obj.Add('⑤');
		obj.Add('⑥');
		obj.Add('⑦');
		obj.Add('⑧');
		obj.Add('⑨');
		obj.Add('⑩');
		NumberCharset = obj;
	}
}
