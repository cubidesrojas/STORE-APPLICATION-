using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace retailstoredata.sql
{
    public interface Iretailstore
    {

        /* IEnumerable<customer> getinventory();*/
        public void companytransactions(int storeid, string name, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction);

        public List<retailstoresql> getinventory(int storeid);


        public void endinventory(int storeid, int Engines, int INCAPPARTS, int WINDOWS, int DOORS, DateTime timetransaction);

        public void registercustomers(int storeid, string name, string lastname, int item);

        public List<retailstoresql> getcustomerlist(int storeid);

        public void registersuppliers(int storeid, string name, string lastname, int item);

        public List<retailstoresql> getsupplierlist(int storeid);




    }
}