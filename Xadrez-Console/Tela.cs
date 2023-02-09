using System.Xml;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console {
    internal class Tela {
        public static void imprimirTabuleiro(PartidaDeXadrez partida) {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Tabuleiro.Tabuleiro tabuleiro = partida.tabuleiro;

            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

            Console.WriteLine();
            dadosDoTurno(partida);
        }

        internal static void imprimirTabuleiro(PartidaDeXadrez partida, bool[,] posicoesPossiveis) {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Tabuleiro.Tabuleiro tabuleiro = partida.tabuleiro;

            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    imprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine();
            dadosDoTurno(partida);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            }
            else {
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
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = Char.ToUpper(s[0]);
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        private static void dadosDoTurno(PartidaDeXadrez partida) {
            if (partida.jogadorAtual == Cor.Branco) {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando: Jogador " + partida.jogadorAtual);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
