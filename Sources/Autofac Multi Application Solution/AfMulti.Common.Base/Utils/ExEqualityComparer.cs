using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using $safeprojectname$.Atttibutes;

namespace $safeprojectname$.Utils
{
	
	/// <summary>
	/// Compared objects of the same type.
	/// </summary>
	/// <typeparam name="T">object type</typeparam>
	public class ExEqualityComparer<T> : IEqualityComparer<T>
	{

		private List<PropertyInfo> _propertyInfos;


		/// <summary>
		///  Reading all property information from the given object type
		///  expect those having the attribute "IgnoreComparison".
		/// </summary>
		public ExEqualityComparer()
		{
			_propertyInfos =
					typeof (T).GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public)
						.Where(x => !x.GetCustomAttributes(typeof (IgnoreComparisonAttribute)).Any()).ToList();
		}


		/// <summary>
		/// Compares values of a property from two objects of the same type. Nullables und date values
		/// will be specially handled. A ByRef-string, that holds the detected differences will by
		/// exteded occasionally.
		/// </summary>
		/// <param name="propInfo">PropertyInfos from the properties to be compared</param>
		/// <param name="x">Objekt 1</param>
		/// <param name="y">Objekt 2</param>
		/// <param name="diffMessage">string containing the running differences (ref).</param>
		/// <returns></returns>
		public bool PropertyEquals(PropertyInfo propInfo, T x, T y, ref string diffMessage)
		{
			var diffTemplate = "{0} - Soll: {1} / Ist: {2}";

			var type = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

			var valueX = propInfo.GetValue(x, null) == null
				? type.GetConstructor(Type.EmptyTypes) != null 
					? Activator.CreateInstance(type) 
					: null
				: Convert.ChangeType(propInfo.GetValue(x, null), type);

			var valueY = propInfo.GetValue(y, null) == null
				? type.GetConstructor(Type.EmptyTypes) != null
					? Activator.CreateInstance(type)
					: null
				: Convert.ChangeType(propInfo.GetValue(y, null), type);

			if (valueX == null && valueY == null)
				return true;

			if ((valueX == null && valueY != null) || (valueX != null && valueY == null))
			{
				diffMessage = String.Format(diffTemplate, propInfo.Name, valueX ?? "null", valueY ?? "null");
				return false;
			}

			var equality = true;

			if (propInfo.PropertyType == typeof(DateTime))
			{
				equality = DateTime.Compare((DateTime)valueX, (DateTime)valueY) == 0;
			}
			else
			{
				if (propInfo.PropertyType == typeof (DateTime?))
				{
					DateTime valueXdt = ((DateTime?) valueX).HasValue ? ((DateTime?) valueX).Value : new DateTime();
					DateTime valueYdt = ((DateTime?) valueX).HasValue ? ((DateTime?) valueX).Value : new DateTime();

					equality = DateTime.Compare(valueXdt, valueYdt) == 0;
				}
				else
				{
					equality = valueX.ToString() == valueY.ToString();
				}
			}

			if (!equality)
			{
				diffMessage = String.Format(diffTemplate, propInfo.Name, valueX, valueY);
			}

			return equality;
		}


		/// <summary>
		/// Compares property values.
		/// </summary>
		/// <param name="x">Object 1</param>
		/// <param name="y">Object 2</param>
		/// <returns>True, if comparison was successful</returns>
		public bool Equals(T x, T y)
		{
			foreach (var propertyInfo in _propertyInfos)
			{
				var diffMsg = String.Empty;
				var equality = PropertyEquals(propertyInfo, x, y, ref diffMsg);

				if (!equality)
					return false;
			}

			return true;
		}


		/// <summary>
		/// Compares values of a property from two objects of the same type. Extends
		/// the diffMessage occasionally and provides a string via getKeyValue function 
		/// that makes it possible to identify the object from the diffMessage.
		/// </summary>
		/// <param name="x">Object 1</param>
		/// <param name="y">Object 2</param>
		/// <param name="getKeyValue">Lambda function creating an ID for both objects.</param>
		/// <param name="diffMessage">Running differences.</param>
		/// <returns></returns>
		public bool Equals(T x, T y, Func<string> getKeyValue, ref string diffMessage)
		{
			var equals = true;
			var key = getKeyValue.Invoke();
			var sb = new StringBuilder(String.Format("Comparing {0} ({1}):", typeof(T).ToString(), key));

			foreach (var propertyInfo in _propertyInfos)
			{
				var diffMsg = String.Empty;
				var equality = PropertyEquals(propertyInfo, x, y, ref diffMsg);

				if (!equality)
				{
					sb.AppendFormat("\r\n{0}", diffMsg);
				}

				equals = equals && equality;
			}

			diffMessage = equals ? String.Empty : sb.ToString();
			return equals;
		}


		/// <summary>
		/// Gets a simple hashcode for an object.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int GetHashCode(T obj)
		{
			return
				_propertyInfos.Aggregate(0, (current, propertyInfo) => current ^ propertyInfo.GetValue(obj, null).GetHashCode());
		}
	}
}