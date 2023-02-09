using System.Security.Cryptography.X509Certificates;
using Xadrez_Console;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {
        
        try {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.terminada) {
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tabuleiro);
                Console.WriteLine();
                
                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                
                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                
                partida.executarMovimento(origem, destino);
            }

        } catch (TabuleiroException e) {
            Console.WriteLine(e.Message);
        }
    }
}