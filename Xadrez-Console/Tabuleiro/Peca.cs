namespace Xadrez_Console.Tabuleiro {
    internal abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qtdMovimentos = 0;
        }

        public abstract bool[,] movimentosPossiveis();

        public void incrementarQtdMovimentos() {
            qtdMovimentos++;
        }

        public void decrementarQtdMovimentos() {
            qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis() {
            bool[,] matriz = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (matriz[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao posicao) {
            return movimentosPossiveis()[posicao.linha, posicao.coluna];
        }
    }
}
