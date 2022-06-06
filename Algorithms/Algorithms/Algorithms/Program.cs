// See https://aka.ms/new-console-template for more information

var n = int.Parse(Console.ReadLine());

var arr = new int[n];

Gen01(arr, 0);


static void Gen01(int[] arr, int index)
{
    if (index >= arr.Length)
    {
        Console.WriteLine(String.Join(string.Empty, arr));
        return;
    }

    for (int i = 0; i < 2; i++)
    {
        arr[index] = i;

        Gen01(arr, index + 1);
    }
}