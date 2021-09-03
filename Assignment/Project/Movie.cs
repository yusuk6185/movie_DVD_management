using Assignment.Interfaces;
using System;

namespace Assignment
{
    class Movie : IMovie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Classification { get; set; }
        public int Duration { get; set; }
        public int AvailableCopies { get; set; }
        public int NoBorrowings { get; set; }

        public int BorrowCount => _borrowCount;
        //get all the members who are currently holding this tool
        public IMemberCollection getBorrowers => _borrowers;

        IMemberCollection _borrowers;

        //add a member to the borrower list
        public void addBorrower(IMember aMember)
        {
            _borrowers.add(aMember);
            _borrowCount++;
        }
        //delete a member from the borrower list
        public void deleteBorrower(IMember aMember)
        {
            _borrowers.delete(aMember);
        }
        //return a string containning the title, genre, classification, duration, and the number of copies of this movie currently in the community library 
        public override string ToString()
        {
            return $" Title : {Title} \n" +
                   $" Genre : {Genre} \n" +
                   $" Classification : {toClassification(Classification)} \n" +
                   $" Duration : {Duration} \n" +
                   $" Available Copies : {AvailableCopies - NoBorrowings}";
        }

        private int _borrowCount = 0;

        private string toClassification(int c)
        {
            switch (c)
            {
                case 0:
                    return "G";
                case 1:
                    return "PG";
                case 2:
                    return "M15+";
                case 3:
                    return "MA15+";
            }
            return "";
        }
        public Movie()
        {
            _borrowers = new MemberCollection();
        }
        public Movie(string title, string genre, int classification, int duration, int availableCopies) : this()
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            AvailableCopies = availableCopies;
        }
    }
}
