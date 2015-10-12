namespace $safeprojectname$.Extensions
{

	public static class StringExtensions
	{

		public static string UmlToHtml(this string source)
		{
			return source
				.Replace("ä", "&auml;")
				.Replace("Ä", "&Auml;")
				.Replace("ö", "&ouml;")
				.Replace("Ö", "&Ouml;")
				.Replace("ü", "&uuml;")
				.Replace("Ü", "&Uuml;")
				.Replace("ß", "&szlig;");
		}

	}

}