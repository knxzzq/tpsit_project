using System;
using System.Threading;

namespace progetto_tpsit
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("AVVIO MAGAZZINO MULTI-REPARTO");
            Console.WriteLine("-----------------------------");

            // 1. Costruiamo i 3 reparti indipendenti (ognuno ha il suo lucchetto)
            Reparto repPiccoli = new Reparto("PICCOLI", 15);
            Reparto repMedi = new Reparto("MEDI", 10);
            Reparto repGrandi = new Reparto("GRANDI", 5);

            // 2. Creiamo i Robot per i pacchi piccoli (Reparto, Velocità, true=Deposito/false=Prelievo)
            Robot depPiccoli = new Robot(repPiccoli, 800, true);
            Robot prelPiccoli = new Robot(repPiccoli, 1000, false);

            // 3. Creiamo i Robot per i pacchi medi
            Robot depMedi = new Robot(repMedi, 1200, true);
            Robot prelMedi = new Robot(repMedi, 1400, false);

            // 4. Creiamo i Robot per i pacchi grandi
            Robot depGrandi = new Robot(repGrandi, 1800, true);
            Robot prelGrandi = new Robot(repGrandi, 2000, false);

            // 5. Assegniamo le mansioni ai Thread e li facciamo partire!
            new Thread(depPiccoli.Lavora).Start();
            new Thread(prelPiccoli.Lavora).Start();

            new Thread(depMedi.Lavora).Start();
            new Thread(prelMedi.Lavora).Start();

            new Thread(depGrandi.Lavora).Start();
            new Thread(prelGrandi.Lavora).Start();
        }
    }
}