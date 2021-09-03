namespace Assignment.Interfaces
{
    //The specification of MovieCollection ADT, which is used to store and manipulate a collection of movies
    interface IMovieCollection
    {
        // get the number of movies in the community library
        int Number { get; }
        //add a given movie to this tool collection
        void add(IMovie aMovie);
        //delete a given movie from this movie collection
        void delete(IMovie aMovie);
        //search a given movie in this movie collection. Return IMovie if this movie is in the movie collection; return null otherwise
        IMovie search(IMovie aMovie);
        //remove all the movies in this movie collection
        void clear();
        //output the movies in this collection to an array of iMovies
        IMovie[] toArray(); 
    }
}