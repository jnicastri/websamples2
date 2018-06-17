using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Data.Foundation
{
    interface IDTO { }

    interface IWebDTOable<T> where T : IDTO
    {
        T ToWebDTO();
    }

    interface IInternalDTO<T> where T : IDTO
    {
        T ToInternalDTO();
    }
}
