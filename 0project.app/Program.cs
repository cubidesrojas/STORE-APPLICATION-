using logic;
using retailstoredata.sql;
using System.Collections.Generic;
using System;


namespace _0Project

{
    class program

    {
        public static void Main()
        {

            Console.Clear();

            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                switch (counter % 4)
                {

                    case 0:
                        {
                            Console.WriteLine("                   _____ ");
                            Console.WriteLine("                  |     |");
                            Console.WriteLine("                  |     |");
                            Console.WriteLine("                  |__^__|");
                            break;
                            Console.Clear();
                        };

                    case 1:
                        {
                            Console.WriteLine("                    _____ ");
                            Console.WriteLine("                   |     |");
                            Console.WriteLine("                   |  ^  |");
                            Console.WriteLine("                   |_____|");
                            break;
                            Console.Clear();
                        };

                    case 2:
                        {
                            Console.WriteLine("                    _____ ");
                            Console.WriteLine("                   |  ^  |");
                            Console.WriteLine("                   |     |");
                            Console.WriteLine("                   |_____|");
                            break;
                            Console.Clear();
                        };
                        Console.Clear();
                }
                counter++;
                Thread.Sleep(200);


            }
            Console.WriteLine("              \n\n\n        WELCOME TO AUTO PARTS STORES!!!!!\n\n\n");
            Console.WriteLine("Please, select your nearest store: \n\n\n");
            string stores = @"  

        [0] SOUTH DALLAS   
        [1] NORHT DALLAS 
               


            
                                    ";

            Console.WriteLine(stores);

