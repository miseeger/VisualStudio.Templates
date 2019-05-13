using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class MediaTypeConverter
    {
        public static MediaTypeViewModel Convert(MediaType mediaType)
        {
            var mediaTypeViewModel = new MediaTypeViewModel
            {
                MediaTypeId = mediaType.MediaTypeId,
                Name = mediaType.Name
            };
            return mediaTypeViewModel;
        }

        public static List<MediaTypeViewModel> ConvertList(IEnumerable<MediaType> mediaTypes)
        {
            return mediaTypes.Select(m =>
                {
                    var model = new MediaTypeViewModel
                    {
                        MediaTypeId = m.MediaTypeId,
                        Name = m.Name
                    };
                    return model;
                })
                .ToList();
        }
    }
}