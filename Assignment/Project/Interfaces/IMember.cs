namespace Assignment.Interfaces
{
    //The specification of Member ADT
    interface IMember
    {
        //get and set the first name of this member
        string FirstName { get; set; }
        //get and set the last name of this member
        string LastName { get; set; }
        //get and set the contact number of this member
        string ContactNumber { get; set; }
        //get and set a four-digit pin number
        int Pin { get; set; }
        //get a list of movies that this memebr is currently borrowing
        string[] getBorrowingMovieDVDs { get; }

        //add a given movie DVD to the list of movies DVDs that this member is currently holding
        void addMovie(IMovie aMovie);
        //delete a given movie DVD from the list of movie DVDs that this member is currently holding
        void deleteMovie(IMovie aMovie);
        // return a string containing the first name, last name and contact number of this memeber 
        string ToString();
    }
}
