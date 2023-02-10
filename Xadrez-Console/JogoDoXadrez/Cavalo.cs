using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Cavalo : Peca {
        public Cavalo(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matizDePossibilidades = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            return matizDePossibilidades;
        }
    }
}
