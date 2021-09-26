using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Doodle
{
    public class DoodleSearch : IDoodleSearch
    {
        private Dictionary<string, Doodle> doodlesById = new Dictionary<string, Doodle>();
        private Dictionary<string, Doodle> doodlesByTitle = new Dictionary<string, Doodle>();

        public int Count => this.doodlesById.Count;

        public void AddDoodle(Doodle doodle)
        {
            if (!this.doodlesById.ContainsKey(doodle.Id))
            {
                if (!this.doodlesByTitle.ContainsKey(doodle.Title))
                {
                    doodlesById.Add(doodle.Id, doodle);
                    doodlesByTitle.Add(doodle.Title, doodle);
                }
            }
        }

        public bool Contains(Doodle doodle)
        {
            return this.doodlesById.ContainsKey(doodle.Id);
        }

        public Doodle GetDoodle(string id)
        {
            if (!this.doodlesById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            return this.doodlesById[id];
        }

        public IEnumerable<Doodle> GetDoodleAds()
        {
            var result = this.doodlesById
                .Select(x => x.Value)
                .Where(x => x.IsAd)
                .OrderByDescending(x => x.Revenue)
                .ThenByDescending(x => x.Visits)
                .ToList();

            return result;
        }

        public IEnumerable<Doodle> GetTop3DoodlesByRevenueThenByVisits()
        {
            var result = this.doodlesById
                .Select(x => x.Value)
                .OrderByDescending(x => x.Revenue)
                .ThenByDescending(x => x.Visits)
                .Take(3)
                .ToList();

            return result;
        }

        public double GetTotalRevenueFromDoodleAds()
        {
            var total = 0.0;

            foreach (var doodle in this.doodlesById.Values)
            {
                if (doodle.IsAd)
                {
                    total += (doodle.Visits * doodle.Revenue);
                }
            }

            return total;
        }

        public void RemoveDoodle(string doodleId)
        {
            if (!this.doodlesById.ContainsKey(doodleId))
            {
                throw new ArgumentException();
            }

            var doodle = this.doodlesById[doodleId];
            this.doodlesByTitle.Remove(doodle.Title);
            this.doodlesById.Remove(doodleId);
        }

        public IEnumerable<Doodle> SearchDoodles(string searchQuery)
        {
            //var result = this.doodlesByTitle
            //    .Select(x => x.Value)
            //    .Where(x => x.Title.Contains(searchQuery))
            //    .OrderByDescending(x => x.Title)
            //    .ThenByDescending(x => x.Visits)
            //    .ToList();

            //return result;

            return new List<Doodle>();
        }

        public void VisitDoodle(string title)
        {
            if (!this.doodlesByTitle.ContainsKey(title))
            {
                throw new ArgumentException();
            }
            var doodle = this.doodlesByTitle[title];

            doodle.Visits++;
            //this.doodlesByTitle[title].Visits++;
            //this.doodlesById[doodle.Id].Visits++;
        }
    }
}
