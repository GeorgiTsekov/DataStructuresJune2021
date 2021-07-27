namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private Dictionary<int, IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new Dictionary<int, IWeapon>();
        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon.Id, weapon);
        }

        public void Clear()
        {
            this.weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.weapons.ContainsKey(weapon.Id);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in this.weapons)
            {
                if (weapon.Value.Category == category)
                {
                    weapon.Value.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            if (!this.weapons.ContainsKey(weapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (weapon.Ammunition >= ammunition)
            {
                weapon.Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        public IWeapon GetById(int id)
        {
            if (!this.weapons.ContainsKey(id))
            {
                return null;
            }

            return this.weapons[id];

        }

        public IEnumerator GetEnumerator()
        {
            return this.weapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            if (!this.weapons.ContainsKey(weapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (ammunition + weapon.Ammunition >= weapon.MaxCapacity)
            {
                weapon.Ammunition = weapon.MaxCapacity;
            }
            else
            {
                weapon.Ammunition += ammunition;
            }

            return weapon.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            if (!this.weapons.ContainsKey(id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            var weapon = this.weapons[id];
            this.weapons.Remove(id);
            return weapon;
        }

        public int RemoveHeavy()
        {
            var dictionary = new Dictionary<int, IWeapon>();

            foreach (var keyValuePair in this.weapons)
            {
                if (keyValuePair.Value.Category != Category.Heavy)
                {
                    dictionary.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            int countOfRemovedWeapons = this.weapons.Count - dictionary.Count;

            this.weapons = dictionary;
            return countOfRemovedWeapons;
        }

        public List<IWeapon> RetrieveAll()
        {
            var list = new List<IWeapon>();

            list.AddRange(this.weapons.Values);

            return list;
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var list = new List<IWeapon>();

            foreach (var weapon in this.weapons.Values)
            {
                if (weapon.Category >= lower && weapon.Category <= upper)
                {
                    list.Add(weapon);
                }
            }

            return list;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            if (!(this.weapons.ContainsKey(firstWeapon.Id) && this.weapons.ContainsKey(secondWeapon.Id)))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (this.weapons[firstWeapon.Id].Category == this.weapons[secondWeapon.Id].Category)
            {
                this.weapons[firstWeapon.Id] = secondWeapon;
                this.weapons[secondWeapon.Id] = firstWeapon;
            }
        }
    }
}
