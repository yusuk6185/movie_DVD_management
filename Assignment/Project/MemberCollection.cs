using Assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members
    class MemberCollection : IMemberCollection
    {
        int memberCount;
        IMember[] members;

        // get the number of members in the community library
        public int Number => memberCount;

        //add a new member to this member collection, make sure there are no duplicates in the member collection
        public void add(IMember aMember)
        {
            if (memberCount == members.Length) extendSize();

            members[memberCount++] = aMember;
        }

        //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        public void clear()
        {
            throw new NotImplementedException();
        }

        // remove all the members in this member collection
        public void delete(IMember aMember)
        {
            int i;
            for(i = 0; i < memberCount; i++)
            {
                if (members[i] == aMember) break;
            }

            if (i == memberCount) return;

            for (; i < memberCount - 1; i++)
            {
                members[i] = members[i + 1];
            }

            members[i] = null;
            memberCount--;
        }

        //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise
        public IMember search(IMember aMember)
        {
            for (var i = 0; i < memberCount; i++)
            {
                if (members[i] == aMember || members[i].ContactNumber == aMember.ContactNumber || (members[i].FirstName == aMember.FirstName && members[i].LastName == aMember.LastName) ) return members[i];
            }

            return null;
        }

        //output the memebers into an array of iMember 
        public IMember[] toArray()
        {
            IMember[] newMembers = new IMember[memberCount];
            for (var i = 0; i < memberCount; i++) newMembers[i] = members[i];
            return newMembers;
        }

        public MemberCollection()
        {
            memberCount = 0;
            members = new IMember[10];
        }

        private void extendSize()
        {
            IMember[] newMembers = new IMember[members.Length * 2];
            for (var i = 0; i < members.Length; i++) newMembers[i] = members[i];
            members = newMembers;
        }
    }
}
