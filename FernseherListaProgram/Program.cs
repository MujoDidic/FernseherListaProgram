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

            
            //int aktueleSendung = 0;
            

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
                

                Console.WriteLine("Aktuele Programm: {0}",AndereProgramm.AktueleProgrammNummer());

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Program: {0}", HauptListe.ZeigenSendungNummer());
                Console.WriteLine("Liste:");
               

                if (HauptListe.ZeigenSendungNummer() == 0)
                {
                    
                    Console.WriteLine("  Liste ist leer!\n   Bitte Taste 4 drucken.");
                }
                else
                {
                    HauptListe.ListeZeigen();
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
                            // Console.Clear();
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
                            if (neuProgramm == 4 )
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

        bool einAus = false;

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
        
        private int programmNummerInt;

        public void ProgrammNummerAendern(int argProgrammNummerInt) // Änderen Programmnummer
        {
            programmNummerInt = argProgrammNummerInt;
        }

        public int AktueleProgrammNummer()
        {
            return programmNummerInt;
        }

        

        //public void ProgrammSteuerung(int argProgrammNummerInt)
        //{
        //    if (ProgrammNummerDurchAndereClassAendern.ZeigenSendungNummer() == argProgrammNummerInt && argProgrammNummerInt < programmNummerInt + 1)
        //    {
        //        //ProgrammNummerAendern(argProgrammNummerInt);
        //        programmNummerInt = argProgrammNummerInt;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Geben Sie bitte eralubte Nummer ein!");
        //    }

        //    //ProgrammNummerAendern(argProgrammNummerInt); ovako radi




        //}//Ende Methode ProgrammSteuerung

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
        public void ListeErweitern(string argSendung,int argProgrammNummer)
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

        }



        public void ListeZeigen()
        {
            if(Verbindung != null && Verbindung.sendungNummer > 0)
            {
                Verbindung.ListeZeigen();
                Console.WriteLine(sendung + " " + Verbindung.sendungNummer);
            }
            
            
        }





        public void GetNth(int index)
        {
            if (Verbindung != null && Verbindung.sendungNummer == index)
            {
                Verbindung.ListeZeigen();
            }
           
                
           
        }


        //public int GetNth(int index)
        //{
        //    Node current = head;
        //    int count = 0; /* index of Node we are
        //                currently looking at */
        //    while (current != null)
        //    {
        //        if (count == index)
        //            return current.data;
        //        count++;
        //        current = current.next;
        //    }


        //}




    }//Ende class SendungListe




}//Ende Namespace Fernseher




