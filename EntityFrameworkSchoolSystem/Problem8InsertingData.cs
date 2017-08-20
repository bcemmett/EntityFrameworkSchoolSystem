using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        public string DoProblem8()
        {
            using (var db = new EFSchoolSystemContext())
            {
                for (int i = 0; i < 2000; i++)
                {
                    Pupil pupil = GetNewPupil();
                    db.Pupils.Add(pupil);
                }
                db.SaveChanges();

                return "Finished adding data";
            }
        }

        private static Pupil GetNewPupil()
        {
            return new Pupil
            {
                FirstName = "Josephine",
                LastName = "Tomkinson",
                Address1 = "1234 West Ave",
                City = "New Houndslow",
                PostalZipCode = "12345",
                SchoolId = 1
            };
        }
    }
}