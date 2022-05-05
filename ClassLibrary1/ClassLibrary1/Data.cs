using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1;

public class Data : IData
{
    public string GetSomething()
    {
        return "42";
    }
}
