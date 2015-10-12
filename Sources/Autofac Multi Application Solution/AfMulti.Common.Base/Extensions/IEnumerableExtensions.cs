﻿using System;
using System.Collections.Generic;

namespace $safeprojectname$.Extensions
{

	public static class IEnumerableExtensions
	{
		
		public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value) {
			foreach ( var cur in e) 
			{
				yield return cur;
			}
			yield return value;
		}
	
	}
	
}