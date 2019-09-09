using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLab1.Abstractions
{
    internal interface ICryptPolicy<TCryptModel>
    {
        TCryptModel Encrypt(TCryptModel cryptModel);
        TCryptModel Decrypt(TCryptModel cryptModel);
    }
}
