class Program
{
    //variabile che mostra la quantita' di prodotti in magazzino
    static int prodotti = 0;

    //capacita' massima del magazzino
    static int capacita = 10;

    //variabile condivisa che indica se lo scaffale e' libero
    static bool scaffaleLibero = true;

    //metodo eseguito dai robot che depositano prodotti
    static void RobotDeposito()
    {
        while (true) //il robot lavora finche' lo scaffale e' libero
        {
            //controlla se lo scaffale e' libero

            if (scaffaleLibero)
            {
                //occupa lo scaffale
                scaffaleLibero = false;

                //controlla se il magazzino ha ancora spazio
                if (prodotti < capacita)
                {
                    Console.WriteLine("Robot DEPOSITO aggiunge un prodotto");

                    //simula il tempo necessario per depositare il prodotto
                    Thread.Sleep(1000);

                    //controllo di sicurezza
                    if (prodotti < capacita)
                    {
                        prodotti++; //aumenta il numero di prodotti
                    }
                    Console.WriteLine("Prodotti nel magazzino: " + prodotti);
                }
                else
                {
                    //il magazzino e' pieno
                    Console.WriteLine("Magazzino pieno");
                }
                //libera lo scaffale
                scaffaleLibero = true;
            }
            //pausa prima di riprovare
            Thread.Sleep(1000);
        }
    }

    //metodo eseguito dai robot che prelevano prodotti
    static void RobotPrelievo()
    {
        while (true) //il robot lavora finche' lo scaffale e' libero
        {
            //controlla se lo scaffale e' libero
            if (scaffaleLibero)
            {
                //occupa lo scaffale
                scaffaleLibero = false;

                //controlla se ci sono prodotti disponibili
                if (prodotti > 0)
                {
                    Console.WriteLine("Robot PRELIEVO prende un prodotto");

                    //simula il tempo necessario per il prelievo
                    Thread.Sleep(1000);

                    //controllo di sicurezza
                    if (prodotti > 0)
                    {
                        prodotti--; //diminuisce il numero di prodotti
                    }
                    Console.WriteLine("Prodotti nel magazzino: " + prodotti);
                }
                else
                {
                    //il magazzino e' vuoto
                    Console.WriteLine("Magazzino vuoto");
                }
                //libera lo scaffale
                scaffaleLibero = true;
            }
            //pausa prima di riprovare
            Thread.Sleep(1000);
        }
    }

    static void Main(string[] args)
    {
        //riempiamo il magazzino con random prodotti
        Random rnd = new Random();
        prodotti = rnd.Next(1, 10); //genera un numero da 1 a 9

        Console.WriteLine("Numero iniziale di prodotti nel magazzino: " + prodotti);

        //creazione dei thread dei robot di deposito
        Thread deposito1 = new Thread(RobotDeposito);
        Thread deposito2 = new Thread(RobotDeposito);

        //creazione dei thread dei robot di prelievo
        Thread prelievo1 = new Thread(RobotPrelievo);
        Thread prelievo2 = new Thread(RobotPrelievo);

        //avvio dei robot di deposito
        deposito1.Start();
        deposito2.Start();

        //avvio dei robot di prelievo
        prelievo1.Start();
        prelievo2.Start();
    }
}