namespace Assignment.Interfaces
{
    //The specification of Movie ADT
    interface IMovie
    {
        // get and set the tile of this movie
        string Title { get; set; }
        //get and set the genre of this movie
        string Genre { get; set; }
        //get and set the classification of this movie
        int Classification { get; set; }
        //get and set the duration of this movie
        int Duration { get; set; }
        //get and set the number of the copies of this movie currently available to lend
        int AvailableCopies { get; set; }
        //get and set the number of times that this movie has been borrowed
        int NoBorrowings { get; set; }

        //get all the members who are currently holding this tool
        IMemberCollection getBorrowers { get; }

        //add a member to the borrower list
        void addBorrower(IMember aMember);
        //delte a member from the borrower list
        void deleteBorrower(IMember aMember);
        //return a string containning the title, genre, classification, duration, and the number of copies of this movie currently in the community library 
        string ToString(); 
    }
}