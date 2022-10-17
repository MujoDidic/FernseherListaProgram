/*################################################
 * Einsendeaufgabe 5.1
 * #############################################*/
using System;

namespace Fernseher
{
    class Program
    {
        static void Main(string[] args)
        {

            EinAusGeschaltet FernEin = new EinAusGeschaltet();
            
            LautsprecherClass LautSprecherInput = new LautsprecherClass();
            
            ProgramAendern AndereProgramm = new ProgramAendern();

            SendungListe HauptListe = new SendungListe();

            do
            {
                Console.Clear();
                if (FernEin.EinSchalten() == true)
                {
                    Console.WriteLine("Fernseher ist Eingeschaltet!!!");
                }
                else
                {
                    Console.WriteLine("Fernseher ist Ausgeschaltet!!!");
                }

                Console.WriteLine("Lautstärke: {0}", LautSprecherInput.LautsprecherZustand());

                Console.WriteLine("Aktuelle Programm: {0}", AndereProgramm.AktuelleProgrammNummer());


                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Program: {0}", HauptListe.ZeigenSendungNummer());
                Console.WriteLine("Liste:");


                if (HauptListe.ZeigenSendungNummer() == 0)
                {

                    Console.WriteLine("  Liste ist leer!\n   Bitte Taste 4 drucken.");
                }
                else
                {
                    //HauptListe.ListeZeigen();
                    //HauptListe.ListeZeigenRuckwaerts();

                    if (AndereProgramm.ListeVersionZurückLiefern() == true)
                    {
                        HauptListe.ListeZeigen();
                    }
                    else
                    {
                        HauptListe.ListeZeigenRuckwaerts();
                    }
                }


                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
                Console.WriteLine("Fernseher Einschalten  [1] ");
                Console.WriteLine("Lautstärke ändern      [2] ");
                Console.WriteLine("Programm ändern        [3] ");
                Console.WriteLine("Liste Neue/Erweitern   [4] ");
                Console.WriteLine("Liste rückwärts zeigen [5] ");
                Console.WriteLine("Fernseher ausschalten  [6] ");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
                int eingabe = Convert.ToInt32(Console.ReadLine());

                switch (eingabe)
                {
                    case 1:
                        if (FernEin.EinSchalten() == false)
                        {
                            FernEin.FerStart();
                        }
                        else
                        {
                            Console.WriteLine("Fernseher ist schon Eingeschaltet!!!");
                        }
                        break;
                    
                    case 2:
                        if (FernEin.EinSchalten() == true)
                        {
                            LautSprecherInput.Lautstaerke();
                        }
                        else
                        {
                            Console.WriteLine("Schalten Sie bitte erst Fernseher ein!!!");
                        }
                        break;

                    case 3:
                        if (FernEin.EinSchalten() == true)
                        {
                            Console.Write("Program zu ändern geben Sie Nummer bis {0} ein:", HauptListe.ZeigenSendungNummer());
                            int programmWahl = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i <= HauptListe.ZeigenSendungNummer(); i++)
                            {
                                if (i == programmWahl)
                                {
                                    AndereProgramm.ProgrammNummerAendern(programmWahl);
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Schalten Sie bitte erst Fernseher ein!!!");
                        }
                        break;

                    case 4:

                        if (FernEin.EinSchalten() == true)
                        {
                            Console.Write("Druckem Sie Taste 4:");
                            int neuProgramm = Convert.ToInt32(Console.ReadLine());
                            if (neuProgramm == 4)
                            {

                                HauptListe.ListeErweitern(HauptListe.SendungNameZeigen(), HauptListe.ZeigenSendungNummer());
                            }
                            else
                            {
                                do
                                {
                                    //Console.Clear();
                                    Console.WriteLine("Bitte drucken Sie richtige Taste!!!");
                                    Console.Write("Druckem Sie Taste 4:");
                                    neuProgramm = Convert.ToInt32(Console.ReadLine());

                                    if (neuProgramm == 4)
                                        HauptListe.ListeErweitern(HauptListe.SendungNameZeigen(), HauptListe.ZeigenSendungNummer());
                                } while (neuProgramm != 4);



                            }

                        }
                        else
                        {
                            Console.WriteLine("Schalten Sie bitte erst Fernseher ein!!!");
                        }
                        break;

                    case 5:

                        AndereProgramm.ListeVersionAendern();

                        break;

                    case 6:

                        FernEin.FerStop();

                        break;


                }
            } while (true);

        }//Ende Main Methode



    } //Ende class Program



