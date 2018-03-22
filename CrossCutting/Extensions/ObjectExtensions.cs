using System;
using System.IO;
using System.Xml.Serialization;

namespace Solution.CrossCutting.Extensions
{
	public static class ObjectExtensions
	{
		public static void ThrowIfArgumentIsNull<T>(this T obj, string paramName) where T : class
		{
			if (obj == null) throw new ArgumentNullException(paramName);
		}

		public static T XmlDeserialize<T>(this string xml) where T : class, new()
		{
			if (xml == null) throw new ArgumentNullException(nameof(xml));
			var serializer = new XmlSerializer(typeof(T));

			using (var reader = new StringReader(xml))
			{
				try { return (T)serializer.Deserialize(reader); } catch { return null; }
			}
		}

		public static string XmlSerialize<T>(this T obj) where T : class, new()
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			var serializer = new XmlSerializer(typeof(T));

			using (var writer = new StringWriter())
			{
				serializer.Serialize(writer, obj);
				return writer.ToString();
			}
		}
	}
}
