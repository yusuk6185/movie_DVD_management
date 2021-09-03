// This file has not updated yet

using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Interfaces
{
    interface ILibrarySystem
    {
        // add DVDs of a new movie to the system
        void add(IMovie aMovie);
        //add new DVDs of an existing movie to the system
        void add(IMovie aMovie, int quantity);
        //remove a given movie from the system
        void delete(IMovie aMovie);
        //add a new memeber to the system
        void add(IMember aMember);
        //delete a member from the system
        void delete(IMember aMember);
        //given a member's first name and last name, find the contact phone number of this member
        string[] getConnectPhone(string firstname, string lastname);
        //given the title of a movie, return all thoe memebrs wo are currently borrowing that movie
        IMemberCollection getBorrowers(string movieTitle);


        //display the information about all the movies in the library
        void displayAllMovies();
        //display all the information about about amovie, given the title of the movie 
        void displayOneMovie(string movieTitle);
        //a member borrows a movie DVD from the library
        void borrowMovie(IMember aMember, IMovie aMovie);
        //a member returns a movie DVD to the library
        void returnMovie(IMember aMember, IMovie aMovie);
        //get a list of movie DVDs that are currently held by a given member
        string[] getMovieDVDs(IMember aMember);
        //Display top three most frequently borrowed movies by the members in the library in the descending order by the number of times the movie has been borrowed.
        void displayTop3(); 

    }
}
