using System;
using System.Threading;

namespace progetto_tpsit
{
    public class Reparto
    {
        public string NomeCategoria { get; } // "Piccoli", "Medi" o "Grandi"
        private int prodotti = 0;
        private int capacita;
        
        // Ogni reparto ha la sua porta e la sua chiave!
        private readonly object lucchetto = new object();

        // Costruttore: quando creiamo il reparto, decidiamo come si chiama e quanto è grande
        public Reparto(string nome, int capacitaMassima)
        {
            NomeCategoria = nome;
            capacita = capacitaMassima;
        }

        public void Deposita()
        {
            lock (lucchetto)
            {
                while (prodotti == capacita)
                {
                    Monitor.Wait(lucchetto);
                }

                prodotti++;
                Console.WriteLine($"[+] Deposito PACCHI {NomeCategoria}: pacco inserito. Totale: {prodotti}");
                Monitor.PulseAll(lucchetto);
            }
        }

        public void Preleva()
        {
            lock (lucchetto)
            {
                while (prodotti == 0)
                {
                    Monitor.Wait(lucchetto);
                }

                prodotti--;
                Console.WriteLine($"[-] Prelievo PACCHI {NomeCategoria}: pacco rimosso. Totale: {prodotti}");
                Monitor.PulseAll(lucchetto);
            }
        }
    }
}