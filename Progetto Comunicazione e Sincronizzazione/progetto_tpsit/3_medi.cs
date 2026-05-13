partial class Magazzino
{
    // REPARTO PACCHI MEDI
    static void DepositoMedi()
    {
        while (true)
        {
            lock (monitor)
            {
                //se e' gia' pieno aspetta
                while (prodottiMedi == capacitaMedi)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiMedi++;
                Console.WriteLine("Deposito PACCHI MEDI: ho depositato un pacco. Totale: " + prodottiMedi);

                //avvisa gli altri che c'e' qualcosa
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(1200);
        }
    }

    static void PrelievoMedi()
    {
        while (true)
        {
            lock (monitor)
            {
                //se non c'e' nulla si ferma
                while (prodottiMedi == 0)
                {
                    Monitor.Wait(monitor); //sospende e aspetta
                }

                prodottiMedi--;
                Console.WriteLine("Prelievo PACCHI MEDI: ho prelevato un pacco. Totale: " + prodottiMedi);

                //avvisa gli altri che c'e' di nuovo spazio
                Monitor.PulseAll(monitor);
            }
            Thread.Sleep(1400);
        }
    }
}