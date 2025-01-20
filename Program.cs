using System;
using System.Diagnostics;
class Program 
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int[] a = Enumerable.Range(1, 100).OrderBy(x => Guid.NewGuid()).ToArray();

        BubbleSort(a);
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"{a[i]}");
            
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
    private static void BubbleSort(int[] a)
    {
        int cnt = a.Length;
        bool sorted = false;
        while(!sorted)
        {
            sorted = true;
            for(int i = 0; i < cnt - 1; i++)
            {
                if(a[i] > a[i+1])
                {
                    int temp = a[i];
                    a[i] = a[i+1];
                    a[i+1] = temp;
                    sorted = false;
                }
            }
            cnt-= 1;
            
        }
        
    }

    private static void Mergsort(int [] a) {

    }
    
}