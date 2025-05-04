using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("certificate_settings")]
public class CertificateSetting
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("logo_url")]
    public string? LogoUrl { get; set; }

    [Column("signature_url")]
    public string? SignatureUrl { get; set; }

    [Column("is_certificate_auto_issued")]
    public bool IsCertificateAutoIssued { get; set; }

    [Column("regular_threshold")]
    public int RegularThreshold { get; set; }

    [Column("excellent_threshold")]
    public int ExcellentThreshold { get; set; }

    public Course Course { get; set; }
}