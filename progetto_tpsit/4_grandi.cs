using System.Drawing;

partial class Magazzino
{
    // REPARTO PACCHI GRANDI
    static void DepositoGrandi()
    {
        while (true)
        {
            lock (monitor)
            {
                //se e' gia' pieno aspetta
                if (prodottiGrandi == capacitaGrandi)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiGrandi++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deposito PACCHI GRANDI: ho depositato un pacco. Totale: " + prodottiGrandi);
                Console.ResetColor();

                //avvisa gli altri che c'e' qualcosa
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(1800);
        }
    }

    static void PrelievoGrandi()
    {
        while (true)
        {
            lock (monitor)
            {
                //se non c'e' nulla si ferma
                if (prodottiGrandi == 0)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiGrandi--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Prelievo PACCHI GRANDI: ho prelevato un pacco. Totale: " + prodottiGrandi);
                Console.ResetColor();

                //avvisa gli altri che c'e' di nuovo spazio
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(2000);
        }
    }
}