using System;
using $safeprojectname$.Utilities;

namespace $safeprojectname$.Models
{

    public class Costume
    {

        public Costume()
        {
			CostumeId = GuidComb.GenerateComb();
        }

        public Guid CostumeId { get; set; }
        public string Shortcut { get; set; }
        public string Name { get; set; }
		public string Detachment { get; set; }
		public string DetachmentUrl { get; set; }
		public string DetachmentLogoUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid ModifyUserId { get; set; }

    }

}
    