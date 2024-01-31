using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIE
{
    internal interface IAuthControl
    {
        void Clear();

        bool IsValid();
        string ErrorMessage();
    }
}
