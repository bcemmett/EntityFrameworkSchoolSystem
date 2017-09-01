using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        //Retrieve pupil names in a single school
        public string DoProblem3()
        {
            using (var db = new EFSchoolSystemContext())
            {
                int schoolId = 1;

                List<Pupil> pupils = db.Pupils
                    .Where(p => p.SchoolId == schoolId)
                    .ToList();

                foreach (var pupil in pupils)
                {
                    WriteOutput($"{pupil.FirstName} {pupil.LastName}");
                }

                return _outputBuffer.ToString();
            }
        }
        














        private class PupilName
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}