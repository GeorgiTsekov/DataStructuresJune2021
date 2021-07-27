namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private Dictionary<int, IEnemy> enemies;

        public Legion()
        {
            this.enemies = new Dictionary<int, IEnemy>();
        }

        public int Size => this.enemies.Count;

        public bool Contains(IEnemy enemy)
        {
            if (!this.enemies.ContainsKey(enemy.AttackSpeed))
            {
                return false;
            }

            return true;
        }

        public void Create(IEnemy enemy)
        {
            if (!this.enemies.ContainsKey(enemy.AttackSpeed))
            {
                this.enemies.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (this.enemies.ContainsKey(speed))
            {
                return this.enemies[speed];
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var list = this.enemies.Where(x => x.Key > speed).ToDictionary(x => x.Key, y => y.Value);
            return list.Values.ToList();
        }

        public IEnemy GetFastest()
        {
            if (this.enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return this.enemies[this.enemies.Keys.Max()];
        }

        public IEnemy[] GetOrderedByHealth()
        {
            if (this.enemies.Count == 0)
            {
                return new IEnemy[0];
            }

            var array = this.enemies.Values.OrderByDescending(x => x.Health).ToArray();

            return array;
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var list = this.enemies.Where(x => x.Key < speed).ToDictionary(x => x.Key, y => y.Value);
            return list.Values.ToList();
        }

        public IEnemy GetSlowest()
        {
            if (this.enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return this.enemies[this.enemies.Keys.Min()];
        }

        public void ShootFastest()
        {
            if (this.enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            this.enemies.Remove(this.enemies.Keys.Max());
        }

        public void ShootSlowest()
        {
            if (this.enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            this.enemies.Remove(this.enemies.Keys.Min());
        }
    }
}
