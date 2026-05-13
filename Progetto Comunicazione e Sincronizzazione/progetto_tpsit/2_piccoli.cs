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
                while (prodottiPiccoli == capacitaPiccoli)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiPiccoli++;
                Console.WriteLine("Deposito PACCHI PICCOLI: ho depositato un pacco. Totale: " + prodottiPiccoli);

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
                while (prodottiPiccoli == 0)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiPiccoli--;
                Console.WriteLine("Prelievo PACCHI PICCOLI: ho prelevato un pacco. Totale: " + prodottiPiccoli);

                //avvisa gli altri che c'e' di nuovo spazio
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(1000);
        }
    }
}