using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Rei : Peca {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca != null && peca is Torre && peca.cor == cor && peca.qtdMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matrizDePossibilidades = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matrizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Jogada Especial
            if (qtdMovimentos == 0 && !partida.xeque) {
                //(Roque Pequeno)
                Posicao posicaoTorre1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posicaoTorre1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null) {
                        matrizDePossibilidades[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //(Roque Grande)
                Posicao posicaoTorre2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posicaoTorre2)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null) {
                        matrizDePossibilidades[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return matrizDePossibilidades;
        }
    }
}
