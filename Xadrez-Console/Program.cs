using System.Security.Cryptography.X509Certificates;
using Xadrez_Console;
using Xadrez_Console.Tabuleiro;

internal class Program {
    private static void Main(string[] args) {
        
        Tabuleiro tabuleiro = new Tabuleiro(8, 8);
        Tela.imprimirTabuleiro(tabuleiro);
    }
}