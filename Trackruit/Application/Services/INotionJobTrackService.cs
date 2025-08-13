using Trackruit.Domain.JobsApplications;

namespace Trackruit.Application.Services;

public interface INotionJobTrackService
{
    Task InsertAsync(JobApplication jobApplication);
}