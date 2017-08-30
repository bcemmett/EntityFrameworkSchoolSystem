using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public string DoProblem2()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";
                List<School> schools = db.Schools.Where(s => s.City == city).ToList();
                
                foreach (var school in schools)
                {
                    WriteOutput($"{school.Name}: {school.Pupils.Count}");
                }

                return _outputBuffer.ToString();
            }
        }















        private class SchoolPupilCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}