namespace Assignment.Interfaces
{
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members
    interface IMemberCollection
    {
        // get the number of members in the community library
        int Number { get; }
        //add a new member to this member collection, make sure there are no duplicates in the member collection
        void add(IMember aMember);
        //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        void delete(IMember aMember);
        //search a given member in this member collection. Return IMember if this memeber is in the member collection; return null otherwise
        IMember search(IMember aMember);
        // remove all the members in this member collection
        void clear();
        //output the memebers into an array of iMember 
        IMember[] toArray();
    }
}
