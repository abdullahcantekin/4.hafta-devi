using System;

public class Urun
{
    // Ürün adı
    public string Ad { get; private set; }

    // Ürün fiyatı
    public decimal Fiyat { get; private set; }

    // İndirim oranı: Sadece 0 ile 50 arasında bir değer alabilir
    private decimal _indirim;
    public decimal Indirim
    {
        get { return _indirim; } // İndirim değerini döndürür
        set
        {
            // İndirim oranını 0-50% arasında sınırlar
            if (value >= 0 && value <= 50)
                _indirim = value; // Geçerli bir indirimse ayarlar
            else
                throw new ArgumentOutOfRangeException("İndirim oranı 0 ile 50 arasında olmalıdır."); // Geçersiz indirim için hata fırlatır
        }
    }

    // Yapıcı metot: Ürün adı ve fiyatı ile ürünü başlatır
    public Urun(string ad, decimal fiyat)
    {
        Ad = ad;            // Ürün adını ayarlar
        Fiyat = fiyat;      // Ürün fiyatını ayarlar
        Indirim = 0;       // Başlangıçta indirim sıfır
    }

    // İndirimli fiyatı döndüren metot
    public decimal IndirimliFiyat()
    {
        // İndirimli fiyatı hesaplar
        return Fiyat - (Fiyat * Indirim / 100); // Ürün fiyatından indirim tutarını çıkararak indirimli fiyatı döndürür
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Yeni bir Urun nesnesi oluşturulur
        Urun urun = new Urun("Laptop", 10000m); // "Laptop" adında 10.000 TL fiyatlı ürün oluşturulur

        // Ürün bilgileri ekrana yazdırılır
        Console.WriteLine($"Ürün Adı: {urun.Ad}"); // Ürün adını görüntüler
        Console.WriteLine($"Ürün Fiyatı: {urun.Fiyat} TL"); // Ürün fiyatını görüntüler

        // İndirim oranı ayarlanır
        urun.Indirim = 20; // İndirim oranı %20 olarak ayarlanır
        Console.WriteLine($"Uygulanan İndirim: %{urun.Indirim}"); // Uygulanan indirim oranını görüntüler

        // İndirimli fiyat hesaplanır ve ekrana yazdırılır
        Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()} TL"); // İndirimli fiyatı hesaplayıp görüntüler

        // Geçersiz bir indirim denemesi yapılır
        try
        {
            urun.Indirim = 60; // %60 indirim ayarlamaya çalışılır (hata fırlatır)
        }
        catch (ArgumentOutOfRangeException ex) // Hata yakalama
        {
            Console.WriteLine(ex.Message); // Hata mesajını görüntüler
            Console.ReadKey();
        }
    }
}

