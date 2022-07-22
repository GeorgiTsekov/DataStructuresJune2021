namespace ConnectedAreas
{
    internal class Area
    {
        public Area(int row, int col, int size)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
}