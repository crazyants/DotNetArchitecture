using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class PropertyInfoExtensions
{
	public static IDictionary ToDictionary(this IEnumerable<PropertyInfo> propertiesInfos)
	{
		return propertiesInfos?
			.Where(property => !string.IsNullOrWhiteSpace(property.GetValue(null) as string))
			.ToDictionary(property => property.Name.CamelCase(), property => (property.GetValue(null) as string));
	}
}
