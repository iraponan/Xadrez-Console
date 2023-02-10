using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Peao : Peca {

        private PartidaDeXadrez partida;

        public Peao(Tabuleiro.Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) { 
            this.partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca != null && peca.cor != cor;
        }

        private bool livre(Posicao posicao) {
            return tabuleiro.peca(posicao) == null;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matrizDePossibilidades = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branco) {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                // Jogada Especial En Passant
                if (posicao.linha == 3) {
                    //Esquerda
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        matrizDePossibilidades[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    //Direita
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        matrizDePossibilidades[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    matrizDePossibilidades[pos.linha, pos.coluna] = true;
                }
                // Jogada Especial En Passant
                if (posicao.linha == 4) {
                    //Esquerda
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        matrizDePossibilidades[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    //Direita
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        matrizDePossibilidades[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }

            return matrizDePossibilidades;
        }
    }
}
