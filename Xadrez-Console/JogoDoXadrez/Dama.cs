using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Dama : Peca{
        public Dama(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString() {
            return "D";
        }

        private bool podeMover(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matrizDePossibilidades = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha, pos.coluna - 1);
            }

            //Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha, pos.coluna + 1);
            }

            //Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna);
            }

            //Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna);
            }

            //Noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }

            //Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }

            //Suldeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            //Suldoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }

            return matrizDePossibilidades;
        }
    }
}
