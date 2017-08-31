using NPoco.FluentMappings;
using $safeprojectname$.Models;

namespace $safeprojectname$.Database.Mapping
{
    public class CostumeMapping : Map<Costume>
	{

		public CostumeMapping()
		{
			TableName("Costume");
			PrimaryKey(x => x.CostumeId);

			Columns(x =>
			{
				x.Column(y => y.CostumeId);
				x.Column(y => y.Shortcut);
				x.Column(y => y.Name);
				x.Column(y => y.Detachment);
				x.Column(y => y.DetachmentUrl);
				x.Column(y => y.DetachmentLogoUrl);
                x.Column(y => y.CreateDate);
                x.Column(y => y.CreateUserId);
                x.Column(y => y.ModifyDate);
                x.Column(y => y.ModifyUserId);
            });
		}

	}

}
