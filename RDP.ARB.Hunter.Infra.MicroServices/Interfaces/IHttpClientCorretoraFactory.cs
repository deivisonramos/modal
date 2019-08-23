using System;
using System.Collections.Generic;
using System.Text;

namespace RDP.ARB.Hunter.Infra.MicroServices.Interfaces
{
    public interface IHttpClientCorretoraFactory
    {
        IHttpClientCorretora ObtemHttpClientPorCorretora(string corretora);
    }
}
