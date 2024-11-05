using System;

public class BankaHesabi
{
    // Hesap numarası: Yalnızca okunabilir, dışarıdan değiştirilemez
    public string HesapNumarasi { get; set; }

    // Bakiye alanı: Sadece sınıf içinden değiştirilebilir
    private decimal _bakiye;

    // Bakiye özelliği: Yalnızca okunabilir, sınıf içinden değiştirilebilir
    public decimal Bakiye
    {
        get { return _bakiye; }          // Bakiye dışarıdan okunabilir
        private set { _bakiye = value; }  // Bakiye sadece sınıf içinde ayarlar
    }

    // Yapıcı metot: Hesap numarası ve başlangıç bakiyesi ile hesap oluşturur
    public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
    {
        HesapNumarasi = hesapNumarasi;  // Hesap numarasını ayarlar
        _bakiye = ilkBakiye;            // Başlangıç bakiyesini ayarlar
    }

    // Para yatırma işlemi: Pozitif miktar verilirse bakiyeye ekler
    public void ParaYatir(decimal miktar)
    {
        if (miktar > 0) // Yatırılacak miktar pozitif mi kontrol edilir
        {
            _bakiye += miktar; // Bakiyeye miktar eklenir
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {_bakiye} TL.");
        }
        else
        {
            Console.WriteLine("Yatırılacak miktar pozitif olmalıdır.");
        }
    }

    // Para çekme işlemi: Pozitif ve yeterli miktar varsa çekim yapılır
    public void ParaCek(decimal miktar)
    {
        if (miktar > 0 && miktar <= _bakiye) // Pozitif miktar ve bakiye yeterli mi kontrol edilir
        {
            _bakiye -= miktar; // Bakiyeden miktar çıkarılır
            Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {_bakiye} TL.");
        }
        else if (miktar > _bakiye) // Yetersiz bakiye durumu
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
        else
        {
            Console.WriteLine("Çekilecek miktar pozitif olmalıdır.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Yeni bir BankaHesabi nesnesi oluşturulur ve hesap numarası ile ilk bakiye atanır
        BankaHesabi hesap = new BankaHesabi("123456789", 1000m);

        // Hesap numarası ve başlangıç bakiyesini görüntüler
        Console.WriteLine($"Hesap Numarası: {hesap.HesapNumarasi}");
        Console.WriteLine($"Başlangıç Bakiyesi: {hesap.Bakiye} TL");

        // Para yatırma işlemi yapılır; bakiye pozitif miktarla güncellenir
        hesap.ParaYatir(500m);

        // Para çekme işlemi yapılır; bakiye pozitif ve uygun miktarla azalır
        hesap.ParaCek(300m);

        // Yetersiz bakiye ile para çekme denemesi yapılır; hata mesajı verir
        hesap.ParaCek(1500m);

        // Son güncel bakiyeyi görüntüler
        Console.WriteLine($"Güncel Bakiye: {hesap.Bakiye} TL");
        Console.ReadKey();
    }
}



