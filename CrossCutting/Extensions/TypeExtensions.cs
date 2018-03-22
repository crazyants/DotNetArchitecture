using System;
using System.Collections;

public static class TypeExtensions
{
	public static IDictionary ToDictionary(this Type type)
	{
		return type?.GetProperties().ToDictionary();
	}
}
