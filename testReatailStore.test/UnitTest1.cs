using Xunit;
using System;

using logic;

namespace testReatailStore.test
{
    public class UnitTest1
    {




        [Fact]
        public void Test1()
        {
            Assert.Equal(true, true);
        }

        [Fact]


        public void company_registerclient_validregisterclient()
        {

            // ARRANGE 
            string expected = "carlos";


            //ACT 
            customerassistant tester = new customerassistant("Andres", "camargo", "EMPLOYEE");
            tester.register(1, "carlos", "camargo", 15);

            var findclient = (tester.getlist()).Find(x => x.item == 15);


            //ASSEERT

            Assert.Equal(findclient.name, expected);

        }

        [Fact]
        public void company_buyingitems_validbuyingengines()
        {

            // ARRANGE 
            int expected = -8;


            //ACT 
            customerassistant tester = new customerassistant("Andres", "camargo", "EMPLOYEE");
            tester.register(1, "carlos", "camargo", 15);

            var findclient = (tester.getlist()).Find(x => x.item == 15);

            DateTime timet = DateTime.Now;
            findclient.inventory3(1, "Andres", -8, 0, 0, 0, timet);


            //ASSEERT

            Assert.Equal(findclient.getengines(), expected);

        }


        [Fact]
        public void company_buyingitems_validbuyingicapparts()
        {

            // ARRANGE 
            int expected = -8;


            //ACT 
            customerassistant tester = new customerassistant("Andres", "camargo", "EMPLOYEE");
            tester.register(1, "carlos", "camargo", 15);

            var findclient = (tester.getlist()).Find(x => x.item == 15);

            DateTime timet = DateTime.Now;
            findclient.inventory3(1, "Andres", 0, -8, 0, 0, timet);


            //ASSEERT

            Assert.Equal(findclient.getincapparts(), expected);

        }

        [Fact]
        public void company_buyingitems_validbuyingWINDOWS()
        {

            // ARRANGE 
            int expected = -8;


            //ACT 
            customerassistant tester = new customerassistant("Andres", "camargo", "EMPLOYEE");
            tester.register(1, "carlos", "camargo", 15);

            var findclient = (tester.getlist()).Find(x => x.item == 15);

            DateTime timet = DateTime.Now;
            findclient.inventory3(1, "Andres", 0, 0, -8, 0, timet);


            //ASSEERT

            Assert.Equal(findclient.getwindows(), expected);

        }

        [Fact]
        public void company_buyingitems_validbuyingDOORS()
        {

            // ARRANGE 
            int expected = -8;


            //ACT 
            customerassistant tester = new customerassistant("Andres", "camargo", "EMPLOYEE");
            tester.register(1, "carlos", "camargo", 15);

            var findclient = (tester.getlist()).Find(x => x.item == 15);

            DateTime timet = DateTime.Now;
            findclient.inventory3(1, "Andres", 0, 0, 0, -8, timet);


            //ASSEERT

            Assert.Equal(findclient.getdoors(), expected);

        }


    }


}