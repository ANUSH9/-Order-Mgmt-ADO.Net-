using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDetails
{
    internal class Item
    {
        public static string sqlConnectionstr = @"Data Source=DESKTOP-F0DS2US\SQLEXPRESS;Initial Catalog=OrderDetail;Integrated Security=True";

        public DataTable IsItemNameInItems(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string queryString = "SELECT CASE WHEN EXISTS (SELECT * FROM items WHERE ItemName = '" + name + "') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            sqlConnection.Close();
            return dataTable;
        }
        public string InsertItem()
        {
            Item itemMaster = new Item();


        ItemNo:
            Console.WriteLine("Enter the Item No:");
            int NO = Convert.ToInt32(Console.ReadLine());

            if (NO.Equals(""))
            {
                Console.WriteLine("NO Should not be empty!");
                goto ItemNo;
            }
        ItemName:
            Console.WriteLine("Enter the ItemName:");
            string name = Console.ReadLine();
            if (name.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto ItemName;
            }
            if (itemMaster.IsItemNameInItems(name).Rows[0][0].ToString().Equals("True"))
            {
                Console.WriteLine($"{name} is already in the Items Table.Please Insert different item!");
                goto ItemName;
            }
        ItemRate:
            Console.WriteLine("Enter the ItemRate:");
            int rate = Convert.ToInt32(Console.ReadLine());

            if (rate.Equals(""))
            {
                Console.WriteLine("Rate Should not be empty!");
                goto ItemRate;
            }


        ItemQTY:
            Console.WriteLine("Enter the ItemQuantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity.Equals(""))
            {
                Console.WriteLine("Qty Should not be empty!");
                goto ItemQTY;
            }

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into items values("+NO+",'" + name + "'," + rate + "," + quantity + ")", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Inserted";

            
        }

        public DataTable show()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select* from items", sqlConnection);
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
            SqlCommand cmd = new SqlCommand("delete from items where ItemNo=" + NO, sqlConnection);
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
            Console.WriteLine("Enter Item NO     : ");
            int NO = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Item Name  : ");
            string name = Console.ReadLine();

            Console.WriteLine("update Item Rate  : ");
            int rate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Item QTY   : ");
            int Qty = Convert.ToInt32(Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update items set ItemNo="+NO+",ItemName='" + name + "',ItemRate=" + rate + ",ItemQTY='" + Qty + "' where ItemNo=" + NO + "", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

        }
    }
}
