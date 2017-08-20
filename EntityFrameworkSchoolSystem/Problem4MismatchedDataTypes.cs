using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public string DoProblem4()
        {
            using (var db = new EFSchoolSystemContext())
            {
                string zipCode = "90210";

                var pupils = db.Pupils
                    .Where(p => p.PostalZipCode == zipCode)
                    .Select(x => new { x.FirstName, x.LastName })
                    .ToList();
                
                foreach (var pupil in pupils)
                {
                    WriteOutput($"{pupil.FirstName} {pupil.LastName}");
                }

                return _outputBuffer.ToString();
            }
        }
    }
}