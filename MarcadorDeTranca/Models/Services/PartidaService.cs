namespace MarcadorDeTranca.Models.Services
{
    public class PartidaService
    {
        private Partida _partida;

        public PartidaService(Partida partida)
        {
            _partida = partida;
        }

        public void AdicionarJogador(string nome)
        {

            _partida.Jogadores.Add(new Jogador(nome));

        }

        public void RegistrarPontuacao(int rodada, string nomeJogador, int pontosCanastras, int pontosCartas)
        {
            var jogador = _partida.Jogadores.FirstOrDefault(j => j.Nome == nomeJogador);
            if (jogador != null)
            {
                jogador.Pontos += pontosCanastras + pontosCartas;
                _partida.Rodadas.Add(new Rodada
                {
                    Numero = rodada,
                    NomeQueDaCartas = nomeJogador,
                    PontosCanastras = pontosCanastras,
                    PontosCartas = pontosCartas
                });
            }
        }

        public bool VerificarSeAlguemVenceu(out string vencedor)
        {
            return _partida.VerificarVencedor(out vencedor);
        }
    }
}
