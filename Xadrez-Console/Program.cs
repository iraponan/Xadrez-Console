using Xadrez_Console;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {
        
        Tabuleiro tabuleiro = new Tabuleiro(8, 8);

        tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
        tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
        tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2, 4));

        Tela.imprimirTabuleiro(tabuleiro);
    }
}