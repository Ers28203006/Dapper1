using Students.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Students.DataAccess
{
    public class StudentRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

        #region работа с таблицей группы


        public static List<Models.Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            using (IDbConnection connection =new SqlConnection(connectionString))
            {
                groups = connection.Query<Group>("Select * from Groups").ToList();
            }

            return groups;
        }

        public static void CreateGroup(Group group)
        {
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Groups(Name) VALUES(@Name)";
                connection.Execute(query, group);
            }
        }

        public static void DeleteGroup(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Groups WHERE Id=@id";
                connection.Execute(query, new { id });
            }
        }

        public static void UpdateGroup(int id)
        {
            using(IDbConnection connection= new SqlConnection(connectionString))
            {
                var query = "UPDATE Groups SET Name='AAA-000' WHERE Id=@id";
                connection.Execute(query, new { id });
            }
        }
        #endregion

        public static void CreateStudent(Student student)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                 var query="INSERT INTO Students(FirstName, LastName, MiddleName, GroupId) VALUES (@FirstName, @LastName, @MiddleName, @GroupId)";
                connection.Execute(query, student);
            }
        }

        public static void UpdateStudent(int id)
        {
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                var query = "UPDATE Students SET FirstName='Qwee', LastName='Sdff', MiddleName='Sfdfgfgf' WHERE Id=@id";
                connection.Execute(query, new { id });
            }
        }

        public static void DeleteStudent(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var query="DELETE FROM Students WHERE Id=@id";
                connection.Execute(query, new { id });
            }
        }

        public static void ShowStudent()
        {
            List<Student> students = new List<Student>();
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                students = connection.Query<Student>("SELECT * FROM Students").ToList();
            }
            Console.WriteLine("Список студентов: ");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}. {student.FirstName} {student.LastName} {student.MiddleName}");
            }
        }

    }
}
