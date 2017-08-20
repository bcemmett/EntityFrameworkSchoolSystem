using System;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem7()
        {
            using (var db = new EFSchoolSystemContext())
            {
                var model = new ResultsModel();
                var rnd = new Random();
                model.Page = rnd.Next(1, 1000);
                model.ResultsPerPage = rnd.Next(10, 100);
                var schools = db.Schools
                    .OrderBy(s => s.PostalZipCode)
                    .Skip(model.Page * model.ResultsPerPage)
                    .Take(model.ResultsPerPage)
                    .ToList();

                var sb = new StringBuilder();
                foreach (var school in schools)
                {
                    sb.Append(school.Name);
                    sb.Append(Environment.NewLine);
                }
                return sb.ToString();
            }
        }
    }
}