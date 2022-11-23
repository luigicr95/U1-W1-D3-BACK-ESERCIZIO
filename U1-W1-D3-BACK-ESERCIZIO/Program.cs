using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D3_BACK_ESERCIZIO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ContoCorrente CC = new ContoCorrente();

            string scelta = "";

            do
            {
                Console.WriteLine("Seleziona la scelta");
                Console.WriteLine("1. APRI CONTO CORRENTE");
                Console.WriteLine("2. PRELIEVO");
                Console.WriteLine("3. VERSAMENTO");
                scelta = Console.ReadLine();
                if (scelta == "1")
                {
                    Console.WriteLine("APERTURA CONTO CORRENTE");
                    CC.Apertura = true;
                    Console.WriteLine("Nome Intestatario:");
                    CC.NomeIntestatario = Console.ReadLine();
                    Console.WriteLine("Cognome Intestatario:");
                    CC.CognomeIntestatario = Console.ReadLine();
                    Console.WriteLine($"Conto Corrente di {CC.NomeIntestatario} {CC.CognomeIntestatario} ID: 22234451 aperto correttamente! \r\n" +
                        $"E' necessario effettuare un versamento iniziale di almeno 1000 euro \r\n" +
                        $"Digitare l'importo:");
                    int cifraVersata = int.Parse(Console.ReadLine());
                    CC.VersamentoIniziale(cifraVersata);

                }
                else if (scelta == "2")
                {
                    if (CC.Apertura == false)
                    {
                        Console.WriteLine("Devi aprire un conto per effettuare un prelievo!");
                    }
                    else
                    {
                        Console.WriteLine("PRELIEVO");
                        Console.WriteLine($"Saldo attuale: {CC.Saldo}");
                        Console.WriteLine("Inserire l'importo da prelevare:");
                        int cifraPrelevata = int.Parse(Console.ReadLine());
                        CC.Prelievo(cifraPrelevata);
                        Console.WriteLine($"Saldo attuale: {CC.Saldo}");
                    }
                }
                else if (scelta == "3")
                {
                    if (CC.Apertura == false)
                    {
                        Console.WriteLine("Devi aprire un conto per effettuare un versamento!");
                    }
                    else
                    {
                        Console.WriteLine("VERSAMENTO");
                        Console.WriteLine($"Saldo attuale: {CC.Saldo}");
                        Console.WriteLine("Inserire l'importo da versare" +
                            ":");
                        int cifraVersata = int.Parse(Console.ReadLine());
                        CC.Versamento(cifraVersata);
                        Console.WriteLine($"Saldo attuale: {CC.Saldo}");
                    }
                }
                else
                {
                    Console.WriteLine("Scelta non valida");
                }
            } while (scelta != "1" | scelta != "2" | scelta != "3");


        

            Console.ReadLine();


        }

        public class ContoCorrente
        {
            public string NomeIntestatario { get; set; }
            public string CognomeIntestatario { get; set; }
            public int Saldo { get; set; } = 0;
            public bool Apertura { get; set; } = false;

            public void Prelievo (int cifra)
            {
                if (Saldo < cifra)
                {
                    Console.WriteLine("Saldo disponibile insufficiente!");
                }
                else
                {
                    Saldo = Saldo - cifra;
                }
                
            }
            public void Versamento (int cifra)
            {
                Saldo = Saldo + cifra;
            }

            public void VersamentoIniziale(int cifra)
            {
                if (cifra < 1000)
                {
                    Console.WriteLine("Il versamento deve essere pari ad almeno 1000 euro");
                }
                else
                {
                    Saldo = Saldo + cifra;
                }
            }
        }
    }
}
