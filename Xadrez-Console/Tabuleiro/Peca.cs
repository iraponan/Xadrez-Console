﻿namespace Xadrez_Console.Tabuleiro {
    internal class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor) {
            this.posicao = posicao;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qtdMovimentos = 0;
        }
    }
}
