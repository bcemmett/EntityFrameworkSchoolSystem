using System.Collections.Generic;
using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        //Search pupils based on optional criteria
        public string DoProblem6()
        {
            using (var db = new EFSchoolSystemContext())
            {
                //Search data as input by user
                var searchModel = new Pupil
                {
                    FirstName = "Ben",
                    LastName = null,
                    City = null,
                    PostalZipCode = null
                };

                List<PupilName> pupils = db.Pupils.Where(p =>
                        (searchModel.FirstName == null || p.FirstName == searchModel.FirstName)
                        && (searchModel.LastName == null || p.LastName == searchModel.LastName)
                        && (searchModel.City == null || p.LastName == searchModel.City)
                        && (searchModel.PostalZipCode == null || p.PostalZipCode == searchModel.PostalZipCode)
                    )
                    .Take(100)
                    .Select(p => new PupilName{FirstName = p.FirstName, LastName = p.LastName})
                    .ToList();

                foreach (var pupil in pupils)
                {
                    _outputBuffer.Append($"{pupil.FirstName} {pupil.LastName}");
                }

                return _outputBuffer.ToString();
            }
        }
    }
}