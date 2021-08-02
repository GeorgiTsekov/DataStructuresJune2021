namespace _01._BrowserHistory
{
    using _01._BrowserHistory.Interfaces;

    public class Link : ILink
    {
        public Link(string url, int loadingTime)
        {
            this.Url = url;
            this.LoadingTime = loadingTime;
        }

        public string Url { get; set; }
        public int LoadingTime { get; set; }

        public override string ToString()
        {
            return $"-- {this.Url} {this.LoadingTime}s";
        }
        //public override bool Equals(object obj)
        //{
        //    if (obj is ILink)
        //    {
        //        var entity = (ILink)obj;
        //        return entity.Url == this.Url;
        //    }

        //    return false;
        //}
    }
}
