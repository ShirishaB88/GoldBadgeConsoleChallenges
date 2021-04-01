using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgesRepository
    {
        private Dictionary<int, Badges> _badgesDict = new Dictionary<int,Badges>();

        int _count = 0;
        //Create

        public bool AddNewBadgesToTheDictinary(Badges newBadge)
        {
          
            _count++;
            _badgesDict.Add( _count, newBadge);
           
            return true;

        }
        //Read

        public Dictionary<int,Badges> GetAllBadges()
        {
            return _badgesDict;
        }

        //HelperMethod

       public Badges GetBadgesByTheKey(int badgeKey)
       {
            foreach (var item in _badgesDict)
            {
                if(item.Key == badgeKey)
                {
                    return item.Value;
                }
            }
            return null;
       }

        
        //Update

        public bool UpdateExistingBadges(int badgeKey, Badges newBadge)
        {
            Badges oldBadge = GetBadgesByTheKey(badgeKey);
            if(oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.BadgeDoors = newBadge.BadgeDoors;
                return true;
               
            }
            else
            {
                return false;
            }


        }

        //Delete

        public bool DeleteAllDoorsFromAnExistingBadge(int badgeKey)
        {
            Badges existingBadge = GetBadgesByTheKey(badgeKey);



            if (existingBadge != null)
            {

                //existingBadge.BadgeDoors = null;

                existingBadge.BadgeDoors.Clear();

                return true;
            }
            else
            {
                return false;

            }






        }


    }
}
