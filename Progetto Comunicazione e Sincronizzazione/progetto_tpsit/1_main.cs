partial class Magazzino
{
    //MONITOR
    static object monitor = new object();

    //VARIABILI PACCHI PICCOLI
    static int prodottiPiccoli = 0;
    static int capacitaPiccoli = 15;

    //VARIABILI PACCHI MEDI
    static int prodottiMedi = 0;
    static int capacitaMedi = 10;

    //VARIABILI PACCHI GRANDI
    static int prodottiGrandi = 0;
    static int capacitaGrandi = 5;

    static void Main()
    {
        Console.WriteLine("AVVIO MAGAZZINO");

        //robot per pacchi piccoli
        new Thread(DepositoPiccoli).Start();
        new Thread(PrelievoPiccoli).Start();

        //robot per pacchi medi
        new Thread(DepositoMedi).Start();
        new Thread(PrelievoMedi).Start();

        //robot per pacchi grandi
        new Thread(DepositoGrandi).Start();
        new Thread(PrelievoGrandi).Start();
    }
}