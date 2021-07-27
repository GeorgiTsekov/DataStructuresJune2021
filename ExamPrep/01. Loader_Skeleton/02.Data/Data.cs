namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Data : IRepository
    {
        private PriorityQueue<IEntity> queue;
        private Dictionary<int, IEntity> dictionary;
        private Dictionary<int, List<IEntity>> parents;

        public Data()
        {
            queue = new PriorityQueue<IEntity>();
            dictionary = new Dictionary<int, IEntity>();
            parents = new Dictionary<int, List<IEntity>>();
        }

        public Data(
            PriorityQueue<IEntity> queue,
            Dictionary<int, IEntity> dictionary, 
            Dictionary<int, List<IEntity>> parents)
        {
            this.queue = queue;
            this.dictionary = dictionary;
            this.parents = parents;
        }

        public int Size => queue.Size;

        public void Add(IEntity entity)
        {
            queue.Add(entity);
            dictionary.Add(entity.Id, entity);

            if (entity.ParentId != null)
            {
                if (!parents.ContainsKey((int)entity.ParentId))
                {
                    parents.Add((int)entity.ParentId, new List<IEntity>());
                }

                parents[(int)entity.ParentId].Add(entity);
            }
        }

        public IRepository Copy()
        {
            return new Data(queue, dictionary, parents);
        }

        public IEntity DequeueMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            var element = queue.Dequeue();
            dictionary.Remove(element.Id);

            return element;
        }

        public List<IEntity> GetAll()
        {
            return queue.GetAsList();
        }

        public List<IEntity> GetAllByType(string type)
        {
            var list = new List<IEntity>();

            if (type != "Invoice" && type != "User" && type != "StoreClient")
            {
                throw new InvalidOperationException($"Invalid type: {type}");
            }

            foreach (var entity in queue.GetAsList())
            {
                if (type == entity.GetType().Name)
                {
                    list.Add(entity);
                }
            }

            return list;
        }

        public IEntity GetById(int id)
        {
            if (!dictionary.ContainsKey(id))
            {
                return null;
            }
            return dictionary[id];

            //return queue.GetAsList().Find(x => x.Id == id);
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            //var list = new List<IEntity>();

            //foreach (var entity in queue.GetAsList())
            //{
            //    if (entity.ParentId == parentId)
            //    {
            //        list.Add(entity);
            //    }
            //}

            //return list;
            if (!parents.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }

            return parents[parentId];
        }

        public IEntity PeekMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            return queue.Peek();
        }
    }
}
