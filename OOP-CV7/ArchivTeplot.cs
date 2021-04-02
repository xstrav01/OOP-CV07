using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace OOP_CV7
{
    class ArchivTeplot
    {
        private SortedDictionary<double, RocniTeplota> _archiv = new SortedDictionary<double, RocniTeplota>();

        public void Save(string path)
        {
            StreamWriter wr = File.CreateText(path);

            foreach (var item in _archiv.Values)
            {
                wr.Write(item.Rok + ": ");
                for (int i = 0; i < item.MesicniTeploty.Count; i++)
                {
                    if (i == item.MesicniTeploty.Count-1)
                    {
                        wr.Write("{0:0.0}", item.MesicniTeploty[i]);
                        break;
                    }
                    wr.Write("{0:0.0}; ", item.MesicniTeploty[i]);
                }
                wr.Write(Environment.NewLine);
            }
            wr.Close();
            Console.WriteLine("Ukládání dokončeno do soubouru: "+path);

        }

        public void Load(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            string line = null;
            double rok = 0;
            foreach (var item in lines)
            {
                
                line = item.Replace(" ", "");
                
                //Console.WriteLine(line);

                List<string> temps = line.Split(':', ';').ToList();
                List<double> tempsConverted = new List<double>();
                
                foreach (string value in temps)
                {
                    
                    double converted = Convert.ToDouble(value);
                    if (value == temps.First()) //pokud je prvni hodnota rok, skip
                    {
                        rok = converted;
                        continue;
                    }
                    tempsConverted.Add(converted);
                }
                _archiv.Add(rok, new RocniTeplota(rok, tempsConverted));

            }


        }

        public void TiskTeplot() {
            foreach (var item in _archiv.Values)
            {
                Console.Write(item.Rok+":  ");
                for (int i = 0; i < item.MesicniTeploty.Count; i++)
                {
                    Console.Write("{0:0.0}  ", item.MesicniTeploty[i]);
                }
                Console.WriteLine();
            }
        }

        public void TiskPrumernychRocnichTeplot() {
            foreach (var item in _archiv.Values)
            {
                Console.Write(item.Rok + ":  ");
                Console.WriteLine("{0:0.0}", item.PrumRocniTeplota);
            }
        }

        public void TiskPrumernychMesicnichTeplot() {
            Console.Write("Prum.: ");
            List<double> averMonth = new List<double>(12);
            for (int i = 0; i < 12; i++)
            {
                averMonth.Add(0);
            }
            foreach (var item in _archiv.Values)
            {
                for (int i = 0; i < item.MesicniTeploty.Count; i++)
                {
                    averMonth[i] += item.MesicniTeploty[i];
                }

            }
            for (int i = 0; i < 12; i++)
            {
                Console.Write("{0:0.0}  ", averMonth[i]/_archiv.Keys.Count);
            }
        }

        public void Kalibrace(double konst) {

            foreach (var item in _archiv.Values)
            {
                for (int i = 0; i < item.MesicniTeploty.Count; i++)
                {
                    item.MesicniTeploty[i] = item.MesicniTeploty[i] + konst;
                }
                
            }
            Console.WriteLine("\nKalibrování teplot o " + konst +":");
            TiskTeplot();
        }

        public void Vyhledej(double rok) {
            Console.WriteLine("Vyhledávání roku "+ rok+":");
            if (_archiv.ContainsKey(rok))
            {
                Console.Write(rok+":  ");
                for (int i = 0; i < _archiv[rok].MesicniTeploty.Count; i++)
                {
                    Console.Write("{0:0.0}  ", _archiv[rok].MesicniTeploty[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Rok {0} nenalezen.", rok);
            }
        }

        public void TiskMinimaVsechnyRoky() {
            foreach (var item in _archiv.Values)
            {
                Console.Write(item.Rok + ":  ");
                Console.WriteLine("{0:0.0}", item.MinTeplota);
            }

        }
        public void TiskMaximaVsechnyRoky()
        {
            foreach (var item in _archiv.Values)
            {
                Console.Write(item.Rok + ":  ");
                Console.WriteLine("{0:0.0}", item.MaxTeplota);
            }

        }
    }
}
