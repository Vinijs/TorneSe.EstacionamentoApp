using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Configs;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public class VeiculoBusiness : IVeiculoBusiness
{
    private readonly IVeiculoDAO _veiculoDAO;
    private readonly IReservaVagaVeiculoDAO _reservaVagaVeiculoDAO;
    private readonly IVagaDAO _vagaDAO;
    private readonly ConfiguracoesAplicacao _configuracoesAplicacao;
    public VeiculoBusiness(IVeiculoDAO veiculoDAO, 
                           IReservaVagaVeiculoDAO reservaVagaVeiculoDAO,
                           IVagaDAO vagaDAO,
                           IOptions<ConfiguracoesAplicacao> options)
    {
        _veiculoDAO = veiculoDAO;
        _reservaVagaVeiculoDAO = reservaVagaVeiculoDAO;
        _vagaDAO = vagaDAO;
        _configuracoesAplicacao = options.Value;
    }

    public async Task<List<Veiculo>> ObterPorPlaca(string placa) 
        => await _veiculoDAO.BuscarVeiculosPorPlaca(placa);

    public async Task<ResumoSaida> ObterResumoSaida(int idVeiculo, int idVaga)
    {
        var reservaVaga = await _reservaVagaVeiculoDAO.ObterReservaVagaVeiculo(idVeiculo, idVaga)
           ?? throw new Exception("Não foi possível encontrar a reserva da vaga");

        return new ResumoSaida
        {
            HoraEntrada = reservaVaga.HoraEntrada,
            HoraSaida = DateTime.Now,
            ValorHora = _configuracoesAplicacao.ValorHora,
        };
    }

    public async Task RealizarEntradaVeiculo(Veiculo veiculo, int idVaga,string nomeCondutor, string documentoCondutor)
    {

        if(veiculo.Id is default(int))
        {
            if (await _veiculoDAO.ExisteVeiculoComPlaca(veiculo.Placa))
                throw new Exception("O veiculo informado já ocupa alguma vaga");

            veiculo.Id = await _veiculoDAO.Inserir(veiculo);
        }

        if(!await _vagaDAO.ExisteVagaOcupadaComVeiculoInformado(veiculo.Id))
        {
            await _vagaDAO.MarcarComoOcupada(idVaga, veiculo.Id);
            await _reservaVagaVeiculoDAO.Inserir(new ReservaVagaVeiculo
            {
                IdVeiculo = veiculo.Id,
                IdVaga = idVaga,
                HoraEntrada = DateTime.Now,
                NomeCondutor = nomeCondutor,
                DocumentoCondutor = documentoCondutor
            });
        }
    }
}
