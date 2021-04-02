using System;
using System.Collections.Generic;

namespace OOP_CV7
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivTeplot archiv = new ArchivTeplot();
            archiv.Load(@"loadTeploty.txt");
            Console.WriteLine("Tisk teplot:");
            archiv.TiskTeplot();
            Console.WriteLine("Tisk průměrných ročních teplot:");
            archiv.TiskPrumernychRocnichTeplot();
            Console.WriteLine("Tisk průměrných měsíčních teplot:");
            archiv.TiskPrumernychMesicnichTeplot();
            archiv.Kalibrace(-0.1);
            archiv.Vyhledej(2010);
            archiv.Vyhledej(1998);
            archiv.Save(@"saveTeploty.txt"); //uloženo v místě spuštění programu (adresář Debug..)
            //minitask
            Console.WriteLine("Tisk minimálních ročních teplot:");
            archiv.TiskMinimaVsechnyRoky();
            Console.WriteLine("Tisk maximálních ročních teplot:");
            archiv.TiskMaximaVsechnyRoky();

        }
    }
}
