using System.Data;

public class CertificatesServiceTests
{
    private readonly CertificatesService _certificatesService = new();

    [Fact]
    public void Get_ShouldReturnDataSet_WhenFullNameExists()
    {
        // Arrange
        var expectedCertificates = new List<Certificate>
        {
            new Certificate { Title = "PHP для начинающих", IssueDate = new DateTime(2021, 1, 19), Grade = 70 },
            new Certificate { Title = "Введение в HTML и CSS", IssueDate = new DateTime(2021, 1, 12), Grade = 85 },
            new Certificate { Title = "JavaScript для начинающих", IssueDate = new DateTime(2021, 1, 5), Grade = 95 }
        };

        // Act
        var resultDataSet = _certificatesService.Get("Петр Васильев");
        var resultCertificates = resultDataSet.ToCertificates();

        // Assert
        for (int i = 0; i < expectedCertificates.Count; i++)
        {
            Assert.Equal(expectedCertificates[i].Title, resultCertificates[i].Title);
            Assert.Equal(expectedCertificates[i].IssueDate, resultCertificates[i].IssueDate);
            Assert.Equal(expectedCertificates[i].Grade, resultCertificates[i].Grade);
        }
    }

    [Fact]
    public void Get_ShouldReturnEmptyDataSet_WhenFullNameDoesNotExist()
    {
        // Arrange
        var expectedCertificates = new List<Certificate>();

        // Act
        var resultDataSet = _certificatesService.Get("Несуществующий Пользователь");
        var resultCertificates = resultDataSet.ToCertificates();

        // Assert
        Assert.Equal(expectedCertificates.Count, resultCertificates.Count);
    }
}

public static class DataSetExtensions
{
    public static List<Certificate> ToCertificates(this DataSet dataSet)
    {
        var certificates = new List<Certificate>();

        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var certificate = new Certificate
                {
                    Title = row["title"].ToString(),
                    IssueDate = (DateTime)row["issue_date"],
                    Grade = (int)row["grade"]
                };
                certificates.Add(certificate);
            }
        }

        return certificates;
    }
}