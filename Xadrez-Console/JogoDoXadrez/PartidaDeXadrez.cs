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

            //Jogada Especial (Roque Pequeno)
            if (peca is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tabuleiro.retirarPeca(origemTorre);
                torre.incrementarQtdMovimentos();
                tabuleiro.colocarPeca(torre, destinoTorre);
            }

            //Jogada Especial (Roque Grande)
            if (peca is Rei && destino.coluna == origem.coluna - 2) {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tabuleiro.retirarPeca(origemTorre);
                torre.incrementarQtdMovimentos();
                tabuleiro.colocarPeca(torre, destinoTorre);
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

            //Jogada Especial (Roque Pequeno)
            if (peca is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tabuleiro.retirarPeca(destinoTorre);
                torre.decrementarQtdMovimentos();
                tabuleiro.colocarPeca(torre, origemTorre);
            }

            //Jogada Especial (Roque Grande)
            if (peca is Rei && destino.coluna == origem.coluna - 2) {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tabuleiro.retirarPeca(destinoTorre);
                torre.decrementarQtdMovimentos();
                tabuleiro.colocarPeca(torre, origemTorre);
            }
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
            if (!tabuleiro.peca(origem).movimentoPossivel(destino)) {
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
            colocarNovaPeca('A', 1, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('B', 1, new Cavalo(tabuleiro, Cor.Branco));
            colocarNovaPeca('C', 1, new Bispo(tabuleiro, Cor.Branco));
            colocarNovaPeca('D', 1, new Dama(tabuleiro, Cor.Branco));
            colocarNovaPeca('E', 1, new Rei(tabuleiro, Cor.Branco, this));
            colocarNovaPeca('F', 1, new Bispo(tabuleiro, Cor.Branco));
            colocarNovaPeca('G', 1, new Cavalo(tabuleiro, Cor.Branco));
            colocarNovaPeca('H', 1, new Torre(tabuleiro, Cor.Branco));
            colocarNovaPeca('A', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('B', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('C', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('D', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('E', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('F', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('G', 2, new Peao(tabuleiro, Cor.Branco));
            colocarNovaPeca('H', 2, new Peao(tabuleiro, Cor.Branco));

            colocarNovaPeca('A', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('B', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('C', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('D', 8, new Dama(tabuleiro, Cor.Preta));
            colocarNovaPeca('E', 8, new Rei(tabuleiro, Cor.Preta, this));
            colocarNovaPeca('F', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('G', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('H', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('A', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('B', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('C', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('D', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('E', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('F', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('G', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('H', 7, new Peao(tabuleiro, Cor.Preta));
        }
    }
}
