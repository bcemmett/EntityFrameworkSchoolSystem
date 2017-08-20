using System;
using System.Linq;
using System.Text;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public static string DoProblem4()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string zipCode = "90210";

                var pupils = db.Pupils
                    .Where(p => p.PostalZipCode == zipCode)
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