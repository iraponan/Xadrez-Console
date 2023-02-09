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
    }
}
