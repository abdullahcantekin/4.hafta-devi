using System;
using System.Collections.Generic;

// Kitap sınıfı, kitapların adını, yazarını ve yayın yılını içerir
public class Kitap
{
    public string Ad { get; private set; }           // Kitap adı
    public string Yazar { get; private set; }        // Kitap yazarı
    public int YayinYili { get; private set; }       // Kitap yayın yılı

    // Yapıcı Metot: Kitap adı, yazar ve yayın yılı bilgisi ile kitabı başlatır
    public Kitap(string ad, string yazar, int yayinYili)
    {
        Ad = ad;               // Kitap adını ayarla
        Yazar = yazar;        // Yazar adını ayarla
        YayinYili = yayinYili; // Yayın yılını ayarla
    }

    // Kitap bilgilerini döndüren metot
    public string KitapBilgisi()
    {
        return $"Kitap Adı: {Ad}, Yazar: {Yazar}, Yayın Yılı: {YayinYili}";
    }
}

// Kutuphane sınıfı, kitapları tutmak için kullanır
public class Kutuphane
{
    private List<Kitap> Kitaplar; // Kütüphanedeki kitapları saklamak için bir listeler

    // Yapıcı Metot: Kitap listesi boş olarak başlatır
    public Kutuphane()
    {
        Kitaplar = new List<Kitap>(); // Yeni bir kitap listesi oluşturur
    }

    // Yeni bir kitap eklemek için metot
    public void KitapEkle(Kitap yeniKitap)
    {
        // this anahtar kelimesiyle eklenen kitabın kütüphaneye ait olduğunu belirtiriz
        this.Kitaplar.Add(yeniKitap); // Yeni kitabı kütüphaneye ekle
        Console.WriteLine($"{yeniKitap.Ad} kütüphaneye eklendi."); // Kitap ekleme mesajı
    }

    // Tüm kitapları listeleyen metot
    public void KitaplariListele()
    {
        Console.WriteLine("\nKütüphanedeki Kitaplar:"); // Başlık
        foreach (var kitap in Kitaplar)
        {
            Console.WriteLine(kitap.KitapBilgisi()); // Her bir kitabın bilgilerini yazdır
        }
    }
}

// Program sınıfı: Ana programın çalıştığı yerdir
public class Program
{
    public static void Main(string[] args)
    {
        // Yeni bir kütüphane oluştur
        Kutuphane kutuphane = new Kutuphane();

        // Kütüphaneye kitaplar ekle
        kutuphane.KitapEkle(new Kitap("Küçük Prens", "Antoine de Saint-Exupéry", 1943));
        kutuphane.KitapEkle(new Kitap("Fahrenheit 451", "Ray Bradbury", 1953));
        kutuphane.KitapEkle(new Kitap("Bülbülü Öldürmek", "Harper Lee", 1960));

        // Kütüphanedeki tüm kitapları listele
        kutuphane.KitaplariListele();
        Console.WriteLine();
        Console.ReadKey();
    }
}

