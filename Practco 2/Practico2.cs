using ConsoleApp1.Ejs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Practco_2
{
    internal class Practico2
    {
        public Ej2BinaryConverter Ej2;
        public Ej3_StairClimb Ej3;
        public Ej7_Impresoras Ej7;
        public Practico2()
        {
            Ej2 = new Ej2BinaryConverter();
            Ej3 = new Ej3_StairClimb();
            Ej7 = new Ej7_Impresoras();

        }

    }
}
