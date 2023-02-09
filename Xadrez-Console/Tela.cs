using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console {
    internal class Tela {
        public static void imprimirTabuleiro(Xadrez_Console.Tabuleiro.Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tabuleiro.peca(i, j) + "");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
