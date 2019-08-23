using RDP.ARB.Hunter.Application.Models;
using System;
using System.Collections.Generic;

namespace RDP.ARB.Hunter.Application.Services
{
    public interface IOrdensService
    {
        OrdensPorMoedaResult ObtemOrdensPorMoeda(OrdensPorMoedaRequest requestModel);
        SpreadPorMoedaResult ObtemSpreadPorMoeda(IEnumerable<OrdensPorCorretora> requestModel);
    }
}
