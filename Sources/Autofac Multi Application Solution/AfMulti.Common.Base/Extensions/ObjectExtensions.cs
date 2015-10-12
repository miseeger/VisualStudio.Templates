using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace $safeprojectname$.Extensions
{
	
	public static class ObjectExtensions
	{

		public static T Clone<T>(this object item)
		{
			if (item != null)
			{
				var formatter = new BinaryFormatter();
				var stream = new MemoryStream();

				formatter.Serialize(stream, item);
				stream.Seek(0, SeekOrigin.Begin);

				var result = (T)formatter.Deserialize(stream);

				stream.Close();

				return result;
			}
			else
				return default(T);
		}

	}

}