using System;
using System.Linq;
using System.Data.Entity;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        //Page through schools
        public string DoProblem7()
        {
            using (var db = new EFSchoolSystemContext())
            {
                var model = new ResultsModel();
                var rnd = new Random();
                model.Page = rnd.Next(1, 1000);
                model.ResultsPerPage = rnd.Next(10, 100);
                var resultsToSkip = model.Page * model.ResultsPerPage;

                var schools = db.Schools
                    .OrderBy(s => s.PostalZipCode)
                    .Skip(resultsToSkip)
                    .Take(model.ResultsPerPage)
                    .ToList();

                foreach (var school in schools)
                {
                    _outputBuffer.Append(school.Name);
                }
                return _outputBuffer.ToString();
            }
        }
    }
}