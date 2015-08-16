namespace HTMLRenderingEngineAndShit
{
    using System.Text;
    public class Table: HTMLElement, ITable
    {
        private readonly string tableName = "table";
        private IElement[,] table;

        public Table(int row, int col)
            :base()
        {
            this.Name = tableName;
            this.TextContent = null;
            this.ChildElements = null;
            this.Rows = row;
            this.Cols = col;
            this.table = new IElement[this.Rows, this.Cols];
        }
        public int Rows
        {
            get;
            private set;
        }

        public int Cols
        {
            get;
            private set;
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.table[row, col];
            }
            set
            {
                this.table[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>");

            for (int i = 0; i < this.Rows; i++)
            {
                output.Append("<tr>");

                for (int j = 0; j < this.Cols; j++)
                {
                    output.Append("<td>" + this.table[i, j].ToString() + "</td>");   
                }

                output.Append("</tr>");
            }

            output.Append("</table>");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
