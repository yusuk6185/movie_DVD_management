using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Interfaces;

namespace Assignment
{
    class Member : IMember
    {
        //get and set the first name of this member
        public string FirstName { get; set; }
        //get and set the last name of this member
        public string LastName { get; set; }
        //get and set the contact number of this member
        public string ContactNumber { get; set; }
        //get and set a four-digit pin number
        public int Pin { get; set; }
        //get a list of movies that this memebr is currently borrowing
        public string[] getBorrowingMovieDVDs => _borrowings.toArray().Select(i => i.Title).ToArray();

        IMovieCollection _borrowings;

        //add a given movie DVD to the list of movies DVDs that this member is currently holding
        public void addMovie(IMovie aMovie)
        {
            if (_borrowings.search(aMovie) == null) _borrowings.add(aMovie);
        }
        //delete a given movie DVD from the list of movie DVDs that this member is currently holding
        public void deleteMovie(IMovie aMovie)
        {
            _borrowings.delete(aMovie);
        }
        // return a string containing the first name, last name and contact number of this memeber 
        public override string ToString()
        {
            return $" ========== Member Information ========== \r\n" +
                   $" First Name : {FirstName} \r\n" +
                   $" Last Name : {LastName} \r\n" +
                   $" Contact Number : {ContactNumber} \r\n" +
                   $" Borrowing Movie Count : {_borrowings.Number} \n\n" +
                   $" ======================================== \r\n";
        }

        public Member()
        {
            _borrowings = new MovieCollection();
        }
        public Member(string first, string last, string contact, int pin) : this()
        {
            FirstName = first;
            LastName = last;
            ContactNumber = contact;
            Pin = pin;
        }
    }
}
