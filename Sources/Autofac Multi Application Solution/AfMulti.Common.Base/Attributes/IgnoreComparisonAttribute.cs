using System;

namespace $safeprojectname$.Atttibutes
{

	/// <summary>
	/// Property-Attribut, that exclueds a property from comparison
	/// by an EqualityComparer.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class IgnoreComparisonAttribute : Attribute { }  

}