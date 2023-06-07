using NetCoreAdo.Models;
using NetCoreAdo.Utility;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreAdo.Data
{
    public class StudentDAL
    {
        string connectionString = ConnectionString.cName;

        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> listStudents = new List<Student>();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPGetAllStudent", con);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                con.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();

                    student.Id =Convert.ToInt32(reader["ID"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();

                    listStudents.Add(student);
                }
                con.Close();
            }

            return listStudents;
        }
    }
}
