using Microsoft.EntityFrameworkCore;
using System.Data;

namespace stepik.Services.EF;

public class CertificatesService : ICertificatesService
{
    /// <summary>
    /// Получение сертификатов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>DataSet</returns>
    public DataSet Get(string fullName)
    {
        using ApplicationDbContext dbContext = new();

        var certificates = dbContext.Certificates
            .AsNoTracking()
            .Include(c => c.Course)
            .Where(c => c.User.FullName == fullName)
            .OrderByDescending(c => c.IssueDate)
            .ToList();

        var dataSet = new DataSet();

        var dataTable = new DataTable("certificates");
        dataTable.Columns.Add("title", typeof(string));
        dataTable.Columns.Add("issue_date", typeof(DateTime));
        dataTable.Columns.Add("grade", typeof(int));

        foreach (var certificate in certificates)
        {
            dataTable.Rows.Add(certificate.Course.Title, certificate.IssueDate, certificate.Grade);
        }

        dataSet.Tables.Add(dataTable);
        return dataSet;
    }
}
