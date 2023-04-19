namespace ConsoleJogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] tabuleiro = new string[3, 3];

            bool temVencedor = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = " ";
                }
            }

            mostraTabuleiro(tabuleiro);

            bool vez = true;

            while (!temVencedor)
            {
                if (vez)
                {
                    //jogador 1
                    Console.WriteLine("Jogador 1, informe linha e coluna!");
                    int linha = int.Parse(Console.ReadLine());
                    int coluna = int.Parse(Console.ReadLine());

                    bool gravoCerto = GravaJogada((linha - 1), (coluna - 1), "X", tabuleiro);

                    if (gravoCerto)
                        vez = false;
                }
                else
                {
                    //jogador 2
                    Console.WriteLine("Jogador 2, informe linha e coluna!");
                    int linha = int.Parse(Console.ReadLine());
                    int coluna = int.Parse(Console.ReadLine());

                    bool gravoCerto = GravaJogada((linha - 1), (coluna - 1), "O", tabuleiro);

                    if (gravoCerto)
                        vez = true;
                }

                mostraTabuleiro(tabuleiro);

                temVencedor = VerificaVencedor(tabuleiro);
            }

            if (!vez)
            {
                Console.WriteLine("O vencedor é o jogador 1!");
            }
            else
            {
                Console.WriteLine("O vencedor é o jogador 2!");
            }

            Console.ReadKey();
        }

        private static bool VerificaVencedor(string[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2] && tabuleiro[i, 0] != " ")
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i] && tabuleiro[0, i] != " ")
                {
                    return true;
                }
            }

            if (tabuleiro[0, 0] != " " && tabuleiro[1, 1] == tabuleiro[2, 2] && tabuleiro[0, 0] == tabuleiro[1, 1])
            {
                return true;
            }

            if (tabuleiro[0, 2] != " " && tabuleiro[1, 1] == tabuleiro[0, 2] && tabuleiro[0, 2] == tabuleiro[2, 0])
            {
                return true;
            }

            return false;
        }

        private static bool GravaJogada(int linha, int coluna, string valor, string[,] tabuleiro)
        {
            try
            {
                if (tabuleiro[linha, coluna] == " ")
                {
                    tabuleiro[linha, coluna] = valor;
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        static void mostraTabuleiro(string[,] tab)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("[" + tab[i, j] + "]");
                }

                Console.WriteLine();
            }
        }
    }
}