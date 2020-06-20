using System.Collections.Generic;
using System.Threading.Tasks;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Interface
{
    public interface IDashboardService
    {
        Task<IEnumerable<TopTrackViewModel>> GetTop3TracksAsync();
        Task<StatisticsViewModel> GetStatisticsAsync();
    }
}