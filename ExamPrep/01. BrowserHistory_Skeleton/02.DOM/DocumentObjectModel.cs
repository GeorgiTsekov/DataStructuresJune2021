namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        private List<IHtmlElement> list;

        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            list = new List<IHtmlElement>();
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            return this.list.FirstOrDefault(x => x.Type == type);
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return this.list.Where(x => x.Type == type).ToList();
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.list.Contains(htmlElement);
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            if (!this.list.Contains(parent))
            {
                throw new InvalidOperationException();
            }

            foreach (var element in this.list)
            {
                if (element.Parent == parent)
                {
                    element.Parent.Children.Insert(0, child);
                }
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            if (!this.list.Contains(parent))
            {
                throw new InvalidOperationException();
            }

            foreach (var element in this.list)
            {
                if (element.Parent == parent)
                {
                    element.Parent.Children.Add(child);
                }
            }
        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!this.list.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            this.list.Remove(htmlElement);
        }

        public void RemoveAll(ElementType elementType)
        {
            this.list = this.list.Where(x => x.Type != elementType).ToList();
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public IHtmlElement GetElementById(string idValue)
        {
            throw new NotImplementedException();
        }
    }
}
