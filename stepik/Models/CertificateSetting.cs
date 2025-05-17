public class CertificateSetting
{
    public int CourseId { get; set; }
    public string LogoUrl { get; set; }
    public string SignatureUrl { get; set; }
    public bool IsCertificateAutoIssued { get; set; }
    public int RegularThreshold { get; set; }
    public int ExcellentThreshold { get; set; }

    public Course Course { get; set; }
}
