namespace Trackruit.Domain.JobsApplications;

public record JobDetails
{
    public string Title { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public string Url { get; set; }
}