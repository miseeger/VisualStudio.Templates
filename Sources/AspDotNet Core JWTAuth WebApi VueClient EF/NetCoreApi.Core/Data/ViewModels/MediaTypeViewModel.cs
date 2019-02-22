using System.Collections.Generic;

namespace $safeprojectname$.Data.ViewModels
{
    public class MediaTypeViewModel
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public IList<TrackViewModel> Tracks { get; set; }
    }
}