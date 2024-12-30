namespace MarcadorDeTranca.Models
{
    public class Partida
    {
        public Guid Id { get; set; }
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();
        public List<Rodada> Rodadas { get; set; } = new List<Rodada>();
        public int PontuacaoMaxima { get; set; } = 5000;

        public Partida()
        {
            Id = Guid.NewGuid();
        }

        public bool VerificarVencedor(out string vencedor)
        {
            var ganhador = Jogadores.FirstOrDefault(j => j.Pontos >= PontuacaoMaxima);
            if (ganhador != null)
            {
                vencedor = ganhador.Nome;
                return true;
            }
            vencedor = string.Empty;
            return false;
        }
    }
}
