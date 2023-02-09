using System.Security.Cryptography.X509Certificates;
using Xadrez_Console;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {
        
        try {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2, 5));

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new Posicao(3, 5));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new Posicao(2, 3));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branco), new Posicao(5, 5));

            Tela.imprimirTabuleiro(tabuleiro);

        } catch (TabuleiroException e) {
            Console.WriteLine(e.Message);
        }
    }
}