using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
    int[] sizes = { 10, 100, 1000, 10000, 100000}; //En arryen som innehåller storlekerna på de listorna som ska testas

        Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Algorithm", "Array Size", "Avg Time (ms)"); //Skriver ut en tabelrukbrik
            Console.WriteLine(new string('-', 45));

        foreach (int size in sizes)
        //Iterar enom varje storlek i sizes
        {
            int[] array = GenerateRandomArray(size); // Skapar en slumpmässig arry
            //Anropar medeltiden för varj algortim
            Medeltid("BubbleSort", array, Sorting.BubbleSort);
            Medeltid("InsertionSort", array, Sorting.InsertionSort);
            Medeltid("MergeSort", array, Sorting.MergeSort);
            Medeltid("QuickSort", array, Sorting.QuickSort);
            Console.WriteLine("******************************************");
        }
    }

    static int[] GenerateRandomArray(int size) 
    {
        Random rand = new Random(); //Skapar en instans av random för att skapa slumpmässiga tal
        int[] array = new int[size]; //skapar en ny arry med storleken size
        for (int i = 0; i < size; i++) // Fyller arryen med slumässiga tal
        {
            array[i] = rand.Next(1, size + 1);
        }
        return array; //Skickar den skapade arryen till Main
    }

    static void Medeltid(string name, int[] array, Action<int[]> sortMethod)
    {
        int runs = 5;  //Antal gånger aloritm ska köras
        long totalTicks = 0; //Samalr den totala tiden som algoritmen tar för alla körningar

        for (int i = 0; i < runs; i++) 
        {
            int[] copy = (int[])array.Clone(); //Skapar en kopia av den urspungliga arryen med Clone
            Stopwatch stopwatch = Stopwatch.StartNew(); //startar Timer
            sortMethod(copy); //Kör algoritmen på kopian
            stopwatch.Stop();
            totalTicks += stopwatch.ElapsedTicks; //Stoppar timern och lägger till tiden
        }

        
        double averageTimeMs = (totalTicks / (double)runs) * 1000 / Stopwatch.Frequency; // Breäknar medelvärdet av tiden i millisekunder
            Console.WriteLine("{0,-15} {1,-15} {2,-15:F6}", name, array.Length, averageTimeMs); //Skriver ut result
        
    }
}
