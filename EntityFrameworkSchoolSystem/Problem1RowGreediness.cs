using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem1()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";

                List<School> schools = db.Schools.ToList();
                List<School> newYorkSchools = schools.Where(s => s.City == city).ToList();



                ////////////////////
                //Format results for display
                ////////////////////
                var sb = new StringBuilder();
                foreach (var school in newYorkSchools)
                {
                    sb.Append(school.Name);
                    sb.Append(Environment.NewLine);
                }
                return sb.ToString();
            }
        }
    }
}