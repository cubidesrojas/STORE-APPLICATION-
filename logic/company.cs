using System.Xml.Serialization;
using retailstoredata.sql;
using System;

namespace logic


{
    public abstract class company
    {
        readonly string stringconnection = "Server=tcp:christian709.database.windows.net,1433;Initial Catalog=christian709;Persist Security Info=False;User ID=christian709;Password=gato8711*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        Iretailstore connection = new retailstoresql("Server=tcp:christian709.database.windows.net,1433;Initial Catalog=christian709;Persist Security Info=False;User ID=christian709;Password=gato8711*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        Iretailstore connection1 = new retailstoresql(0, 0, 0, 0, 0, DateTime.Now);

        public static List<customer> customerslist = new List<customer>() { };
        public static List<customer> coorporate = new List<customer>() { new customer(1, "christian", "cubides", 7) };
        public static List<customer> inventory = new List<customer>();
        public static List<customer> supplier = new List<customer>() { };
        private static int i = 0;
        protected string name;
        protected string lastname;
        protected string role;
        protected int orders;


        protected int Engines
        {


            get
            {
                int result = 0;
                foreach (var client in inventory)
                {
                    result += client.Engines;
                }
                return result;

            }
        }

        protected int INCAPPARTS
        {


            get
            {
                int result1 = 0;
                foreach (var client1 in inventory)
                {
                    result1 += client1.INCAPPARTS;
                }
                return result1;

            }

        }

        protected int WINDOWS
        {


            get
            {
                int result2 = 0;
                foreach (var client2 in inventory)
                {
                    result2 += client2.WINDOWS;
                }
                return result2;

            }

        }

        protected int DOORS
        {


            get
            {
                int result3 = 0;
                foreach (var client3 in inventory)
                {
                    result3 += client3.DOORS;
                }
                return result3;

            }

        }
        public List<customer> getlist()
        {
            return customerslist;
        }
        public int getengines()
        {
            return Engines;

        }

        public int getincapparts()
        {
            return INCAPPARTS;

        }

        public int getwindows()
        {
            return WINDOWS;

        }

        public int getdoors()
        {
            return DOORS;

        }
        protected int budget;
        protected float profit;
        public object customer_name;
        public object sold_Engines;
        public object sold_doors;
        public object DATETIME;
        public readonly object sold_incapparts;
        public readonly object sold_windows;

        // public string Getname
        //             {

        //             get {return this.name;}
        //             set {
        //                 if (name =="felipe") throw new ArgumentException ("bad input" ); 
        //                 this.name = value ;
        //                     }
        //             }

        public void register(int storeid, string name, string lastname, int item)
        {



            var client = new customer(storeid, name, lastname, item);
            connection.registercustomers(storeid, name, lastname, item);
            customerslist.Add(client);
            Console.WriteLine($"your user ID is {client.item}, please keep this informations for your next visit");


            return;

        }

        public void registersupplier(int storeid, string name, string lastname, int item)
        {
            var supplier1 = new customer(storeid, name, lastname, item);
            connection.registersuppliers(storeid, name, lastname, item);
            supplier.Add(supplier1);
            Console.WriteLine($"your user ID is {supplier1.item}, please keep this informations for your next visit");
        }


        public abstract void getorders();

        public async void inventory4()
        {
            Console.WriteLine("Please, type your corporate ID :\n\n");
            try
            {
                int clientID = int.Parse(Console.ReadLine());
                var findclient = coorporate.Find(x => x.item == clientID);
                Console.WriteLine(@"Welcome Bose !!!! :");
                Console.WriteLine("Here is and update of our inventory:");

                Console.WriteLine($"Available inventory:\n ENGINES: {Engines} \n INCAP PARTS: {INCAPPARTS} \n WINDOWS: {WINDOWS} \n DOORS: {DOORS}");

                Console.WriteLine("Bose, do you still need to do something else (y/n)?");
                char ans4 = char.Parse(Console.ReadLine());
                if (ans4.Equals('n')) { return; }


                if (ans4.Equals('y'))
                {
                    return;
                }
            }
            catch (Exception a) { Console.WriteLine("This is not a valid coorporate ID"); }
            return;

        }

        public void inventory3(int storeid, string name, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction)
        {
            var client = new customer(storeid, name, Engines, INCAPPARTS, WINDOWS, DOORS, timetransaction);
            inventory.Add(client);

            return;
        }

        /*public void getdatainventory()

        {

            var inventory1 = connection1.getinventory();

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
            var inventory2 = new customer("inventory", item1, item2, item3, item4, DateTime.Now);
            inventory.Add(inventory2);
        }*/

