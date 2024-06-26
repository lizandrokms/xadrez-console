﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {
                    try {
                        Console.Clear();

                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);

                    }
                    catch (TabuleiroException ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (TabuleiroException ex) {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}