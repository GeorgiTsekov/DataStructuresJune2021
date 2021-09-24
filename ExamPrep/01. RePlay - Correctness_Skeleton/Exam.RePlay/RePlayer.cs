using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {

        private SortedDictionary<string, Dictionary<string, Track>> albums;
        private Dictionary<string, Track> tracks;
        private List<Track> listeningTracks;
        private SortedDictionary<string, List<Track>> discoveryTracks;

        public RePlayer()
        {
            this.albums = new SortedDictionary<string, Dictionary<string, Track>>();
            this.tracks = new Dictionary<string, Track>();
            this.listeningTracks = new List<Track>();
            this.discoveryTracks = new SortedDictionary<string, List<Track>>();
        }

        public int Count => this.tracks.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            if (!this.albums.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.albums[albumName].ContainsKey(trackName))
            {
                throw new ArgumentException();
            }

            this.listeningTracks.Add(this.albums[albumName][trackName]);
        }

        public void AddTrack(Track track, string album)
        {
            if (!this.albums.ContainsKey(album))
            {
                this.discoveryTracks.Add(album, new List<Track>());
                this.albums.Add(album, new Dictionary<string, Track>());
            }

            if (!this.albums[album].ContainsKey(track.Title))
            {
                this.tracks.Add(track.Id, track);
                this.discoveryTracks[album].Add(track);
                this.albums[album].Add(track.Title, track);
            }
        }

        public bool Contains(Track track)
        {
            return this.tracks.ContainsKey(track.Id);
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.discoveryTracks.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            var tracksByAlbumName = this.discoveryTracks[albumName]
                .OrderByDescending(x => x.Plays)
                .ToList();

            if (tracksByAlbumName.Count == 0)
            {
                throw new ArgumentException();
            }

            return tracksByAlbumName;
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            var result = this.discoveryTracks
                .Where(x => x.Value.Any(x => x.Artist == artistName))
                .ToDictionary(x => x.Key, y => y.Value);

            if (result.Count() == 0)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public Track GetTrack(string title, string albumName)
        {
            if (!this.albums.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.albums[albumName].ContainsKey(title))
            {
                throw new ArgumentException();
            }

            return this.albums[albumName][title];
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            var result = this.tracks
                .Values
                .Where(x => x.DurationInSeconds >= lowerBound && x.DurationInSeconds <= upperBound)
                .OrderBy(x => x.DurationInSeconds)
                .ThenByDescending(x => x.Plays)
                .ToList();

            if (result.Count() ==0)
            {
                return new List<Track>();
            }

            return result;
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            if (this.discoveryTracks.Count() == 0)
            {
                return new List<Track>();
            }

            return this.discoveryTracks
                .SelectMany(x => x.Value)
                .OrderByDescending(x => x.Plays)
                .ThenByDescending(x => x.DurationInSeconds)
                .ToList();
        }

        public Track Play()
        {
            if (this.listeningTracks.Count == 0)
            {
                throw new ArgumentException();
            }

            foreach (var track in listeningTracks)
            {
                track.Plays++;
            }

            var result = this.listeningTracks[0];

            this.listeningTracks.RemoveAt(0);

            return result;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            if (!this.albums.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.albums[albumName].ContainsKey(trackTitle))
            {
                throw new ArgumentException();
            }

            var track = this.albums[albumName][trackTitle];
            this.albums[albumName].Remove(trackTitle);
            this.discoveryTracks[albumName].Remove(track);
            this.tracks.Remove(track.Id);
            this.listeningTracks.Remove(track);
        }
    }
}