        public void lookforclient()
        {
            Console.WriteLine("Please, type your client ID :\n\n");
            int clientID = int.Parse(Console.ReadLine());
            var findclient = customerslist.Find(x => x.item == clientID);
            while (true)
            {

                Console.WriteLine("welcome dear customer, here is our menu ");


                string Inventory =
    @" From our menu, select the product that you need. 
                                                                       
             [0] ENGINES  
             [1] INCAP PARTS  
             [2] WINDOWS 
             [3] DOORS  
                                                        
                                                
                                                                    ";
                Console.WriteLine(Inventory);
                string[] inventory2 = { "ENGINES", "INCAP PARTS", "WINDOWS", "DOORS" };




                int answer = int.Parse(Console.ReadLine());
                string Itemselected = inventory2[answer];

                string clientname = findclient.name;
                int clientstore = findclient.storeid;
                Console.WriteLine(clientname);


                switch (answer)
                {
                    case 0:
                        Console.WriteLine("Number of Engines .\n");
                        int ENGINES = int.Parse(Console.ReadLine());
                        Console.WriteLine($"I confirm the you need {ENGINES} {Itemselected}(y/n)\n\n?");
                        char ans2 = char.Parse(Console.ReadLine());
                        if (ans2.Equals('n')) { break; }


                        if (ans2.Equals('y'))
                        {
                            if (ENGINES > Engines)
                            {
                                Console.WriteLine($"the amount you requested is more of our inventory: ENGINES: {Engines}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine(clientname);
                                findclient.inventory3(clientstore, clientname, -ENGINES, 0, 0, 0, DateTime.Now);
                                connection.companytransactions(clientstore, clientname, -ENGINES, 0, 0, 0, DateTime.Now);
                                Thread.Sleep(500);
                                break;
                            }
                        }



                        break;

                    case 1:
                        Console.WriteLine("Number of incap parts .\n");
                        int INCAPPARTS1 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"I confirm the you need {INCAPPARTS1} {Itemselected}(y/n)\n\n?");
                        char ans3 = char.Parse(Console.ReadLine());
                        if (ans3.Equals('n')) { break; }


                        if (ans3.Equals('y'))
                        {
                            if (INCAPPARTS1 > INCAPPARTS)
                            {
                                Console.WriteLine($"the amount you requested is more of our inventory: ENGINES: {INCAPPARTS}");
                                break;
                            }
                            else
                            {
                                findclient.inventory3(clientstore, clientname, 0, -INCAPPARTS1, 0, 0, DateTime.Now);
                                connection.companytransactions(clientstore, clientname, 0, -INCAPPARTS1, 0, 0, DateTime.Now);
                                Thread.Sleep(500);
                                break;
                            }
                        }

                        break;

                    case 2:
                        Console.WriteLine("Number of Windows .\n");
                        int WINDOWS1 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"I confirm the you need {WINDOWS1} {Itemselected}(y/n)\n\n?");
                        char ans4 = char.Parse(Console.ReadLine());
                        if (ans4.Equals('n')) { break; }


                        if (ans4.Equals('y'))
                        {
                            if (WINDOWS1 > WINDOWS)
                            {
                                Console.WriteLine($"the amount you requested is more of our inventory: ENGINES: {WINDOWS}");
                                break;
                            }
                            else
                            {
                                findclient.inventory3(clientstore, clientname, 0, 0, -WINDOWS1, 0, DateTime.Now);
                                connection.companytransactions(clientstore, clientname, 0, 0, -WINDOWS1, 0, DateTime.Now);
                                Thread.Sleep(500);
                                break;
                            }
                        }

                        break;

                    case 3:
                        Console.WriteLine("Number of Doors .\n");
                        int DOORS1 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"I confirm the you need {DOORS1} {Itemselected}(y/n)\n\n?");
                        char ans5 = char.Parse(Console.ReadLine());
                        if (ans5.Equals('n')) { break; }


                        if (ans5.Equals('y'))
                        {
                            if (DOORS1 > DOORS)
                            {
                                Console.WriteLine($"the amount you requested is more of our inventory: ENGINES: {DOORS}");
                                break;
                            }
                            else
                            {
                                findclient.inventory3(clientstore, clientname, 0, 0, 0, -DOORS1, DateTime.Now);
                                connection.companytransactions(clientstore, clientname, 0, 0, 0, -DOORS1, DateTime.Now);
                                Thread.Sleep(500);
                                break;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("you didn't select a proper option, please try again.");
                        break;

                }

                break;

            }
            return;
        }



