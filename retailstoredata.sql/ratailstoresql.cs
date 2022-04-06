
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace retailstoredata.sql
{
    public class retailstoresql : Iretailstore

    {
        //fields 

        readonly string stringconnection;
        public int Engines;
        public int INCAPPARTS;
        public int WINDOWS;
        public int DOORS;
        public string name;
        public string lastname;
        public int item;
        DateTime time;
        public int storeid;
        //constructor 

        public retailstoresql(string stringconnection)
        {
            this.stringconnection = stringconnection ?? throw new ArgumentNullException(nameof(stringconnection));

        }

        public retailstoresql(int storeid, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime time)

        {
            this.Engines = Engines;
            this.INCAPPARTS = INCAPPARTS;
            this.WINDOWS = WINDOWS;
            this.DOORS = DOORS;
            this.storeid = storeid;

        }

        public retailstoresql(int storeid, string name, string lastname, int item)
        {
            this.name = name;
            this.lastname = lastname;
            this.item = item;
            this.storeid = storeid;
        }

        //methods 


        public void companytransactions(int storeid, string name, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction)
        {

            // List<customer> transactions = new List<customer>() { new customer("christian", 20, 20, 20, 20, DateTime.Now) };
            using (SqlConnection connection = new SqlConnection(this.stringconnection))
            {
                string customer_name;
                connection.Open();

                string cmdText =
                    "INSERT INTO company.transactions (storeid,customer_name,sold_Engines, sold_incapparts,sold_windows, sold_doors, DATETIME)" +
                     @"VALUES (@storeid,@name,@Engines,@INCAPPARTS,@WINDOWS, @DOORS, @timetransaction) ";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);

                cmd.Parameters.AddWithValue("@storeid", storeid);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@Engines", Engines);
                cmd.Parameters.AddWithValue("@INCAPPARTS", INCAPPARTS);
                cmd.Parameters.AddWithValue("@WINDOWS", WINDOWS);
                cmd.Parameters.AddWithValue("@DOORS", DOORS);
                cmd.Parameters.AddWithValue("@timetransaction", timetransaction);




                cmd.ExecuteNonQuery();

                connection.Close();
            }



        }


        public void registercustomers(int storeid, string name, string lastname, int item)
        {
            using (SqlConnection connection = new SqlConnection(this.stringconnection))
            {

                connection.Open();

                string cmdText =
                    "INSERT INTO company.customer (storeid, customer_name,customer_lastname, custome_id)" +
                     @"VALUES (@storeid,@customer_name,@customer_lastname,@custome_id) ";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);


                cmd.Parameters.AddWithValue("@storeid", storeid);
                cmd.Parameters.AddWithValue("@customer_name", name);
                cmd.Parameters.AddWithValue("@customer_lastname", lastname);
                cmd.Parameters.AddWithValue("@custome_id", item);





                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }


        public void registersuppliers(int storeid, string name, string lastname, int item)
        {
            using (SqlConnection connection = new SqlConnection(this.stringconnection))
            {

                connection.Open();

                string cmdText =
                    "INSERT INTO company.suppliers (storeid, supplier_name,supplier_lastname, supplier_id)" +
                     @"VALUES (@storeid,@supplier_name,@supplier_lastname,@supplier_id) ";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);


                cmd.Parameters.AddWithValue("@storeid", storeid);
                cmd.Parameters.AddWithValue("@supplier_name", name);
                cmd.Parameters.AddWithValue("@supplier_lastname", lastname);
                cmd.Parameters.AddWithValue("@supplier_id", item);





                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<retailstoresql> getinventory(int storeid)
        {

            List<retailstoresql> inventory = new List<retailstoresql>();

            using SqlConnection connection = new SqlConnection(this.stringconnection);
            connection.Open();

            using SqlCommand cmd = new SqlCommand(@"Select * from company.inventory where storeid = @storeid", connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int storeid1 = reader.GetInt32(0);
                int Engines = reader.GetInt32(1);
                int INCAPPARTS = reader.GetInt32(2);
                int WINDOWS = reader.GetInt32(3);
                int DOORS = reader.GetInt32(4);
                var inventory1 = new retailstoresql(storeid1, Engines, INCAPPARTS, WINDOWS, DOORS, DateTime.Now);
                inventory.Add(inventory1);

            }

            connection.Close();
            return inventory;

        }


        public List<retailstoresql> getcustomerlist(int storeid)
        {
            List<retailstoresql> customers = new();

            using SqlConnection connection = new SqlConnection(this.stringconnection);
            connection.Open();

            using SqlCommand cmd = new(@"Select * from company.customer  Where storeid = @storeid;", connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int storeid2 = reader.GetInt32(0);
                string name = reader.GetString(1);
                string lastname = reader.GetString(2);
                int item = reader.GetInt32(3);
                customers.Add(new(storeid2, name, lastname, item));
            }
            connection.Close();

            return customers;
        }


        public List<retailstoresql> getsupplierlist(int storeid)
        {
            List<retailstoresql> suppliers = new();

            using SqlConnection connection = new SqlConnection(this.stringconnection);
            connection.Open();

            using SqlCommand cmd = new(@"Select * from company.suppliers  Where storeid = @storeid;", connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int storeid3 = reader.GetInt32(0);
                string name = reader.GetString(1);
                string lastname = reader.GetString(2);
                int item = reader.GetInt32(3);
                suppliers.Add(new(storeid3, name, lastname, item));
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();

            return suppliers;
        }

        public void endinventory(int storeid, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction)
        {

            // List<customer> transactions = new List<customer>() { new customer("christian", 20, 20, 20, 20, DateTime.Now) };
            using (SqlConnection connection = new SqlConnection(this.stringconnection))
            {
                string customer_name;
                connection.Open();

                string cmdText =
                    @"update company.inventory
                    set engines = @Engines,
                        incapparts = @INCAPPARTS,
                        windows = @WINDOWS,
                        doors = @DOORS
                    where storeid = @storeid";

                using SqlCommand cmd = new SqlCommand(cmdText, connection);


                cmd.Parameters.AddWithValue("@storeid", storeid);
                cmd.Parameters.AddWithValue("@Engines", Engines);
                cmd.Parameters.AddWithValue("@INCAPPARTS", INCAPPARTS);
                cmd.Parameters.AddWithValue("@WINDOWS", WINDOWS);
                cmd.Parameters.AddWithValue("@DOORS", DOORS);





                cmd.ExecuteNonQuery();

                connection.Close();
            }



        }

    }




}

