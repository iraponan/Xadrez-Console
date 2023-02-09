using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class PartidaDeXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            terminada = false;
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }

        public void realizarJogada(Posicao origem, Posicao destino) {
            executarMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        private void mudarJogador() {
            if (jogadorAtual == Cor.Branco) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branco;
            }
        }

        public void validarPossicaoDeOrigem(Posicao posicao) {
            if (tabuleiro.peca(posicao) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tabuleiro.peca(posicao).cor) {
                throw new TabuleiroException("A Peça de origem escolhida não é sua!");
            }
            if (!tabuleiro.peca(posicao).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tabuleiro.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
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