        public void lookforsupplaier()
        {
            Console.WriteLine("Please, type your client ID :\n\n");
            int suppliertID = int.Parse(Console.ReadLine());
            var findsupplier = supplier.Find(x => x.item == suppliertID);
            while (true)
            {
                Console.WriteLine($"Welcome {findsupplier.name}\n\n");
                Console.WriteLine($"The following items are required by the store:\n");
                Console.WriteLine($"\n ENGINES: {30 - Engines} \n INCAP PARTS: {30 - INCAPPARTS} \n WINDOWS: {30 - WINDOWS} \n DOORS: {30 - DOORS}");
                Console.WriteLine("\n\nPlease, let us know what do you have available : \n\n\n");

                string supplyInventory =
         @" From our menu, select the product that you have: 
 
           [0] ENGINES  
           [1] INCAP PARTS  
           [2] WINDOWS 
           [3] DOORS  
                                                        
                                                
                                                                                ";
                Console.WriteLine(supplyInventory);


                string[] inventory4 = { "ENGINES", "INCAP PARTS", "WINDOWS", "DOORS" };

                string suppliername = findsupplier.name;
                int supplierstore = findsupplier.storeid;
                Console.WriteLine(suppliername);




                int answer2 = int.Parse(Console.ReadLine());
                string Itemselected = inventory4[answer2];




                switch (answer2)
                {
                    case 0:
                        Console.WriteLine($"I confirm that you have in your inventory {30 - Engines} {Itemselected} ?.(y/n)\n\n\n");
                        char ans2 = char.Parse(Console.ReadLine());
                        if (ans2.Equals('n')) { break; }


                        if (ans2.Equals('y'))
                        {

                            Console.WriteLine(suppliername);
                            connection.companytransactions(supplierstore, suppliername, (30 - Engines), 0, 0, 0, DateTime.Now);
                            findsupplier.inventory3(supplierstore, suppliername, (30 - Engines), 0, 0, 0, DateTime.Now);

                            Thread.Sleep(500);
                            break;

                        }

                        break;

                    case 1:
                        Console.WriteLine($"I confirm that you have in your inventory {30 - INCAPPARTS} {Itemselected} ?.(y/n)\n\n\n");
                        char ans3 = char.Parse(Console.ReadLine());
                        if (ans3.Equals('n')) { break; }
                        if (ans3.Equals('y'))
                        {

                            Console.WriteLine(suppliername);
                            connection.companytransactions(supplierstore, suppliername, 0, (30 - INCAPPARTS), 0, 0, DateTime.Now);
                            findsupplier.inventory3(supplierstore, suppliername, 0, (30 - INCAPPARTS), 0, 0, DateTime.Now);

                            Thread.Sleep(500);
                            break;

                        }
                        break;
                    case 2:
                        Console.WriteLine($"I confirm that you have in your inventory {30 - WINDOWS} {Itemselected} ?.(y/n)\n\n\n");
                        char ans4 = char.Parse(Console.ReadLine());
                        if (ans4.Equals('n')) { break; }
                        if (ans4.Equals('y'))
                        {

                            Console.WriteLine(suppliername);
                            connection.companytransactions(supplierstore, suppliername, 0, 0, 30 - WINDOWS, 0, DateTime.Now);
                            findsupplier.inventory3(supplierstore, suppliername, 0, 0, 30 - WINDOWS, 0, DateTime.Now);

                            Thread.Sleep(500);
                            break;

                        }
                        break;
                    case 3:
                        Console.WriteLine($"I confirm that you have in your inventory {30 - DOORS} {Itemselected} ?.(y/n)\n\n\n");
                        char ans5 = char.Parse(Console.ReadLine());
                        if (ans5.Equals('n')) { break; }
                        if (ans5.Equals('y'))
                        {

                            Console.WriteLine(suppliername);
                            connection.companytransactions(supplierstore, suppliername, 0, 0, 0, 30 - DOORS, DateTime.Now);
                            findsupplier.inventory3(supplierstore, suppliername, 0, 0, 0, 30 - DOORS, DateTime.Now);

                            Thread.Sleep(500);
                            break;

                        }
                        break;
                    default:
                        Console.WriteLine("you didn't select a proper option, please try again.");
                        break;
                }
                break;

            }
            return;
        }

        public void record()
        {
            var reacod = inventory.OrderByDescending(x => x.name);
            foreach (var item1 in inventory)
            {
                Console.WriteLine($" {item1.name}  {item1.Engines} {item1.INCAPPARTS} {item1.WINDOWS} {item1.DOORS} {item1.timetransaction}");

            }
        }
    }







}