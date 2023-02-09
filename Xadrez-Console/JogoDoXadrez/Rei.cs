﻿using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.JogoDoXadrez {
    internal class Rei : Peca {
        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao posicao) {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matizDePossibilidades = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            //Noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matizDePossibilidades[pos.linha, pos.coluna] = true;
            }

            return matizDePossibilidades;
        }
    }
}
