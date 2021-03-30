using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public enum ClaimType {Car, Home, Theft};
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get
            {
                DateTime dateOfIncident = new DateTime();
                DateTime dateOfClaim = new DateTime();
                TimeSpan timeSpan = dateOfIncident - dateOfClaim;
                int daysToClaim = Convert.ToInt32(timeSpan.TotalDays);

               if(daysToClaim <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }

        }
        
        public Claims()
        {

        }

        public Claims(int claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
           
        }
    }
}
