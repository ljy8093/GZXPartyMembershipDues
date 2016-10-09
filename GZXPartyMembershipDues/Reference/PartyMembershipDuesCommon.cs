using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZXPartyMembershipDues.Reference
{
    public class PartyMembershipDuesCommon
    {
        public double DueRate(double salary)
        {
            if (salary <= 3000)
                return 0.005;
            else if (salary <= 5000)
                return 0.01;
            else if (salary <= 10000)
                return 0.015;
            else
                return 0.02; 
        }
    }
}