            string[] storeslocations = { "SOUTH DALLAS", "NORHT DALLAS" };
            int answer1 = int.Parse(Console.ReadLine());
            string Itemselected1 = storeslocations[answer1];
            switch (answer1)
            {
                case 0:

                    Iretailstore connection1 = new retailstoresql("Server=tcp:christian709.database.windows.net,1433;Initial Catalog=christian709;Persist Security Info=False;User ID=christian709;Password=gato8711*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                    var inventory2 = connection1.getinventory(1);
                    int item11 = 0;
                    int item22 = 0;
                    int item33 = 0;
                    int item44 = 0;
                    int item55 = 0;
                    foreach (var item in inventory2)
                    {
                        item11 += item.storeid;
                        item22 += item.Engines;
                        item33 += item.INCAPPARTS;
                        item44 += item.WINDOWS;
                        item55 += item.DOORS;
                    }
                    var inventory33 = new customer(item11, item22, item33, item44, item55, DateTime.Now);
                    company.inventory.Add(inventory33);

                    var datacustomers1 = connection1.getcustomerlist(1);
                    string name1 = "";
                    string lastname1;
                    int customerid;
                    int storeid1;
                    foreach (var customer1 in datacustomers1)
                    {
                        storeid1 = customer1.storeid;
                        name1 = customer1.name;
                        lastname1 = customer1.lastname;
                        customerid = customer1.item;
                        var client = new customer(storeid1, name1, lastname1, customerid);
                        company.customerslist.Add(client);
                    }

                    var datasuppliers1 = connection1.getsupplierlist(1);
                    string name2;
                    string lastname2;
                    int supplierid;
                    int storeid2;
                    foreach (var customer2 in datasuppliers1)
                    {
                        storeid2 = customer2.storeid;
                        name2 = customer2.name;
                        lastname2 = customer2.lastname;
                        supplierid = customer2.item;
                        var client = new customer(storeid2, name2, lastname2, supplierid);
                        company.supplier.Add(client);
                    }


                    while (true)
                    {


                        Console.WriteLine("     \n\n     WELCOME TO SOUTH DALLAS AUTO PARTS STORE !!!!!!");
                        Console.WriteLine("\n\n\nPlease, select your role: \n\n");

                        string Inventory = @"  

                [0] CUSTOMER    
                [1] SUPPLIER 
                [2] CORPORATE
                [3] EXIT



                                    ";

                        Console.WriteLine(Inventory);
                        customerassistant Andrea = new customerassistant("Andres", "camargo", "EMPLOYEE");
                        customer inventory = new customer(20, 20, 20, 20, 20, DateTime.Now);
                        customer angie = new customer(1, "angie", "camargo", 25);





                        string[] inventory22 = { "CUSTOMER", "SUPPLIER", "EMPLOYEE", "CORPORATE" };
                        int answer = int.Parse(Console.ReadLine());
                        string Itemselected = inventory22[answer];

                        switch (answer)
                        {
                            case 0:
                                Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                char ans2 = char.Parse(Console.ReadLine());
                                if (ans2.Equals('n'))
                                {
                                    Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Please , type your lastname.\n");
                                    string lastname = Console.ReadLine();
                                    Console.WriteLine("type last four numbers of your phonenumber.\n");
                                    int item = Int32.Parse(Console.ReadLine());

                                    Andrea.register(1, name, lastname, item);

                                }


                                if (ans2.Equals('y')) { Andrea.lookforclient(); }


                                else { break; }

                                break;

                            case 1:

                                Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                char ans10 = char.Parse(Console.ReadLine());
                                if (ans10.Equals('n'))
                                {
                                    Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Please , type your lastname.\n");
                                    string lastname = Console.ReadLine();
                                    Console.WriteLine("type last four numbers of your phonenumber.\n");
                                    int item = Int32.Parse(Console.ReadLine());

                                    Andrea.registersupplier(1, name, lastname, item);

                                }


                                if (ans10.Equals('y')) { Andrea.lookforsupplaier(); }


                                else { break; }


                                break;



                            case 2:



                                Andrea.inventory4();
                                Andrea.record();

                                break;


                            case 3:
                                break;


                        }
                        Console.WriteLine($"Dear {Itemselected}, Do you still need to do something else ?(y/n)\n\n");
                        char ans7 = char.Parse(Console.ReadLine());

                        if (ans7.Equals('n'))
                        { break; }
                        else { continue; }








                    }

                    var inventory55 = company.inventory;
                    int item99 = 0;
                    int item101 = 0;
                    int item111 = 0;
                    int item121 = 0;

                    foreach (var item in inventory55)
                    {
                        item99 += item.Engines;
                        item101 += item.INCAPPARTS;
                        item111 += item.WINDOWS;
                        item121 += item.DOORS;
                    }

                    connection1.endinventory(1, item99, item101, item111, item121, DateTime.Now);

                    break;



                /*       Iretailstore connection = new retailstoresql("Server=tcp:christian709.database.windows.net,1433;Initial Catalog=christian709;Persist Security Info=False;User ID=christian709;Password=gato8711*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                       var inventory1 = connection.getinventory();
                       int item1 = 0;
                       int item2 = 0;
                       int item3 = 0;
                       int item4 = 0;
                       foreach (var item in inventory1)
                       {
                           item1 += item.Engines;
                           item2 += item.INCAPPARTS;
                           item3 += item.WINDOWS;
                           item4 += item.DOORS;
                       }
                       var inventory3 = new customer("inventory", item1, item2, item3, item4, DateTime.Now);
                       company.inventory.Add(inventory3);

                       var datacustomers = connection.getcustomerlist();
                       string name1 = "";
                       string lastname1;
                       int customerid;
                       foreach (var customer1 in datacustomers)
                       {
                           name1 = customer1.name;
                           lastname1 = customer1.lastname;
                           customerid = customer1.item;
                           var client = new customer(name1, lastname1, customerid);
                           company.customerslist.Add(client);
                       }

                       var datasuppliers = connection.getsupplierlist();
                       string name2;
                       string lastname2;
                       int supplierid;
                       foreach (var customer2 in datasuppliers)
                       {
                           name2 = customer2.name;
                           lastname2 = customer2.lastname;
                           supplierid = customer2.item;
                           var client = new customer(name2, lastname2, supplierid);
                           company.supplier.Add(client);
                       }


                       while (true)
                       {


                           Console.WriteLine("     \n\n     WELCOME TO SOUTH DALLAS AUTO PARTS STORE !!!!!!");
                           Console.WriteLine("\n\n\nPlease, select your role: \n\n");

                           string Inventory = @"  

                   [0] CUSTOMER    
                   [1] SUPPLIER 
                   [2] CORPORATE
                   [3] EXIT



                                       ";

                           Console.WriteLine(Inventory);
                           customerassistant Andrea = new customerassistant("Andres", "camargo", "EMPLOYEE");
                           customer inventory = new customer("initial inventory", 20, 20, 20, 20, DateTime.Now);
                           customer angie = new customer("angie", "camargo", 25);





                           string[] inventory2 = { "CUSTOMER", "SUPPLIER", "EMPLOYEE", "CORPORATE" };
                           int answer = int.Parse(Console.ReadLine());
                           string Itemselected = inventory2[answer];

                           switch (answer)
                           {
                               case 0:
                                   Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                   char ans2 = char.Parse(Console.ReadLine());
                                   if (ans2.Equals('n'))
                                   {
                                       Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                       string name = Console.ReadLine();
                                       Console.WriteLine("Please , type your lastname.\n");
                                       string lastname = Console.ReadLine();
                                       Console.WriteLine("type last four numbers of your phonenumber.\n");
                                       int item = Int32.Parse(Console.ReadLine());

                                       Andrea.register(name, lastname, item);

                                   }


                                   if (ans2.Equals('y')) { Andrea.lookforclient(); }


                                   else { break; }

                                   break;

                               case 1:

                                   Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                   char ans10 = char.Parse(Console.ReadLine());
                                   if (ans10.Equals('n'))
                                   {
                                       Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                       string name = Console.ReadLine();
                                       Console.WriteLine("Please , type your lastname.\n");
                                       string lastname = Console.ReadLine();
                                       Console.WriteLine("type last four numbers of your phonenumber.\n");
                                       int item = Int32.Parse(Console.ReadLine());

                                       Andrea.registersupplier(name, lastname, item);

                                   }


                                   if (ans10.Equals('y')) { Andrea.lookforsupplaier(); }


                                   else { break; }


                                   break;



                               case 2:



                                   Andrea.inventory4();
                                   Andrea.record();

                                   break;


                               case 3:
                                   break;


                           }
                           Console.WriteLine($"Dear {Itemselected}, Do you still need to do something else ?(y/n)\n\n");
                           char ans7 = char.Parse(Console.ReadLine());

                           if (ans7.Equals('n'))
                           { break; }
                           else { continue; }








                       }

                       var inventory5 = company.inventory;
                       int item5 = 0;
                       int item6 = 0;
                       int item7 = 0;
                       int item8 = 0;

                       foreach (var item in inventory5)
                       {
                           item5 += item.Engines;
                           item6 += item.INCAPPARTS;
                           item7 += item.WINDOWS;
                           item8 += item.DOORS;
                       }

                       connection.endinventory(item5, item6, item7, item8, DateTime.Now);
                    break;
   */

                case 1:
                    Iretailstore connection = new retailstoresql("Server=tcp:christian709.database.windows.net,1433;Initial Catalog=christian709;Persist Security Info=False;User ID=christian709;Password=gato8711*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                    var inventory1 = connection.getinventory(2);
                    int item1 = 0;
                    int item2 = 0;
                    int item3 = 0;
                    int item4 = 0;
                    int item5 = 0;
                    foreach (var item in inventory1)
                    {
                        item1 += item.storeid;
                        item2 += item.Engines;
                        item3 += item.INCAPPARTS;
                        item4 += item.WINDOWS;
                        item5 += item.DOORS;
                    }
                    var inventory3 = new customer(item1, item2, item3, item4, item5, DateTime.Now);
                    company.inventory.Add(inventory3);

                    var datacustomers = connection.getcustomerlist(2);
                    string name11 = "";
                    string lastname11;
                    int customerid11;
                    int storeid11;
                    foreach (var customer1 in datacustomers)
                    {
                        storeid11 = customer1.storeid;
                        name11 = customer1.name;
                        lastname11 = customer1.lastname;
                        customerid11 = customer1.item;
                        var client = new customer(storeid11, name11, lastname11, customerid11);
                        company.customerslist.Add(client);
                    }

                    var datasuppliers = connection.getsupplierlist(2);
                    string name22;
                    string lastname22;
                    int supplierid22;
                    int storeid22;
                    foreach (var customer2 in datasuppliers)
                    {
                        storeid22 = customer2.storeid;
                        name22 = customer2.name;
                        lastname22 = customer2.lastname;
                        supplierid22 = customer2.item;
                        var client = new customer(storeid22, name22, lastname22, supplierid22);
                        company.supplier.Add(client);
                    }


                    while (true)
                    {


                        Console.WriteLine("     \n\n     WELCOME TO NORTH DALLAS AUTO PARTS STORE !!!!!!");
                        Console.WriteLine("\n\n\nPlease, select your role: \n\n");

                        string Inventory = @"  

                [0] CUSTOMER    
                [1] SUPPLIER 
                [2] CORPORATE
                [3] EXIT



                                    ";

                        Console.WriteLine(Inventory);
                        customerassistant Andrea = new customerassistant("Andres", "camargo", "EMPLOYEE");
                        customer inventory = new customer(20, 20, 20, 20, 20, DateTime.Now);
                        customer angie = new customer(2, "angie", "camargo", 25);





                        string[] inventory123 = { "CUSTOMER", "SUPPLIER", "EMPLOYEE", "CORPORATE" };
                        int answer = int.Parse(Console.ReadLine());
                        string Itemselected = inventory123[answer];

                        switch (answer)
                        {
                            case 0:
                                Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                char ans2 = char.Parse(Console.ReadLine());
                                if (ans2.Equals('n'))
                                {
                                    Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Please , type your lastname.\n");
                                    string lastname = Console.ReadLine();
                                    Console.WriteLine("type last four numbers of your phonenumber.\n");
                                    int item = Int32.Parse(Console.ReadLine());

                                    Andrea.register(2, name, lastname, item);

                                }


                                if (ans2.Equals('y')) { Andrea.lookforclient(); }


                                else { break; }

                                break;

                            case 1:

                                Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                                char ans10 = char.Parse(Console.ReadLine());
                                if (ans10.Equals('n'))
                                {
                                    Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Please , type your lastname.\n");
                                    string lastname = Console.ReadLine();
                                    Console.WriteLine("type last four numbers of your phonenumber.\n");
                                    int item = Int32.Parse(Console.ReadLine());

                                    Andrea.registersupplier(2, name, lastname, item);

                                }


                                if (ans10.Equals('y')) { Andrea.lookforsupplaier(); }


                                else { break; }


                                break;



                            case 2:



                                Andrea.inventory4();
                                Andrea.record();

                                break;


                            case 3:
                                break;


                        }
                        Console.WriteLine($"Dear {Itemselected}, Do you still need to do something else ?(y/n)\n\n");
                        char ans7 = char.Parse(Console.ReadLine());

                        if (ans7.Equals('n'))
                        { break; }
                        else { continue; }








                    }

                    var inventory5 = company.inventory;
                    int item9 = 0;
                    int item10 = 0;
                    int item112 = 0;
                    int item12 = 0;

                    foreach (var item in inventory5)
                    {
                        item9 += item.Engines;
                        item10 += item.INCAPPARTS;
                        item112 += item.WINDOWS;
                        item12 += item.DOORS;
                    }

                    connection.endinventory(2, item9, item10, item112, item12, DateTime.Now);

                    break;
            }



        }


    }

}


















