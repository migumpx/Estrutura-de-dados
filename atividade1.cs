
using System;

class Program
{
    static void Main()
    {
       
        int[][] notas = new int[3][];
        notas[0] = new int[3]; 
        notas[1] = new int[2]; 
        notas[2] = new int[4]; 

      -
        notas[0] = new int[] { 78, 100, 85 };     
        notas[1] = new int[] { 90, 67 };          
        notas[2] = new int[] { 55, 100, 72, 88 }; 

   
        Console.WriteLine("Notas armazenadas:");
        for (int a = 0; a < notas.Length; a++)
        {
            Console.Write($"Aluno {a}: ");
            for (int p = 0; p < notas[a].Length; p++)
                Console.Write(notas[a][p] + (p == notas[a].Length - 1 ? "" : ", "));
            Console.WriteLine();
        }

       
        Console.Write("\nDigite a nota a procurar (ex: 100): ");
        if (!int.TryParse(Console.ReadLine(), out int notaProcurada))
        {
            Console.WriteLine("Entrada inválida. Encerrando.");
            return;
        }

        
        if (BuscaSequencial(notas, notaProcurada, out int alunoIdx, out int provaIdx))
        {
            Console.WriteLine($"Nota {notaProcurada} encontrada! Aluno {alunoIdx}, prova {provaIdx}.");
        }
        else
        {
            Console.WriteLine($"Nota {notaProcurada} NÃO encontrada no sistema.");
        }

        Console.WriteLine("\nPressione ENTER para sair.");
        Console.ReadLine();
    }

    static bool BuscaSequencial(int[][] dados, int chave, out int alunoIndex, out int provaIndex)
    {
        alunoIndex = -1;
        provaIndex = -1;

        for (int a = 0; a < dados.Length; a++)
        {
            
            for (int p = 0; p < dados[a].Length; p++)
            {
                if (dados[a][p] == chave)
                {
                    alunoIndex = a;
                    provaIndex = p;
                    return true; 
                }
            }
        }

        return false; 
    }
}
