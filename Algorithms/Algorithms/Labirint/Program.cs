// See https://aka.ms/new-console-template for more information
int rows = int.Parse(Console.ReadLine());
int cols = int.Parse(Console.ReadLine());

var labirint = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    var colElements = Console.ReadLine();

    for (int col = 0; col < colElements.Length; col++)
    {
        labirint[row, col] = colElements[col];
    }
}

FindPaths(labirint, 0, 0, new List<string>(), string.Empty);


static void FindPaths(char[,] labirint, int row, int col, List<string> directions, string direction)
{
    if (row < 0 || row >= labirint.GetLength(0) || col < 0 || col >= labirint.GetLength(1))
    {
        return;
    }

    if (labirint[row, col] == '*' || labirint[row, col] == 'v')
    {
        return;
    }

    directions.Add(direction);

    if (labirint[row,col] == 'e')
    {
        Console.WriteLine(string.Join(string.Empty, directions));
        directions.RemoveAt(directions.Count - 1);
        return;
    }

    labirint[row, col] = 'v';

    FindPaths(labirint, row - 1, col, directions, "U"); // up
    FindPaths(labirint, row + 1, col, directions, "D"); // down
    FindPaths(labirint, row, col - 1, directions, "L"); // left
    FindPaths(labirint, row, col + 1, directions, "R"); // right

    labirint[row, col] = '-';
    directions.RemoveAt(directions.Count - 1);
}

