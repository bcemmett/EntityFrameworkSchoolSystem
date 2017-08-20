using System;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem5()
        {
            using (var db = new EFSchoolSystemContext())
            {
                db.Database.CommandTimeout = 300;
                string city = "New York";

                var pupils = db.Pupils
                    .Where(p => p.City == city)
                    .OrderBy(p => p.LastName)
                    .Select(x => new { x.FirstName, x.LastName })
                    .ToList();

                var sb = new StringBuilder();
                foreach (var pupil in pupils)
                {
                    sb.Append(pupil.FirstName);
                    sb.Append(" ");
                    sb.Append(pupil.LastName);
                    sb.Append(Environment.NewLine);
                }
                return sb.ToString();
            }
        }
    }
}