namespace HTMLRenderingEngineAndShit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;
        protected HTMLElement()
        {
            this.ChildElements = new List<IElement>();
        }
        public HTMLElement(string name)
            :this()
        {
            this.Name = name;
        }
        public HTMLElement(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public HTMLElement(string name, string textContent, IEnumerable<IElement> childElements)
            : this(name, textContent)
        {
            this.ChildElements = childElements;
        }
        public string Name
        {
            get;
            protected set;
        }

        public string TextContent
        {
            get;
            set;
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
            protected set
            {
                this.childElements = (IList<IElement>)value;
            }
        }

        public void AddElement(IElement element)
        {
            if (element != null)
            {
                this.childElements.Add(element);
            }
        }
        protected string HTMLEncode(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (var ch in text)
            {
                if (ch == '<')
                {
                    result.Append("&lt;");
                }
                else if (ch == '>')
                {
                    result.Append("&gt;");
                }
                else if (ch == '&')
                {
                    result.Append("&amp;");
                }
                else
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<" + this.Name + ">");
            }
            if (this.TextContent != null)
            {
                output.Append(HTMLEncode(this.TextContent));
            }
            if (this.ChildElements.Count() > 0)
            {
                foreach (var element in this.ChildElements)
                {
                    element.Render(output);
                }
            }
            if (this.Name != null)
            {
                output.Append("</" + this.Name + ">");
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
