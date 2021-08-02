namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private List<ILink> links;

        public BrowserHistory()
        {
            this.links = new List<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.links.Contains(link);
        }

        public ILink DeleteFirst()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var firstLink = this.links[0];
            this.links.RemoveAt(0);

            return firstLink;
        }

        public ILink DeleteLast()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var lastLink = this.links[this.links.Count - 1];
            this.links.RemoveAt(this.links.Count - 1);

            return lastLink;
        }

        public ILink GetByUrl(string url)
        {
            if (this.links.Count == 0)
            {
                return null;
            }

            foreach (var link in this.links)
            {
                if (link.Url == url)
                {
                    return link;
                }
            }

            return null;
        }

        public ILink LastVisited()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.links[this.links.Count - 1];
        }

        public void Open(ILink link)
        {
            this.links.Add(link);
        }

        public int RemoveLinks(string url)
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var list = new List<ILink>();
            int count = 0;

            foreach (var link in this.links)
            {
                if (link.Url.Contains(url))
                {
                    count++;
                }
                else
                {
                    list.Add(link);
                }
            }

            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.links = list;

            return count;
        }

        public ILink[] ToArray()
        {
            var array = new List<ILink>();
            if (this.links.Count == 0)
            {
                return array.ToArray();
            }

            for (int i = this.links.Count - 1; i >= 0; i--)
            {
                array.Add(this.links[i]);
            }

            return array.ToArray();
        }

        public List<ILink> ToList()
        {
            var array = new List<ILink>();
            if (this.links.Count == 0)
            {
                return array;
            }

            for (int i = this.links.Count - 1; i >= 0; i--)
            {
                array.Add(this.links[i]);
            }

            return array;
        }

        public string ViewHistory()
        {
            if (this.links.Count == 0)
            {
                return "Browser history is empty!";
            }

            var sb = new StringBuilder();

            for (int i = this.links.Count - 1; i >= 0; i--)
            {
                sb.Append(this.links[i].ToString() + "\r\n");
            }

            return sb.ToString();
        }
    }
}
