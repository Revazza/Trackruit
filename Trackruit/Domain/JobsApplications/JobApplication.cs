using Trackruit.Domain.JobsApplications.Enums;

namespace Trackruit.Domain.JobsApplications;

public class JobApplication
{
    public Guid Id { get; set; }
    public JobDetails Details { get; set; }
    public int MatchPercentage { get; set; }
    public JobApplicationStatus Status { get; set; }
    public DateTime AppliedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public CompanyResponseStatus CompanyResponseStatus { get; set; }
    public string Hash { get; set; }
}