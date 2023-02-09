using Xadrez_Console;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {
        
        try {
            PosicaoXadrez posicaoXadrez = new PosicaoXadrez('c', 7);

            Console.WriteLine(posicaoXadrez);
            Console.WriteLine(posicaoXadrez.toPosicao());

        } catch (TabuleiroException e) {
            Console.WriteLine(e.Message);
        }
    }
}