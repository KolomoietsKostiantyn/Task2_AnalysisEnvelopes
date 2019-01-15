using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateLvl
{
    public interface IUI
    {
        event CompareEnvelopes CompareEnvelopesDesc;
        event SendData SendDataDesc;

    }
}
