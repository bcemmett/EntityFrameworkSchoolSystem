using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private Stopwatch _timer;

        private void button1_Click(object sender, EventArgs e)
        {
            StartTest("1");
            string result = DataLayer.DoProblem1();
            EndTest(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";

                List<School> schools = db.Schools.Where(s => s.City == city).ToList();
                var sb = new StringBuilder();
                foreach(var school in schools)
                {
                    sb.Append(school.Name);
                    sb.Append(": ");
                    sb.Append(school.Pupils.Count);
                    sb.Append(Environment.NewLine);
                }
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                int schoolId = 1;

                List<Pupil> pupils = db.Pupils
                    .Where(p => p.SchoolId == schoolId)
                    .ToList();

                var sb = new StringBuilder();
                foreach(var pupil in pupils)
                {
                    sb.Append(pupil.FirstName);
                    sb.Append(" ");
                    sb.Append(pupil.LastName);
                    sb.Append(Environment.NewLine);
                }
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                string zipCode = "90210";

                var pupils = db.Pupils
                    .Where(p => p.PostalZipCode == zipCode)
                    .Select(x => new {x.FirstName, x.LastName})
                    .ToList();

                var sb = new StringBuilder();
                foreach (var pupil in pupils)
                {
                    sb.Append(pupil.FirstName);
                    sb.Append(" ");
                    sb.Append(pupil.LastName);
                    sb.Append(Environment.NewLine);
                }
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                db.Database.CommandTimeout = 300;
                string city = "New York";

                var pupils = db.Pupils
                    .Where(p => p.City == city)
                    .OrderBy(p => p.LastName)
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
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
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

                List<Pupil> pupils = db.Pupils.Where(p =>
                        (searchModel.FirstName == null || p.FirstName == searchModel.FirstName)
                        && (searchModel.LastName == null || p.LastName == searchModel.LastName)
                        && (searchModel.City == null || p.LastName == searchModel.City)
                        && (searchModel.PostalZipCode == null || p.PostalZipCode == searchModel.PostalZipCode)
                    )
                    .Take(100)
                    .ToList();

                var sb = new StringBuilder();
                foreach (var pupil in pupils)
                {
                    sb.Append(pupil.FirstName);
                    sb.Append(" ");
                    sb.Append(pupil.LastName);
                    sb.Append(Environment.NewLine);
                }
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                var model = new ResultsModel();
                var rnd = new Random();
                model.Page = rnd.Next(1, 1000);
                model.ResultsPerPage = rnd.Next(10, 100);
                var schools = db.Schools
                    .OrderBy(s => s.PostalZipCode)
                    .Skip(model.Page * model.ResultsPerPage)
                    .Take(model.ResultsPerPage)
                    .ToList();

                var sb = new StringBuilder();
                foreach (var school in schools)
                {
                    sb.Append(school.Name);
                    sb.Append(Environment.NewLine);
                }
                textBoxResults.Text = sb.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PrintThatFetchingData();
            using (var db = new EFSchoolSystemContext())
            {
                for (int i = 0; i < 2000; i++)
                {
                    Pupil pupil = GetNewPupil();
                    db.Pupils.Add(pupil);
                }
                db.SaveChanges();

                textBoxResults.Text = "Finished adding data";
            }
        }

        private void StartTest(string testName)
        {
            _timer = Stopwatch.StartNew();
            textBoxResults.Text = String.Empty;
            labelTime.Text = String.Empty;
            labelStatus.Text = $"Doing work for test {testName}";
            Refresh();
        }

        private void EndTest(string result)
        {
            textBoxResults.Text = result;
            labelTime.Text = (_timer.ElapsedMilliseconds / 1000.0) + " s";
            labelStatus.Text = "Done";
            _timer.Stop();
        }

        private Pupil GetNewPupil()
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

        private void PrintThatFetchingData()
        {
            textBoxResults.Text = "Fetching data...";
            Refresh();
        }
    }
}