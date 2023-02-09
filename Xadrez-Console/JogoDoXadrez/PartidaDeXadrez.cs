using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class PartidaDeXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }
        private void colocarPecas() {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('C', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('C', 2).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('D', 2).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('E', 2).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('E', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branco), new PosicaoXadrez('D', 1).toPosicao());

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('C', 7).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('C', 8).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('D', 7).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('E', 7).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('E', 8).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new PosicaoXadrez('D', 8).toPosicao());
        }
    }
}
