using System;

class Program
{
    static void Main()
    {
        int[] original = new int[] { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };

        Console.WriteLine("Vetor original:");
        PrintArray(original);
        Console.WriteLine();

        
        int[] arrBubble = (int[])original.Clone();
        var statsBubble = BubbleSort(arrBubble);
        Console.WriteLine("=== Bubble Sort ===");
        PrintArray(arrBubble);
        Console.WriteLine($"Comparações: {statsBubble.comparisons}, Trocas: {statsBubble.swaps}\n");

       
        int[] arrSelection = (int[])original.Clone();
        var statsSelection = SelectionSort(arrSelection);
        Console.WriteLine("=== Selection Sort ===");
        PrintArray(arrSelection);
        Console.WriteLine($"Comparações: {statsSelection.comparisons}, Trocas: {statsSelection.swaps}\n");

      
        int[] arrInsertion = (int[])original.Clone();
        var statsInsertion = InsertionSort(arrInsertion);
        Console.WriteLine("=== Insertion Sort ===");
        PrintArray(arrInsertion);
     
        Console.WriteLine($"Comparações: {statsInsertion.comparisons}, Movimentações (shifts): {statsInsertion.movements}\n");

        Console.WriteLine("Pressione ENTER para sair.");
        Console.ReadLine();
    }

    static void PrintArray(int[] a)
    {
        Console.WriteLine(string.Join(", ", a));
    }

    
    static (long comparisons, long swaps) BubbleSort(int[] a)
    {
        int n = a.Length;
        long comps = 0;
        long swaps = 0;

        for (int i = 0; i < n - 1; i++)
        {
           
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                comps++; 
                if (a[j] > a[j + 1])
                {
                    
                    int tmp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = tmp;
                    swaps++;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        return (comps, swaps);
    }


    static (long comparisons, long swaps) SelectionSort(int[] a)
    {
        int n = a.Length;
        long comps = 0;
        long swaps = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                comps++; 
                if (a[j] < a[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int tmp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = tmp;
                swaps++;
            }
        }

        return (comps, swaps);
    }

        static (long comparisons, long movements) InsertionSort(int[] a)
    {
        int n = a.Length;
        long comps = 0;
        long movements = 0;

        for (int i = 1; i < n; i++)
        {
            int key = a[i];
            int j = i - 1;

            
            while (j >= 0)
            {
                comps++; 
                if (a[j] > key)
                {
                   
                    a[j + 1] = a[j];
                    movements++;
                    j--;
                }
                else
                {
                    
                    break;
                }
            }

           
            a[j + 1] = key;
            
        }

        return (comps, movements);
    }
}
