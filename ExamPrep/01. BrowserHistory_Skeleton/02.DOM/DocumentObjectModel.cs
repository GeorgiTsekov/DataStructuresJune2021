namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        private List<IHtmlElement> children;
        private IHtmlElement parent;
        private Dictionary<string, string> attributes;

        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
            this.parent = root.Parent;
            this.children = root.Children;
            this.attributes = root.Attributes;
        }

        public DocumentObjectModel()
        {
            this.children = new List<IHtmlElement>();
            this.attributes = new Dictionary<string, string>();
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            return this.parent.Children.FirstOrDefault(x => x.Type == type);
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return this.children.Where(x => x.Type == type).ToList();
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.children.Contains(htmlElement);
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            if (!this.children.Contains(parent))
            {
                throw new InvalidOperationException();
            }

            foreach (var element in this.children)
            {
                if (element.Parent == parent)
                {
                    element.Parent.Children.Insert(0, child);
                }
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            if (!this.children.Contains(parent))
            {
                throw new InvalidOperationException();
            }

            foreach (var element in this.children)
            {
                if (element.Parent == parent)
                {
                    element.Parent.Children.Add(child);
                }
            }
        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!this.children.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            this.children.Remove(htmlElement);
        }

        public void RemoveAll(ElementType elementType)
        {
            this.children = this.children.Where(x => x.Type != elementType).ToList();
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
