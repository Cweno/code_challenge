using System;
namespace back.Models
{
    public class Check
    {
        public string State{get; set;}
        public string MonthOfBirth{get; set;}
        public string MaxAge{get; set;}
        public string MinAge{get; set;}

        public double Premium{get; set;}

        public Check(string state, string month, string min, string max, double premium)
        {
            this.State = state;
            this.MonthOfBirth = month;
            this.MaxAge = max;
            this.MinAge = min;
            this.Premium = premium;
        }

        public bool checker(Premium premium)
        {
            if(String.Equals(this.State, "*") | String.Equals(this.State, premium.State) )
            {
                if(String.Equals(this.MonthOfBirth, "*") | String.Equals(this.MonthOfBirth, premium.DateOfBirth.Substring(5,2)) )
                {
                    if(String.Equals(this.MaxAge, "*") | (Int32.Parse(this.MinAge) <= Int32.Parse(premium.Age) &  (String.Equals(this.MaxAge,"*") ? 121 : Int32.Parse(this.MaxAge) )  >= Int32.Parse(premium.Age) ) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}