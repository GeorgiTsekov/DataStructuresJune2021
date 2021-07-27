namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            var result = this.FindById(id);

            if (result == null)
            {
                return null;
            }

            this.entities.Remove(result);

            return result;
        }

        public IEntity Find(IEntity entity)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i] == entity)
                {
                    return this.entities[i];
                }
            }

            //foreach (var ent in this.entities)
            //{
            //    if (ent == entity)
            //    {
            //        return ent;
            //    }
            //}
            //var result = this.entities.Find(x => x == entity);

            return null;
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.entities);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        public void RemoveSold()
        {
            var result = new List<IEntity>();

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (entities[i].Status != BaseEntityStatus.Sold)
                {
                    result.Add(entities[i]);
                }
            }

            //foreach (var entity in this.entities)
            //{
            //    if (entity.Status != BaseEntityStatus.Sold)
            //    {
            //        result.Add(entity);
            //    }
            //}

            entities = result;

            //this.entities = this.entities.Where(x => x.Status != BaseEntityStatus.Sold).ToList();
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            var oldIndex = this.entities.IndexOf(oldEntity);

            if (oldIndex < 0)
            {
                throw new InvalidOperationException("Entity not found");
            }

            this.entities[oldIndex] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var result = new List<IEntity>();

            //foreach (var entity in this.entities)
            //{
            //    if (entity.Status >= lowerBound && entity.Status <= upperBound)
            //    {
            //        result.Add(entity);
            //    }
            //}

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status >= lowerBound && this.entities[i].Status <= upperBound)
                {
                    result.Add(this.entities[i]);
                }
            }

            return result;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var firstIndex = this.entities.IndexOf(first);
            var secondIndex = this.entities.IndexOf(second);

            if (firstIndex < 0 || secondIndex < 0)
            {
                throw new InvalidOperationException("Entity not found");
            }

            this.entities[firstIndex] = second;
            this.entities[secondIndex] = first;
        }

        public IEntity[] ToArray()
        {
            return entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            //foreach (var entity in this.entities)
            //{
            //    if (entity.Status == oldStatus)
            //    {
            //        entity.Status = newStatus;
            //    }
            //}

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status == oldStatus)
                {
                    this.entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        private IEntity FindById(int id)
        {
            //foreach (var entity in this.entities)
            //{
            //    if (entity.Id == id)
            //    {
            //        return entity;
            //    }
            //}

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Id == id)
                {
                    return this.entities[i];
                }
            }

            return null;
        }

        private int IndexOf(int searchedId, int start, int end)
        {
            if (start >= end)
            {
                return -1;
            }
            if (start == end && end == entities.Count || end == -1)
            {
                return -1;
            }

            var middle = (start + end) / 2;

            if (this.entities[middle].Id == searchedId)
            {
                return middle;
            }

            if (entities[middle].Id > searchedId)
            {
                return IndexOf(searchedId, start, middle - 1);
            }
            else
            {
                return IndexOf(searchedId, middle + 1, end);
            }
        }
    }
}
