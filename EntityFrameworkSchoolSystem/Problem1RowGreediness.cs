using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public string DoProblem1()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";

                List<School> schools = db.Schools.ToList();
                List<School> newYorkSchools = schools.Where(s => s.City == city).ToList();

                foreach (var school in newYorkSchools)
                {
                    WriteOutput(school.Name);
                }

                return _outputBuffer.ToString();
            }
        }
    }
}