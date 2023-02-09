using System.Security.Cryptography.X509Certificates;
using Xadrez_Console;
using Xadrez_Console.JogoDoXadrez;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {

        
        PartidaDeXadrez partida = new PartidaDeXadrez();

        while (!partida.terminada) {
            try {
                Tela.imprimirTabuleiro(partida);
                
                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                partida.validarPossicaoDeOrigem(origem);

                bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();

                Tela.imprimirTabuleiro(partida, posicoesPossiveis);

                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                partida.validarPosicaoDeDestino(origem, destino);
                
                partida.realizarJogada(origem, destino);
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message + "\nAperte qualquer tecla para tentar novamente.");
                Console.ReadKey();
            }
        }
    }
}