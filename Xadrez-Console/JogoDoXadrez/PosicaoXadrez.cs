using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class PosicaoXadrez {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao() {
            return new Posicao(8 - linha, Char.ToUpper(coluna) - 'A');
        }

        public override string ToString() {
            return ""
                + Char.ToUpper(coluna)
                + linha;
        }
    }
}
