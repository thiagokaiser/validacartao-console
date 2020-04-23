using ValidaCartaoTest.Bandeiras;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidaCartaoTest.Interfaces
{
    public interface ICartaoService
    {        
        public CartaoBase ValidaCartao(string cartao);        
    }
}
