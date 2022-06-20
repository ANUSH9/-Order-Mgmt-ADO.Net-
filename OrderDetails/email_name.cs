using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrderDetails
{
    internal class email_name
    {
        public static string sqlConnectionstr = @"Data Source=DESKTOP-F0DS2US\SQLEXPRESS;Initial Catalog=OrderDetail;Integrated Security=True";
        public string Insert()
        {
            email_name customerMaster = new email_name();


       

        Email:
            Console.WriteLine("re Enter email address :");
            string email = Console.ReadLine();

            if (email.Equals(""))
            {
                Console.WriteLine("Email Should not be empty!");
                goto Email;
            }
            try
            {
                Console.WriteLine($"The email is {email}");
                var mail = new MailAddress(email);
                bool isValidEmail = mail.Host.Contains(".");
                if (!isValidEmail)
                {
                    Console.WriteLine($"The email is invalid");
                }
                else
                {
                    Console.WriteLine($"The email is valid");
                }
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine($"The email is invalid");
                
            }
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into email values('" + email + "')", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "inserted";
        }
        public string Update()
        {
           

            Console.WriteLine("re enter email to update   : ");
            string email = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update email set emailID='" + email + "' ", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

        }
        public string Insertname()
        {
            customer customerMaster = new customer();


        
        FirstName:
            Console.WriteLine("Re Enter the First Name:");
            string name = Console.ReadLine();

            if (name.Equals(""))
            {
                Console.WriteLine("First name Should not be empty!");
                goto FirstName;
            }

       
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into Firstname values('" + name + "')", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "inserted";
        }
       
        public string Updatename()
        {
           

            Console.WriteLine("Update First Name  : ");
            string name = Console.ReadLine();

           

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update Firstname set firstname='" + name + "'", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

        }
        public DataTable showemail()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("SELECT * FROM email WHERE emailID=(SELECT max(emailID) FROM email)", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = cmd.ExecuteReader();

            DataTable obj = new DataTable();
            obj.Load(DataReader);

            sqlConnection.Close();
            return obj;
        }
        public DataTable showname()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Firstname WHERE firstname = (SELECT max(firstname) FROM Dirstname)", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = cmd.ExecuteReader();

            DataTable obj = new DataTable();
            obj.Load(DataReader);

            sqlConnection.Close();
            return obj;
        }

    }
}