    class EinAusGeschaltet
    {

        bool einAus = true;

        private void ZustandAendern(bool einAus) // Änderen der Zustand von "bool einAus" in false oder true
        {
            this.einAus = einAus;
        }

        public bool EinSchalten() // Zurück geben wert von "bool einAus"
        {
            return einAus;
        }

        public void FerStart() //Fernseher einschalten
        {
            if (einAus == false)

                ZustandAendern(true);

        } //Ende Methode FerStart()


        public void FerStop() //Fernseher auschalten
        {
            Console.Clear();
            Console.WriteLine(EinSchalten());

            if (einAus != false)
                ZustandAendern(false);
        } // Ende Methode FerStop()

    }//Ende class EinAusgeschaltet



    class LautsprecherClass
    {
        private int lautSprecherInt = 0;

        public void LautsprecherZustandAendern(int lautSprecherInt) // Änderen der Zustand von "bool einAus" in false oder true
        {
            this.lautSprecherInt = lautSprecherInt;
        }

        public int LautsprecherZustand() // Zurück geben wert von "bool einAus"
        {
            return lautSprecherInt;
        }
        public void Lautstaerke()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("Lautstärke zu ändern geben Sie Nummer von 0 bis 10 ein:");

            int eingabeNummer = Convert.ToInt32(Console.ReadLine());





            if (eingabeNummer <= 10)
            {
                LautsprecherZustandAendern(eingabeNummer);

            }
            else
            {
                Console.WriteLine("Bitte geben Sie richtige Nummer ein!!!");
                Lautstaerke();

            }


            Console.WriteLine("\n-------------------------------");


        }//Ende Methode Lautstaerke

    }//Ende class  LautsprecherClass 


    class ProgramAendern
    {

        SendungListe ProgrammNummerDurchAndereClassAendern = new SendungListe();

        private bool listeVersion = true;

        private int programmNummerInt;

        public void ProgrammNummerAendern(int argProgrammNummerInt) // Änderen Programmnummer
        {
            programmNummerInt = argProgrammNummerInt;
        }

        public int AktuelleProgrammNummer() // Liefertzurück aktuele Sendungnummer
        {
            return programmNummerInt;
        }

        public bool ListeVersionZurückLiefern()
        {
            return listeVersion;
        }

        public void ListeVersionAendern()
        {
            if (listeVersion == true)
            {
                listeVersion = false;

            }
            else
            {
                listeVersion = true;
            }
        }


    }//Ende Class ProgramAendern


    class SendungListe
    {
        

        private string sendung = "Programm";

        SendungListe Verbindung;

        private int sendungNummer = 0;


        public string SendungNameZeigen()
        {
            return sendung;
        }

        public int ZeigenSendungNummer()
        {
            return sendungNummer;
        }

        


        //Liste Anfang
        public void ListeStellen(string argSendung)
        {
            Verbindung = null;
            this.sendung = argSendung;
            sendungNummer = 1;
        }

        //Neue Sendung an der Liste stellen
        public void ListeErweitern(string argSendung, int argProgrammNummer)
        {
            if (Verbindung == null)
            {
                Verbindung = new SendungListe();
                Verbindung.ListeStellen(sendung);

                sendungNummer += 1;
            }
            //Methode ruft sich
            else
            {
                Verbindung.ListeErweitern(argSendung, argProgrammNummer);

                sendungNummer++;
            }

        }//Ende Methode ListeErweitern


        

        public void ListeZeigen()
        {
            if (Verbindung != null && Verbindung.sendungNummer > 0)
            {
                Verbindung.ListeZeigen();
                Console.WriteLine(sendung + " " + Verbindung.sendungNummer);
            }


        }


        public void ListeZeigenRuckwaerts()
        {
            if (Verbindung != null && Verbindung.sendungNummer > 0)
            {
                Console.WriteLine(sendung + " " + Verbindung.sendungNummer);
                Verbindung.ListeZeigenRuckwaerts();
            }


        }

    }//Ende class SendungListe

}//Ende Namespace Fernseher




