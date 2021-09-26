using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<string, Movie> movies = new Dictionary<string, Movie>();
        private Dictionary<string, Dictionary<string, HashSet<Movie>>> moviesWithActors = new Dictionary<string, Dictionary<string, HashSet<Movie>>>();

        public int Count => this.movies.Count;

        public void AddMovie(Movie movie)
        {
            if (!this.movies.ContainsKey(movie.Id))
            {
                this.movies.Add(movie.Id, movie);
                this.moviesWithActors.Add(movie.Id, new Dictionary<string, HashSet<Movie>>());
                foreach (var actor in movie.Actors)
                {
                    if (!this.moviesWithActors[movie.Id].ContainsKey(actor))
                    {
                        this.moviesWithActors[movie.Id].Add(actor, new HashSet<Movie>());
                    }

                    if (!this.moviesWithActors[movie.Id][actor].Contains(movie))
                    {
                        this.moviesWithActors[movie.Id][actor].Add(movie);
                    }
                }
            }
        }

        public bool Contains(Movie movie)
        {
            return this.movies.ContainsKey(movie.Id);
        }

        public IEnumerable<Movie> GetAllMoviesOrderedByActorPopularityThenByRatingThenByYear()
        {
            if (this.movies.Count() == 0)
            {
                return new List<Movie>();
            }

            return this.movies
                .Select(x => x.Value)
                .OrderByDescending(x => x.Actors.Count())
                .ThenByDescending(x => x.Rating)
                .ThenByDescending(x => x.ReleaseYear)
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesByActor(string actorName)
        {
            var returnedMovies = this.movies
                .Select(x => x.Value)
                .Where(x => x.Actors.Contains(actorName))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.ReleaseYear)
                .ToList();

            if (returnedMovies.Count() == 0)
            {
                throw new ArgumentException();
            }

            return returnedMovies;
        }



        public IEnumerable<Movie> GetMoviesByActors(List<string> actors)
        {
            var returnedMovies = new List<Movie>();

            foreach (var movie in this.movies.Values)
            {
                var isTrue = true;

                foreach (var actorName in actors)
                {
                    if (!movie.Actors.Contains(actorName))
                    {
                        isTrue = false;
                        break;
                    }
                }

                if (isTrue)
                {
                    returnedMovies.Add(movie);
                }
            }

            if (returnedMovies.Count() == 0)
            {
                throw new ArgumentException();
            }

            return returnedMovies
                    .OrderByDescending(x => x.Rating)
                    .ThenByDescending(x => x.ReleaseYear)
                    .ToList();
        }

        public IEnumerable<Movie> GetMoviesByYear(int releaseYear)
        {
            var returnedMovies = this.movies
                .Select(x => x.Value)
                .Where(x => x.ReleaseYear == releaseYear)
                .OrderByDescending(x => x.Rating)
                .ToList();

            if (returnedMovies.Count() == 0)
            {
                return new List<Movie>();
            }

            return returnedMovies;
        }

        public IEnumerable<Movie> GetMoviesInRatingRange(double lowerBound, double upperBound)
        {
            var returnedMovies = this.movies
                .Select(x => x.Value)
                .Where(x => x.Rating >=lowerBound && x.Rating <= upperBound)
                .OrderByDescending(x => x.Rating)
                .ToList();

            if (returnedMovies.Count() == 0)
            {
                return new List<Movie>();
            }

            return returnedMovies;
        }

        public void RemoveMovie(string movieId)
        {
            if (!this.moviesWithActors.ContainsKey(movieId))
            {
                throw new ArgumentException();
            }

            this.moviesWithActors.Remove(movieId);
            this.movies.Remove(movieId);
        }
    }
}
