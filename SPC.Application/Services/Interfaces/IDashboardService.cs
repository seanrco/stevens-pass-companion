using SPC.Domain.Models.Dashboard;

namespace SPC.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummary> GetDashboardSummaryAsync(string wsdotId, 
            string latitude, 
            string longitude);
    }
}