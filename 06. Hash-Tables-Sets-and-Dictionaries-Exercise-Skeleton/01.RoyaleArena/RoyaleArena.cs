namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> BattleCards;

        public RoyaleArena()
        {
            this.BattleCards = new Dictionary<int, BattleCard>();
        }

        public void Add(BattleCard card)
        {
            if (this.Contains(card))
            {
                throw new NotImplementedException();
            }

            this.BattleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.BattleCards.ContainsKey(card.Id);
        }

        public int Count => this.BattleCards.Count;

        public void ChangeCardType(int id, CardType type)
        {
            if (!this.BattleCards.ContainsKey(id))
            {
                throw new NotImplementedException();
            }

            this.BattleCards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            if (!this.BattleCards.ContainsKey(id))
            {
                throw new NotImplementedException();
            }

            return this.BattleCards[id];
        }

        public void RemoveById(int id)
        {
            if (!this.BattleCards.ContainsKey(id))
            {
                throw new NotImplementedException();
            }

            this.BattleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var cardWithCurrentType = this.BattleCards.Values
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            return cardWithCurrentType;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards.Values
                .Where(x => x.Type == type && x.Damage >= lo && x.Damage <= hi)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            return cardWithCurrentTypeAndDamage;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards.Values
                .Where(x => x.Type == type && x.Damage <= damage)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            if (cardWithCurrentTypeAndDamage == null)
            {
                throw new InvalidOperationException();
            }

            return cardWithCurrentTypeAndDamage;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards.Values
                .Where(x => x.Name == name)
                .OrderByDescending(x => x.Swag)
                .ThenBy(x => x.Id)
                .ToList();

            if (cardWithCurrentTypeAndDamage == null)
            {
                throw new InvalidOperationException();
            }

            return cardWithCurrentTypeAndDamage;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards.Values
               .Where(x => x.Name == name && x.Swag >= lo && x.Swag < hi)
               .OrderByDescending(x => x.Swag)
               .ThenBy(x => x.Id)
               .ToList();

            if (cardWithCurrentTypeAndDamage == null)
            {
                throw new InvalidOperationException();
            }

            return cardWithCurrentTypeAndDamage;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.Count)
            {
                throw new InvalidCastException();
            }

            var cards = this.BattleCards.Values
                .OrderBy(x => x.Swag)
                .ThenBy(x => x.Id)
                .Take(n)
                .ToList();

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards.Values
               .Where(x => x.Swag >= lo && x.Swag <= hi)
               .OrderBy(x => x.Swag)
               .ToList();

            if (cardWithCurrentTypeAndDamage == null)
            {
                return new List<BattleCard>();
            }

            return cardWithCurrentTypeAndDamage;
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var kvp in this.BattleCards)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}