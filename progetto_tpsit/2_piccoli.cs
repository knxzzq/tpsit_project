partial class Magazzino
{
    //REPARTO PACCHI PICCOLI
    static void DepositoPiccoli()
    {
        while (true)
        {
            lock (monitor)
            {
                //se e' gia' pieno aspetta
                if (prodottiPiccoli == capacitaPiccoli)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiPiccoli++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deposito PACCHI PICCOLI: ho depositato un pacco. Totale: " + prodottiPiccoli);
                Console.ResetColor();

                //avvisa gli altri che c'e' qualcosa
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(800);
        }
    }

    static void PrelievoPiccoli()
    {
        while (true)
        {
            lock (monitor)
            {
                //se non c'e' nulla si ferma
                if (prodottiPiccoli == 0)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiPiccoli--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Prelievo PACCHI PICCOLI: ho prelevato un pacco. Totale: " + prodottiPiccoli);
                Console.ResetColor();

                //avvisa gli altri che c'e' di nuovo spazio
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(1000);
        }
    }
}