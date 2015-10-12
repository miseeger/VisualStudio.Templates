using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace $safeprojectname$.Utils
{

	/// <summary>
	/// Provides functionality to compare properties of ogbjects which are 
	/// of the same type.
	/// </summary>
	/// <typeparam name="T">Type to be compared</typeparam>
	public class EqualityComparer<T> : IEqualityComparer<T>
	{
		
		private PropertyInfo[] _propertyInfos;


		/// <summary>
		/// Gathering compleate property information when creating the comparer.
		/// </summary>
		public EqualityComparer()
		{
			_propertyInfos = typeof(T).GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
		}
		

		/// <summary>
		/// Compares two objects of the same type by checking the equality of their property values.
		/// </summary>
		/// <param name="x">Object 1</param>
		/// <param name="y">Object 2</param>
		/// <returns></returns>
		public bool Equals(T x, T y)
		{
			var equality = true;
			
			foreach (var propertyInfo in _propertyInfos)
			{
				equality = propertyInfo.GetValue(x, null) == propertyInfo.GetValue(y, null);
				var type = propertyInfo.GetType();
				if (type == typeof(DateTime))
				{
					
				}
				if (!equality)
				{
					break;
				}
			}
			
			return equality;
		}


		/// <summary>
		/// Gets a simple hashcode for an object
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int GetHashCode(T obj)
		{
			return _propertyInfos.Aggregate(0, (current, propertyInfo) => current ^ propertyInfo.GetValue(obj, null).GetHashCode());
		}
	}

}