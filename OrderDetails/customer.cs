using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrderDetails
{
    internal class customer
    {
        public static string sqlConnectionstr = @"Data Source=DESKTOP-F0DS2US\SQLEXPRESS;Initial Catalog=OrderDetail;Integrated Security=True";
        public string Insert()
        {
            customer customerMaster = new customer();


        CustomerNo:
            Console.WriteLine("Enter Customer NO:");
            int NO = Convert.ToInt32(Console.ReadLine());

            if (NO.Equals(""))
            {
                Console.WriteLine("No Should not be empty!");
                goto CustomerNo;
            }
        FirstName:
            Console.WriteLine("Enter the First Name:");
            string name = Console.ReadLine();

            if (name.Equals(""))
            {
                Console.WriteLine("First name Should not be empty!");
                goto FirstName;
            }
            email_name obj = new email_name();
           
            string a = obj.Insertname();
            Console.WriteLine(a);
         

        LastName:
            Console.WriteLine("Enter the Last Name:");
            string last = Console.ReadLine();

            if (last.Equals(""))
            {
                Console.WriteLine("Last name Should not be empty!");
                goto LastName;
            }


        Phone:
            Console.WriteLine("Enter the Phone:");
            int phone = Convert.ToInt32(Console.ReadLine());

            if (phone.Equals(""))
            {
                Console.WriteLine("Phone Should not be empty!");
                goto Phone;
            }

        Email:
            Console.WriteLine("Enter the Email:");
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
                Console.ReadLine();
            }
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("as0285303@gmail.com");
                message.To.Add(new MailAddress("email"));
                message.Subject = "Welcome";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Thans for registering to our portal";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
            email_name obj1 = new email_name();
            string a1 = obj1.Insert();
            Console.WriteLine(a1);
          
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into Customer values(" + NO + ",'" + name + "','" + last + "'," + phone + ",'"+email+"')", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return "inserted";
        }
        public DataTable show()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select * from Customer", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = cmd.ExecuteReader();

            DataTable obj = new DataTable();
            obj.Load(DataReader);

            sqlConnection.Close();
            return obj;
        }
        public string DeleteItem(int NO)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("delete from Customer where CustomerNo=" + NO, sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
            {
                return "notDeleted";
            }
            return "Deleted";
        }
        public string Update()
        {
            Console.WriteLine("Enter Customer NO  : ");
            int NO = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update First Name  : ");
            string name = Console.ReadLine();

            Console.WriteLine("Update Last Name   : ");
            string Last = Console.ReadLine();
            email_name obj3 = new email_name();

            string a = obj3.Insertname();
            Console.WriteLine(a);
            

            Console.WriteLine("update Phone Rate  : ");
            int phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Email       : ");
            string email = Console.ReadLine();
            email_name obj4 = new email_name();

            string a2 = obj4.Insertname();
            Console.WriteLine(a2);
           

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update Customer set CustomerNo=" + NO + ",FirstName='" + name + "',LastName='"+Last+ "',Phone=" + phone + ",Email='" + email + "' where CustomerNo=" + NO + "", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

        }

        
    }
}
