using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console {
    internal class Tela {
        public static void imprimirTabuleiro(Xadrez_Console.Tabuleiro.Tabuleiro tabuleiro) {

            Console.BackgroundColor= ConsoleColor.Blue;
            Console.Clear();

            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        imprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branco) {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
