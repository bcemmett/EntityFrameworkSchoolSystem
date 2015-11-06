﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";

                List<School> schools = db.Schools.ToList();
                List<School> newYorkSchools = schools.Where(s => s.City == city).ToList();
                
                textBox_Output.Text = String.Empty;
                foreach (var school in newYorkSchools)
                {
                    textBox_Output.Text += school.Name + Environment.NewLine;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                textBox_Output.Text = sb.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                int schoolId = 1;

                List<Pupil> pupils = db.Pupils
                    .Where(p => p.SchoolId == schoolId)
                    .ToList();

                textBox_Output.Text = String.Empty;
                foreach(var pupil in pupils)
                {
                    textBox_Output.Text += pupil.FirstName + " " + pupil.LastName;
                    textBox_Output.Text += Environment.NewLine;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                string zipCode = "90210";

                var pupils = db.Pupils
                    .Where(p => p.PostalZipCode == zipCode)
                    .Select(x => new {x.FirstName, x.LastName})
                    .ToList();

                textBox_Output.Text = String.Empty;
                foreach (var pupil in pupils)
                {
                    textBox_Output.Text += pupil.FirstName + " " + pupil.LastName;
                    textBox_Output.Text += Environment.NewLine;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
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
                textBox_Output.Text = sb.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                string firstName = "Ben";
                string lastName = String.Empty;
                string city = String.Empty;
                string postCode = String.Empty;
                List<Pupil> pupils = db.Pupils.Where(p =>
                        (firstName == String.Empty || p.FirstName == firstName)
                        && (lastName == String.Empty || p.LastName == lastName)
                        && (city == String.Empty || p.LastName == city)
                        && (postCode == String.Empty || p.PostalZipCode == postCode)
                    )
                    .Take(100)
                    .ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                for (int i = 0; i < 2000; i++)
                {
                    Pupil pupil = GetNewPupil();
                    db.Pupils.Add(pupil);
                }
                db.SaveChanges();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var db = new EFSchoolSystemContext())
            {
                string city = "New York";
                List<School> schools = db.Schools
                    .Where(s => s.City == city)
                    .Take(100)
                    .ToList();

                foreach (var school in schools)
                {
                    textBox_Output.Text += school.Name + Environment.NewLine;
                }
            }
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
    }
}