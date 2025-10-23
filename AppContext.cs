using ConsoleApp1.Practco_2;
using ConsoleApp1.Practico_3;
using ConsoleApp1.DATs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Practica_4;

namespace ConsoleApp1
{
    internal class AppContext
    {
        public Practico2 Practico2;
        public Practico3 Practico3;
        public Practico4 Practico4;
        public DAT_s DATs;

        public AppContext()
        {
            DATs = new DAT_s();
            Practico2 = new Practico2();
            Practico3 = new Practico3();
            Practico4 = new Practico4();
        }
    }
}
