using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_CV7
{
    class RocniTeplota
    {
        private double rok;
        private List<double> mesicniTeploty = new List<double>();
      
        public RocniTeplota(double rok, List<double> mesicniTeploty)
        {
            this.rok = rok;
            this.mesicniTeploty = mesicniTeploty;
        }

        public double Rok { get => rok; set => rok = value; }
        public List<double> MesicniTeploty { get => mesicniTeploty; set => mesicniTeploty = value; }
        public double MaxTeplota { get => mesicniTeploty.Max(); }
        public double MinTeplota { get => mesicniTeploty.Min();  }
        public double PrumRocniTeplota { get => mesicniTeploty.Average();  }
    }
}
