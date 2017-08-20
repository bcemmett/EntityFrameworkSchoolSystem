using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem3()
        {
            using (var db = new EFSchoolSystemContext())
            {
                int schoolId = 1;

                List<Pupil> pupils = db.Pupils
                    .Where(p => p.SchoolId == schoolId)
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