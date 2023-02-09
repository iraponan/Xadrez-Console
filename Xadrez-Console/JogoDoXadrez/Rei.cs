using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Rei : Peca {
        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "R";
        }
    }
}
