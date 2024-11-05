using System;
using System.Collections.Generic;

public class AdresDefteri
{
    // Kisi sınıfı, kişilerin ad, soyad ve telefon numarasını içerir
    public class Kisi
    {
        public string Ad { get; private set; }             // Kişinin adı
        public string Soyad { get; private set; }          // Kişinin soyadı
        public string TelefonNumarasi { get; private set; } // Kişinin telefon numarası

        // Yapıcı Metot: Ad, soyad ve telefon numarası bilgisi ile kişiyi başlatır
        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        // Kişinin bilgilerini (tam adı ve telefon numarasını) döndüren metot
        public string KisiBilgisi()
        {
            return $"Ad: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}";
        }
    }

    // Adres defteri listesi, kişileri tutmak için bir listeden oluşur
    private List<Kisi> kisiler;

    // Yapıcı Metot: Adres defterini başlatır ve kişi listesini oluşturur
    public AdresDefteri()
    {
        kisiler = new List<Kisi>();
    }

    // Adres defterine yeni bir kişi eklemek için metot
    public void KisiEkle(string ad, string soyad, string telefonNumarasi)
    {
        // Yeni bir Kisi nesnesi oluştur ve listeye ekle
        Kisi yeniKisi = new Kisi(ad, soyad, telefonNumarasi);
        kisiler.Add(yeniKisi);
        Console.WriteLine($"{ad} {soyad} adres defterine eklendi.");
    }

    // Adres defterindeki tüm kişilerin bilgilerini ekrana yazdıran metot
    public void TumKisileriListele()
    {
        Console.WriteLine("\nAdres Defterindeki Kişiler:");
        foreach (var kisi in kisiler)
        {
            Console.WriteLine(kisi.KisiBilgisi());
        }
    }
}

// Program sınıfı: Adres defterini ve kişileri yönetmek için ana sınıf
public class Program
{
    public static void Main(string[] args)
    {
        // Yeni bir adres defteri oluştur
        AdresDefteri adresDefteri = new AdresDefteri();

        // Adres defterine yeni kişiler ekle
        adresDefteri.KisiEkle("Ali", "Yılmaz", "123-456-7890");
        adresDefteri.KisiEkle("Ayşe", "Kara", "098-765-4321");
        adresDefteri.KisiEkle("Mehmet", "Çelik", "555-123-4567");

        // Adres defterindeki tüm kişileri listele
        adresDefteri.TumKisileriListele();
        Console.WriteLine();
        Console.ReadKey();
    }
}
