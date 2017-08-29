using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    class WhyEntityFramework
    {
        public List<Pupil> GetSchoolsTraditionally(string schoolName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Live"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
                        SELECT p.PupilId, p.FirstName, p.LastName, p.Address1, p.Adderss2,
                               p.PostalZipCode, p.City, p.PhoneNumber, p.SchoolId, p.Picture
                        FROM   dbo.Pupils p
                        INNER JOIN dbo.Schools s
                        ON     s.SchoolId = p.SchoolId
                        WHERE  s.Name = @schoolName
                        ";

                    cmd.Parameters.AddWithValue("@schoolName", schoolName);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Pupil> pupils = new List<Pupil>();
                        while (reader.Read())
                        {
                            pupils.Add(new Pupil
                            {
                                FirstName = (string)reader["FirstName"], LastName = (string)reader["LastName"],
                                Address1 = (string)reader["Address1"], Adderss2 = (string)reader["Adderss2"],
                                City = (string)reader["City"], PostalZipCode = (string)reader["PostalZipCode"],
                                PupilId = (int)reader["PupilId"], SchoolId = (int)reader["SchoolId"],
                                PhoneNumber = (string)reader["PhoneNumber"], Picture = (byte[])reader["Picture"]
                            });
                        }
                        return pupils;
                    }
                }
            }
        }





        public List<Pupil> GetSchoolsWithEntityFramework(string schoolName)
        {
            using (var db = new EFSchoolSystemContext())
            {
                return db.Pupils.Where(p => p.School.Name == schoolName).ToList();
            }
        }
    }
}