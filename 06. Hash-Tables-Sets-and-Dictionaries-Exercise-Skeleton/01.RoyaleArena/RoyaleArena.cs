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
            this.BattleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.BattleCards.ContainsKey(card.Id);
        }

        public int Count => this.BattleCards.Count;

        public void ChangeCardType(int id, CardType type)
        {
            Exists(id);
            this.BattleCards[id].Type = type;
        }

        private void Exists(int cardId)
        {
            if (!this.BattleCards.ContainsKey(cardId))
            {
                throw new InvalidOperationException();
            }
        }

        public BattleCard GetById(int id)
        {
            Exists(id);
            return this.BattleCards[id];
        }

        public void RemoveById(int id)
        {
            Exists(id);
            this.BattleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var cards = this.BattleCards
                .Select(x => x.Value)
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id);

            IsCardsCountZero(cards);

            return cards;
        }

        private static void IsCardsCountZero(IOrderedEnumerable<BattleCard> cards)
        {
            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var cards = this.BattleCards
                .Select(x => x.Value)
                .Where(x => x.Type == type && x.Damage > lo && x.Damage < hi)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id);

            IsCardsCountZero(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var cards = this.BattleCards
                .Select(x => x.Value)
                .Where(x => x.Type == type && x.Damage <= damage)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id);

            IsCardsCountZero(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var cards = this.BattleCards
                .Select(x => x.Value)
                .Where(x => x.Name == name)
                .OrderByDescending(x => x.Swag)
                .ThenBy(x => x.Id);

            IsCardsCountZero(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var cards = this.BattleCards
               .Select(x => x.Value)
               .Where(x => x.Name == name && x.Swag >= lo && x.Swag < hi)
               .OrderByDescending(x => x.Swag)
               .ThenBy(x => x.Id);

            IsCardsCountZero(cards);

            return cards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.BattleCards.Count)
            {
                throw new InvalidOperationException();
            }

            var cards = this.BattleCards
                .Select(x => x.Value)
                .OrderBy(x => x.Swag)
                .ThenBy(x => x.Id)
                .Take(n);

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var cardWithCurrentTypeAndDamage = this.BattleCards
               .Select(x => x.Value)
               .Where(x => x.Swag >= lo && x.Swag <= hi)
               .OrderBy(x => x.Swag);

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