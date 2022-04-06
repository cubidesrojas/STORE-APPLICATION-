namespace logic
{
    public class customer : company

    {
        public int item { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }

        public int Engines { get; set; }
        public DateTime timetransaction { get; set; }
        public int storeid { get; set; }

        public int INCAPPARTS { get; set; }
        public int WINDOWS { get; set; }
        public int DOORS { get; set; }



        public customer(int storeid, string name, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction)
        {
            this.Engines = Engines;
            this.INCAPPARTS = INCAPPARTS;
            this.WINDOWS = WINDOWS;
            this.DOORS = DOORS;
            this.timetransaction = timetransaction;
            this.name = name;

        }
        public customer(int storeid, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction)
        {
            this.Engines = Engines;
            this.INCAPPARTS = INCAPPARTS;
            this.WINDOWS = WINDOWS;
            this.DOORS = DOORS;
            this.timetransaction = timetransaction;


        }
        public customer(int storeid, string name, string lastname, int item)
        {
            this.name = name;
            this.lastname = lastname;
            this.item = item;
            this.storeid = storeid;
        }



        public override void getorders()
        {
            Console.Clear();
            //     Console.WriteLine("welcome dear customer, here is our menu");


            //     string Inventory = @" From our menu, select the product that you need. 
            //                             [0] ENGINES  
            //                             [1] INCAP PARTS  
            //                             [2] WINDOWS 
            //                             [3] DOORS  


            //                          ";
            //     Console.WriteLine(Inventory);
            //     string [] inventory2 = {"ENGINES", "INCAP PARTS", "WINDOWS", "DOORS"};




            //     int answer = int.Parse(Console.ReadLine());
            //     string Itemselected = inventory2[answer];


            //     switch (answer){


            //                     case 0: 
            //                           Console.WriteLine ("Number of Engines .\n");
            //                           int ENGINES= Int32.Parse(Console.ReadLine());

            //                           .inventory3(-ENGINES, 0 , 0 , 0);


            //                           Console.WriteLine($"I confirm the you need {ENGINES} {Itemselected}?");


            //                           Thread.Sleep(500);


            //                     break;













            // Console.WriteLine("hoy many items do you need ?");
            // int Items = int.Parse(Console.ReadLine());


            //     // this will be the number the Items that client needs 





            // // public abstract void registerpersonal ();


            // // public abstract void materialsupplies();
            // return;

        }

    }

}













