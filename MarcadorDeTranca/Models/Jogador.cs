﻿namespace MarcadorDeTranca.Models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Pontos { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Pontos = 0;
        }
    }
}
