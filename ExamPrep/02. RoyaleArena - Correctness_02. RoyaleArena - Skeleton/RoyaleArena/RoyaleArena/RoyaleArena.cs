using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    private Dictionary<int, Battlecard> cards;

    public RoyaleArena()
    {
        this.cards = new Dictionary<int, Battlecard>();
    }

    public int Count => this.cards.Count;

    public void Add(Battlecard card)
    {
        if (!this.cards.ContainsKey(card.Id))
        {
            this.cards.Add(card.Id, card);
        }
    }

    public void ChangeCardType(int id, CardType type)
    {
        if (!this.cards.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.cards[id].Type = type;
    }

    public bool Contains(Battlecard card)
    {
        if (this.cards.ContainsKey(card.Id))
        {
            return true;
        }

        return false;
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        if (this.cards.Count <= n)
        {
            throw new InvalidOperationException();
        }

        return this.cards
            .OrderByDescending(x => x.Value.Swag)
            .ThenBy(x => x.Key).Take(n)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        var cardsInSwagOrder = this.cards.Values
            .OrderBy(x => x.Name.Distinct())
            .ThenBy(x => x.Swag).Distinct()
            .ToList();

        return cardsInSwagOrder;
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        return this.cards.Values
            .Where(x => x.Swag >= lo && x.Swag <= hi)
            .OrderBy(x => x.Swag)
            .ToList();
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        var newCards = this.cards.Values
            .Where(x => x.Type == type)
            .OrderByDescending(x => x.Damage)
            .ThenBy(x => x.Id)
            .ToList();

        if (newCards.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return newCards;
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        var newCards = this.cards.Values
             .Where(x => x.Type == type && x.Damage <= damage)
             .OrderByDescending(x => x.Damage)
             .ThenBy(x => x.Id)
             .ToList();

        if (newCards.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return newCards;
    }

    public Battlecard GetById(int id)
    {
        if (!this.cards.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return this.cards[id];
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        var newCards = this.cards.Values
             .Where(x => x.Name == name && x.Swag >= lo && x.Swag < hi)
             .OrderByDescending(x => x.Swag)
             .ThenBy(x => x.Id)
             .ToList();

        if (newCards.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return newCards;
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        var newCards = this.cards.Values
             .Where(x => x.Name == name)
             .OrderByDescending(x => x.Swag)
             .ThenBy(x => x.Id)
             .ToList();

        if (newCards.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return newCards; throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        var newCards = this.cards.Values
             .Where(x => x.Type == type && x.Damage >= lo && x.Damage <= hi)
             .OrderByDescending(x => x.Damage)
             .ThenBy(x => x.Id)
             .ToList();

        if (newCards.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return newCards;
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void RemoveById(int id)
    {
        if (!this.cards.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        this.cards.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.cards.GetEnumerator();
    }
}
