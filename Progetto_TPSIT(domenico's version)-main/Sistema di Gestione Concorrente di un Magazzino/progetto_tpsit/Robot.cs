using System;
using System.Threading;

namespace progetto_tpsit
{
    public class Robot
    {
        private Reparto repartoAssegnato;
        private int tempoLavoro;
        private bool faDeposito; // true = deposita, false = preleva

        // Costruttore: istruzioni per il robot
        public Robot(Reparto r, int millisecondi, bool deposito)
        {
            repartoAssegnato = r;
            tempoLavoro = millisecondi;
            faDeposito = deposito;
        }

        public void Lavora()
        {
            while (true)
            {
                // Guarda la sua mansione e chiama il metodo giusto del suo reparto
                if (faDeposito)
                {
                    repartoAssegnato.Deposita();
                }
                else
                {
                    repartoAssegnato.Preleva();
                }

                Thread.Sleep(tempoLavoro); // Riposa in base alla sua velocità
            }
        }
    }
}