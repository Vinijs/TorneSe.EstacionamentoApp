using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public class VeiculoBusiness : IVeiculoBusiness
{
    private readonly IVeiculoDAO _veiculoDAO;
    private readonly IReservaVagaVeiculoDAO _reservaVagaVeiculoDAO;
    private readonly IVagaDAO _vagaDAO;
    public VeiculoBusiness(IVeiculoDAO veiculoDAO, 
                           IReservaVagaVeiculoDAO reservaVagaVeiculoDAO,
                           IVagaDAO vagaDAO)
    {
        _veiculoDAO = veiculoDAO;
        _reservaVagaVeiculoDAO = reservaVagaVeiculoDAO;
        _vagaDAO = vagaDAO;
    }

    public async Task<List<Veiculo>> ObterPorPlaca(string placa) 
        => await _veiculoDAO.BuscarVeiculosPorPlaca(placa);

    public async Task RealizarEntradaVeiculo(Veiculo veiculo, int idVaga,string nomeCondutor, string documentoCondutor)
    {
        if(veiculo.Id is default(int))
            veiculo.Id = await _veiculoDAO.Inserir(veiculo);
            
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
