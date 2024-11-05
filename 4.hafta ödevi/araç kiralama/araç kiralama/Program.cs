using System;

public class KiralikArac
{
    // Özellikler
    public string Plaka { get; private set; } // Aracın plakası
    public decimal GunlukUcret { get; private set; } // Günlük kiralama ücreti
    public bool MusaitMi { get; private set; } // Aracın müsaitlik durumu (true: müsait, false: kiralanmış)

    // Yapıcı Metot: Plaka ve günlük ücret bilgisi ile aracı başlatır, varsayılan olarak aracı müsait yapar
    public KiralikArac(string plaka, decimal gunlukUcret)
    {
        Plaka = plaka;
        GunlukUcret = gunlukUcret;
        MusaitMi = true; // Araç ilk oluşturulduğunda müsaittir
    }

    // Aracı kiralamak için metot
    public void AraciKirala()
    {
        if (MusaitMi)
        {
            MusaitMi = false; // Aracın müsaitlik durumu false olur (kiralanmış)
            Console.WriteLine($"{Plaka} plakalı araç kiralandı.");
        }
        else
        {
            Console.WriteLine($"{Plaka} plakalı araç zaten kiralanmış.");
        }
    }

    // Aracı teslim etmek için metot
    public void AraciTeslimEt()
    {
        if (!MusaitMi)
        {
            MusaitMi = true; // Aracın müsaitlik durumu true olur (müsait)
            Console.WriteLine($"{Plaka} plakalı araç teslim edildi.");
        }
        else
        {
            Console.WriteLine($"{Plaka} plakalı araç zaten müsait.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Yeni bir kiralık araç oluşturuyoruz (Plaka ve günlük ücret belirtilmiş)
        KiralikArac arac1 = new KiralikArac("34XYZ456", 200m);

        // Araç bilgilerini ekrana yazdırıyoruz
        Console.WriteLine("Araç Bilgileri:");
        Console.WriteLine($"Plaka: {arac1.Plaka}");
        Console.WriteLine($"Günlük Ücret: {arac1.GunlukUcret} TL");
        Console.WriteLine($"Müsait Mi: {arac1.MusaitMi}");

        // Aracı kiralama işlemi
        Console.WriteLine("\nAracı kiralama işlemi yapılıyor...");
        arac1.AraciKirala(); // Aracın müsaitlik durumu kiralanmış olarak güncellenir
        Console.WriteLine($"Güncel Müsaitlik Durumu: {arac1.MusaitMi}");

        // Aracı teslim etme işlemi
        Console.WriteLine("\nAracı teslim etme işlemi yapılıyor...");
        arac1.AraciTeslimEt(); // Aracın müsaitlik durumu teslim edilmiş (müsait) olarak güncellenir
        Console.WriteLine($"Güncel Müsaitlik Durumu: {arac1.MusaitMi}");
        Console.ReadKey();
    }
}
