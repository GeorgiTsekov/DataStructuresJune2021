namespace Exam.RePlay
{
    public class Track
    {
        public Track(string id, string title, string artist, int plays, int durationInSeconds)
        {
            this.Id = id;
            this.Title = title;
            this.Artist = artist;
            this.Plays = plays;
            this.DurationInSeconds = durationInSeconds;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int Plays { get; set; }

        public int DurationInSeconds { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Track;
            if (other == null)
            {
                return false;
            }
            return this.Id == other.Id;
        }

        public int CompareTo(Track other)
        {
            return (int)(other.Plays * 100 - this.Plays * 100);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
