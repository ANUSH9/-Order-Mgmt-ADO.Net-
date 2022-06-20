using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDetails
{
    internal class @switch
    {
        public void loginAs()
        {
        menu:
            Console.WriteLine("---------------Admin----------------------");
            Console.WriteLine(" Item Press                        : 1");
            Console.WriteLine(" Customer Press                    : 2");
            Console.WriteLine(" Exit Press                        : 4");
            Console.WriteLine("______________________________________");
            int user = Convert.ToInt32(Console.ReadLine());
            switch (user)
            {
                case 1:
                    {
                    Items:
                        Item();
                        Item obj = new Item();
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Insert");
                                string a = obj.InsertItem();
                                Console.WriteLine(a);
                                Console.ReadKey();
                                goto Items;
                            case 2:
                                Console.WriteLine("update");
                                string b = obj.Update();
                                Console.WriteLine(b);
                                Console.ReadKey();
                                goto Items;
                            case 3:
                                Console.WriteLine("Show all");
                                DataTable dt = obj.show();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dt.Columns.Count; j++)
                                    {
                                        Console.Write(dt.Rows[i][j] + "\t");
                                    }
                                    Console.WriteLine();

                                }
                                Console.ReadKey();
                                goto Items;
                            case 4:
                                Console.WriteLine("Delete by Id");

                                Console.WriteLine("Enter ID to delete: ");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                string a1 = obj.DeleteItem(Id);
                                Console.WriteLine(a1);
                                Console.ReadKey();
                                goto Items;
                            case 5:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Choise ");
                                goto Items;

                        }
                    }
                    break;
                case 2:
                    {
                    Items:
                        Item();
                        customer obj = new customer();
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Insert");
                                string a = obj.Insert();
                                Console.WriteLine(a);
                                Console.ReadKey();
                                goto Items;
                            case 2:
                                Console.WriteLine("update");
                                string b = obj.Update();
                                Console.WriteLine(b);
                                Console.ReadKey();
                                goto Items;
                            case 3:
                                Console.WriteLine("Show all");
                                DataTable dt = obj.show();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dt.Columns.Count; j++)
                                    {
                                        Console.Write(dt.Rows[i][j] + "\t");
                                    }
                                    Console.WriteLine();

                                }
                                Console.ReadKey();
                                goto Items;
                            case 4:
                                Console.WriteLine("Delete by Id");

                                Console.WriteLine("Enter ID to delete: ");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                string a1 = obj.DeleteItem(Id);
                                Console.WriteLine(a1);
                                Console.ReadKey();
                                goto Items;
                            case 5:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Choise ");
                                goto Items;

                        }
                    }
                    break;
                
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" bad Input ");
                    Console.WriteLine("try Again");
                    goto menu;


            }





        }
        private void Item()
        {
            Console.WriteLine("----------------Item Menu----------------");
            Console.WriteLine("Adding New Item Press          : 1");
            Console.WriteLine("Update Item Press              : 2");
            Console.WriteLine("View All data Press           : 3");
            Console.WriteLine("Delete Item Press              : 4");
            Console.WriteLine("Exit Press                     : 5");
        }
        
        private void CustomerMenu()
        {
            Console.WriteLine("----------------Customer Menu----------------");
            Console.WriteLine("Adding New Customer Press          : 1");
            Console.WriteLine("Update Customer Press              : 2");
            Console.WriteLine("View All data Press                : 3");
            Console.WriteLine("Delete Customer Press              : 4");
            Console.WriteLine("Exit Press                         : 5");
        }
    }
}

