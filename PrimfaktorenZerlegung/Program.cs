using System;
using System.Collections.Generic;

namespace PrimfaktorenZerlegung {
  class Program {
    static void Main(string[] args) {
      string benutzerEingabe;
      long zahlZumTesten;
      List<long> faktorenListe = new List<long>();

      while((benutzerEingabe = Eingabe("Eingabe:")) != "exit") {
        if(long.TryParse(benutzerEingabe, out zahlZumTesten)) {
          faktorenListe = BerechneFaktorenListe(zahlZumTesten);
          switch(faktorenListe.Count) {
            case 0:
              Console.WriteLine("1 oder minus Zahl!");
              break;
            case 1:
              Console.WriteLine($"Die Zahl {zahlZumTesten} ist eine Primzahl!");
              break;
            default:
              ZeigeFaktorenListe(faktorenListe); 
              break;
          }
        } else {
          CheckeBenutzerKommando(benutzerEingabe);
        }
      }
    }

    static string Eingabe(string label) {
      string result;
      Console.Write(label + " ");
      result = Console.ReadLine();
      return result;
    }

    static void CheckeBenutzerKommando(string eingabe) {
      switch(eingabe) {
        default:
          Console.WriteLine($"Kommando {eingabe} nicht gefunden!");
          break;
      }
    }

    static List<long> BerechneFaktorenListe(long pruefZahl) {
      long
        teiler = 2,
        berechneteZahl = pruefZahl;
      List<long> faktorenListe = new List<long>();
      Console.WriteLine($"Berechne Primzahlfaktoren für {pruefZahl}...");

      while(berechneteZahl > teiler) {
        if(berechneteZahl % teiler == 0) {
          faktorenListe.Add(teiler);
          berechneteZahl /= teiler;
        } else {
          teiler++;
        }
      }
      if(berechneteZahl == teiler) {
        faktorenListe.Add(teiler);
      }

      return faktorenListe;
    }

    static void ZeigeFaktorenListe(List<long> faktorenListe) {
      for(int i = 0; i < faktorenListe.Count-1; i++) {
        Console.Write($"{faktorenListe[i]} * ");
      }
      Console.WriteLine($"{faktorenListe[^1]}");
    }
  }
}
