using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem2()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";

                List<School> schools = db.Schools.Where(s => s.City == city).ToList();
                var sb = new StringBuilder();
                foreach (var school in schools)
                {
                    sb.Append(school.Name);
                    sb.Append(": ");
                    sb.Append(school.Pupils.Count);
                    sb.Append(Environment.NewLine);
                }
                return sb.ToString();
            }
        }
    }
}