namespace Trackruit.Domain.JobsApplications;

public class ProblematicJobApplication : JobApplication
{
    public string FailureReason { get; set; }
    public int Retries { get; set; }
    public DateTime LastRetriedAt { get; set; }
}