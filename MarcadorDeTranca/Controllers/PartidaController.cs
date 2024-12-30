using MarcadorDeTranca.Models.Services;
using MarcadorDeTranca.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarcadorDeTranca.Controllers
{
    public class PartidaController : Controller
    {
        private static Partida _partida = new Partida();
        private static PartidaService _partidaService = new PartidaService(_partida);

        public IActionResult Index()
        {
            if (_partida.Jogadores == null) 
            {
                _partida.Jogadores = new List<Jogador>();
            }
            return View(_partida);
        }

        [HttpPost]
        public IActionResult AdicionarJogador(string nome)
        {
            _partidaService.AdicionarJogador(nome);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RegistrarPontuacao(int rodada, string nomeJogador, int pontosCanastras, int pontosCartas)
        {
            _partidaService.RegistrarPontuacao(rodada, nomeJogador, pontosCanastras, pontosCartas);

            if (_partidaService.VerificarSeAlguemVenceu(out string vencedor))
            {
                TempData["Vencedor"] = vencedor;
                return RedirectToAction("Vencedor");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Vencedor()
        {
            TempData["Vencedor"] = TempData["Vencedor"] ?? "Nenhum vencedor definido";
            return View();
        }
    }

}
