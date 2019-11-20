using System;

public static class ilkProje{
    static void Main(string[] args){
        //Ekrana Yazı yaz
        string ad = BanaAdSoyadVer();
        Console.WriteLine(ad);
        Console.ReadKey();
    }

    static string BanaAdSoyadVer(){
        return "Enes Behlül Yenidünya";
    }

    static void EkranaYaziYaz(){
        Console.WriteLine("Enes Behlül Yenidünya");
    }
}