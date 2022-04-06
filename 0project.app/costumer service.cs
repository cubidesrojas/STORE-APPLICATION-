using System;
using System.Xml.Serialization;
using System.IO;
using _0Project;

namespace _0Project
{
    public class customerassistant : company
    {



        private string name;
        private string lastname;

        private string role = "CUSTOMER";
        public customerassistant(int storeid, string name, string lastname, string role)
        {
            this.name = name;
            this.role = role;
            this.lastname = lastname;


        }





        public override void getorders() { Console.WriteLine("test"); }







    }
}
