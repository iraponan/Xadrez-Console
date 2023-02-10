using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class PartidaDeXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez() {
            tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas= new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void realizarJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executarMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual)) {
                desfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque!");
            }
            if (estaEmXeque(adversaria(jogadorAtual))) {
                xeque = true;
            }
            else {
                xeque = false;
            }
            if (testeXequeMate(adversaria(jogadorAtual))) {
                terminada = true;
            }
            else {
                turno++;
                mudarJogador();
            }
        }

        public void desfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca peca = tabuleiro.retirarPeca(destino);
            peca.decrementarQtdMovimentos();
            if (pecaCapturada != null) {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(peca, origem);
        }

        private void mudarJogador() {
            if (jogadorAtual == Cor.Branco) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branco;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
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

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private Peca rei(Cor cor) {
            foreach (Peca rei in pecasEmJogo(cor)) {
                if (rei is Rei) {
                    return rei;
                }
            }
            return null;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branco) {
                return Cor.Preta;
            }
            else {
                return Cor.Branco;
            }
        }

        public bool estaEmXeque(Cor cor) {
            Peca rei = this.rei(cor);
            if (rei == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca peca in pecasEmJogo(adversaria(cor))) {
                bool[,] matriz = peca.movimentosPossiveis();
                if (matriz[rei.posicao.linha, rei.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequeMate(Cor cor) {
            if (!estaEmXeque(cor)) {
                return false;
            }
            foreach (Peca peca in pecasEmJogo(cor)) {
                bool[,] matriz = peca.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++) {
                    for (int j = 0; j < tabuleiro.colunas; j++) {
                        if (matriz[i, j]) {
                            Posicao origem = peca.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazerMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branco));

            colocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));
        }
    }
}
