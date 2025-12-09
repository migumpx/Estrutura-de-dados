using System;

class Node
{
    public string Musica;
    public Node Proximo;
    public Node Anterior;

    public Node(string musica)
    {
        Musica = musica;
        Proximo = null;
        Anterior = null;
    }
}

class Playlist
{
    private Node Inicio;
    private Node Fim;
    private Node Atual; // música sendo tocada

    // Adiciona no FINAL da playlist
    public void AdicionarMusica(string nome)
    {
        Node novo = new Node(nome);

        if (Inicio == null)
        {
            Inicio = novo;
            Fim = novo;
            Atual = novo;
        }
        else
        {
            Fim.Proximo = novo;
            novo.Anterior = Fim;
            Fim = novo;
        }

        Console.WriteLine($"Música \"{nome}\" adicionada.");
    }

    // Remover música pelo nome
    public void RemoverMusica(string nome)
    {
        Node temp = Inicio;

        while (temp != null)
        {
            if (temp.Musica == nome)
            {
                // Se for o início
                if (temp == Inicio)
                {
                    Inicio = temp.Proximo;
                    if (Inicio != null)
                        Inicio.Anterior = null;
                }
                // Se for o fim
                else if (temp == Fim)
                {
                    Fim = temp.Anterior;
                    Fim.Proximo = null;
                }
                else
                {
                    // Nó do meio
                    temp.Anterior.Proximo = temp.Proximo;
                    temp.Proximo.Anterior = temp.Anterior;
                }

                Console.WriteLine($"Música \"{nome}\" removida.");
                return;
            }

            temp = temp.Proximo;
        }

        Console.WriteLine("Música não encontrada.");
    }

    // Exibir toda a playlist
    public void MostrarPlaylist()
    {
        Console.WriteLine("\n==== PLAYLIST ====");
        Node temp = Inicio;

        if (temp == null)
        {
            Console.WriteLine("A playlist está vazia.");
            return;
        }

        while (temp != null)
        {
            Console.WriteLine(temp.Musica);
            temp = temp.Proximo;
        }
    }

    // Tocar a próxima música
    public void TocarProxima()
    {
        if (Atual == null)
        {
            Console.WriteLine("Playlist vazia.");
            return;
        }

        if (Atual.Proximo != null)
        {
            Atual = Atual.Proximo;
            Console.WriteLine($"▶ Tocando: {Atual.Musica}");
        }
        else
        {
            Console.WriteLine("Você já está na última música.");
        }
    }

    // Tocar a música anterior
    public void TocarAnterior()
    {
        if (Atual == null)
        {
            Console.WriteLine("Playlist vazia.");
            return;
        }

        if (Atual.Anterior != null)
        {
            Atual = Atual.Anterior;
            Console.WriteLine($"▶ Tocando: {Atual.Musica}");
        }
        else
        {
            Console.WriteLine("Você já está na primeira música.");
        }
    }
}

class Program
{
    static void Main()
    {
        Playlist playlist = new Playlist();

        playlist.AdicionarMusica("Xamã - Malvadão");
        playlist.AdicionarMusica("MC Cabelinho - Fazendo Falta");
        playlist.AdicionarMusica("Veigh - Novo Balanço");

        playlist.MostrarPlaylist();

        Console.WriteLine("\nNavegação:");
        playlist.TocarProxima();
        playlist.TocarProxima();
        playlist.TocarAnterior();

        playlist.RemoverMusica("MC Cabelinho - Fazendo Falta");
        playlist.MostrarPlaylist();

        Console.WriteLine("\nPressione ENTER para sair.");
        Console.ReadLine();
    }
}
