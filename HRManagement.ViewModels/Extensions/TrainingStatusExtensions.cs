using HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels.Extensions
{
    public static class TrainingStatusExtensions
    {
        public static string GetDescription(this TrainingStatus status)
        {
            switch (status)
            {
                case TrainingStatus.Deferred: return "Deferred";
                case TrainingStatus.Finished: return "Finished";
                case TrainingStatus.InProgress: return "In Progress";
                case TrainingStatus.Planned: return "Planned";
                case TrainingStatus.Started: return "Started";
            }

            return "N/A";
        }
    }
}
