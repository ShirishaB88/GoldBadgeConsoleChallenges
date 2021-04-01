using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimsRepoistory
    {
        //Creating empty Queue

        protected readonly Queue<Claims> _claimsQueue = new Queue<Claims>();
        
        //Create Methods..... Add new claims to the Queue
        public bool AddClaimsToTheQueue(Claims claimItem)
        {
            //int startingCount = _claimsQueue.Count();

            _claimsQueue.Enqueue(claimItem);

            return true; 
        }


        //Read Methods ..... Get the claims alredy in the Queue

        public Queue<Claims> GetAllClaims()
        {
            return _claimsQueue;
        }

       public Claims ViewNextClaim()
       {
            Claims claim;
            if (_claimsQueue.Count > 0)
            {
                claim = _claimsQueue.Peek();
                return claim;
            }
            return null;
       }

        public bool ProcessClaim()
        {
            if (_claimsQueue.Count > 0)
            {
                _claimsQueue.Dequeue();

                return true;
            }

            return false;
        }
       
    }
}
