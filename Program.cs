using System;
using System.Collections.Generic;
using System.IO;

namespace ATMUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sistemde kayıtlı kullanıcılar (Kullanıcı Adı, Parola)
            Dictionary<string, string> kullaniciKayitlari = new Dictionary<string, string>
            {
                {"user1", "pass1"},
                {"user2", "pass2"},
                {"user3", "pass3"}
            };

            Console.WriteLine("ATM Uygulamasına Hoş Geldiniz!");

            // Kullanıcı giriş işlemi
            string kullaniciAdi, parola;
            do
            {
                Console.Write("Kullanıcı Adı: ");
                kullaniciAdi = Console.ReadLine();
                Console.Write("Parola: ");
                parola = Console.ReadLine();

                if (!kullaniciKayitlari.ContainsKey(kullaniciAdi) || kullaniciKayitlari[kullaniciAdi] != parola)
                {
                    Console.WriteLine("Hatalı kullanıcı adı veya parola. Tekrar deneyin.");
                }
            } while (!kullaniciKayitlari.ContainsKey(kullaniciAdi) || kullaniciKayitlari[kullaniciAdi] != parola);

            Console.WriteLine($"Hoş geldiniz, {kullaniciAdi}!");

            // İşlem listesi
            List<string> islemListesi = new List<string>
            {
                "Para Çekme", "Para Yatırma", "Ödeme Yapma", "Gün Sonu"
            };

            while (true)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçin:");

                for (int i = 0; i < islemListesi.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {islemListesi[i]}");
                }

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        ParaCek(kullaniciAdi);
                        break;
                    case 2:
                        ParaYatir(kullaniciAdi);
                        break;
                    case 3:
                        OdemeYap(kullaniciAdi);
                        break;
                    case 4:
                        GunSonuLog(kullaniciAdi);
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }

        static void ParaCek(string kullaniciAdi)
        {
            Console.WriteLine("Para Çekme işlemi seçildi.");
            // Para çekme işlemi kodları burada yer alabilir.
        }

        static void ParaYatir(string kullaniciAdi)
        {
            Console.WriteLine("Para Yatırma işlemi seçildi.");
            // Para yatırma işlemi kodları burada yer alabilir.
        }

        static void OdemeYap(string kullaniciAdi)
        {
            Console.WriteLine("Ödeme Yapma işlemi seçildi.");
            // Ödeme yapma işlemi kodları burada yer alabilir.
        }

        static void GunSonuLog(string kullaniciAdi)
        {
            string dosyaAdi = $"{kullaniciAdi}_{DateTime.Now:ddMMyyyy}.txt";

            using (StreamWriter sw = File.CreateText(dosyaAdi))
            {
                sw.WriteLine($"Gün Sonu Raporu - {DateTime.Now}");
                // Gün sonu işlem logları burada yer alabilir.
                sw.WriteLine("Gün sonu işlem logları...");
            }

            Console.WriteLine("Gün sonu işlemi tamamlandı. Loglar dosyaya kaydedildi.");
        }
    }
}
