using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Torre : Peca {
        public Torre(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "T";
        }
    }
}
