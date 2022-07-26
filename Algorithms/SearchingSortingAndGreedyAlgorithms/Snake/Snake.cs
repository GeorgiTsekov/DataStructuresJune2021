namespace Snake
{
    public class Snake
    {
        public Snake(int row, int col, char direction)
        {
            this.Row = row;
            this.Col = col;
            this.Direction = direction;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Direction { get; set; }
    }
}
