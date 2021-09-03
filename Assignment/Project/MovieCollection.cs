using Assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class MovieCollection : IMovieCollection
    {
        // get the number of movies in the community library
        public int Number => _movies.Count;

        Hashtable _movies;

        //add a given movie to this tool collection
        public void add(IMovie aMovie)
        {
            _movies.Add(aMovie.Title.ToUpper(), aMovie);
        }
        //delete a given movie from this movie collection
        public void delete(IMovie aMovie) 
        {
            _movies.Remove(aMovie.Title.ToUpper());
        }
        //search a given movie in this movie collection. Return true if this movie is in the movie collection; return false otherwise
        public IMovie search(IMovie aMovie) 
        {
            if (_movies.ContainsKey(aMovie.Title.ToUpper())) return _movies[aMovie.Title.ToUpper()] as IMovie;

            return null;
        }
        //remove all the movies in this movie collection
        public void clear() 
        {
            _movies.Clear();
        }
        //output the movies in this collection to an array of iMovies
        public IMovie[] toArray() 
        {
            var movies = new IMovie[_movies.Count];
            var index = 0;

            foreach (object key in _movies.Keys) movies[index++] = (IMovie)_movies[key];
            return movies;
        }

        public MovieCollection()
        {
            _movies = new Hashtable();
        }
    }
}
