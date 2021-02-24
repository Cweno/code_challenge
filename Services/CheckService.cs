using System.Collections.Generic;
using back.Models;

namespace back.Services
{
    public class CheckService
    {

        List<Check> checkList = null;
        Check dafultCheck = null;

        

        public CheckService()
        {
            //passing vales fromt he table into a list of class objects
            checkList = new List<Check>();
            checkList.Add (new Check("NY", "08", "18", "45", 150) );
            checkList.Add (new Check("NY", "01", "46", "65", 200.50) );
            checkList.Add (new Check("NY", "*" , "18", "65", 120.99) );
            checkList.Add (new Check("AL", "11", "18", "65", 85.5) );
            checkList.Add (new Check("AL", "*" , "18", "65", 100) );
            checkList.Add (new Check("AK", "12", "65", "*" , 175.2) );
            checkList.Add (new Check("AK", "12", "18", "64", 125.16) );
            checkList.Add (new Check("AK", "*" , "18", "65", 100.80) );

            dafultCheck = new Check("*", "*", "18", "65", 90);
        }

        public List<Check> GetChecks(){
            return checkList;
        }

        public Check getDefault()
        {
            return dafultCheck;
        }
    }

}
