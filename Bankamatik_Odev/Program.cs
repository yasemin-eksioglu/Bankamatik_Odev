using System.Threading.Channels;

namespace Bankamatik_Odev
{
    internal class Program
    { 
        static void Main(string[] args)
        {

            BASLANGIC:
            string kartNo = "123456789012";
            double bakiye = 2500;
            string sifre = "12345";
            Console.WriteLine("  1-Kartlı İşlem\n  2-Kartsız İşlem");
            string islem = (Console.ReadLine());

            if (islem == "1")
            {
                int hak = 3; //Deneme hakkı
                bool girisBasarili = false; //Giriş başarı durumu 
                while (hak > 0)
                {
                    Console.WriteLine("Şifre Giriniz:");
                    string girilenSifre= Console.ReadLine();
                    
                    if (girilenSifre == sifre)
                    {
                        Console.WriteLine("Giriş Başarılı");
                        girisBasarili = true;
                        break; //Şifre doğruysa döngüden çık
                    }
                    else
                    {
                        hak--;
                        Console.WriteLine($"Hatalı Şifre Girdiniz.Kalan Hakkınız: {hak}");
                        if (hak == 0)
                        {
                            Console.WriteLine("Şifre Deneme Hakkınız Kalmadı!");
                            Environment.Exit(0);
                        }
                    }
                }

                if (girisBasarili)
                {
                DON:
                    Console.WriteLine("ANA MENÜ");
                    Console.WriteLine("1-Para Çekme \n 2-Para Yatırma \n 3-Para Transferi \n 4-Eğitim Ödemeleri \n 5-Ödemeler \n 6-Bilgi Güncelleme ");
                    int secim = Convert.ToInt32(Console.ReadLine());
                    if (secim == 1)
                    {
                        Console.WriteLine("Şuanki Bakiyeniz: " + bakiye);
                        Console.WriteLine("Çekmek İstenilen Miktarı Giriniz:");
                        double paraMiktari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= paraMiktari)
                        {
                            Console.WriteLine("Paranızı Alabilirsiniz.");
                            Console.WriteLine("Yeni Bakiyeniz: " + (bakiye -= paraMiktari));
                            Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız. ");
                            int secim2 = Convert.ToInt32(Console.ReadLine());
                            if (secim2 == 9)
                            {
                                goto DON;
                            }
                            else if (secim2 == 0)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                                goto DON;
                            }

                        }
                        else if (bakiye < paraMiktari)
                        {
                            Console.WriteLine("Yetersiz Bakiye! \n Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız. ");
                            int secim2 = Convert.ToInt32(Console.ReadLine());
                            if (secim2 == 9)
                            {
                                goto DON;
                            }
                            else if (secim2 == 0)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                                goto DON;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                            goto DON;
                        }
                    
                    }
                    else if (secim == 2)
                    {
                        Console.WriteLine("Kredi Kartına Para Yatırmak İçin 1'i \n Kendi Hesabınıza Para Yatırmak İçin 2'yi Tuşlayınız.");
                        Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız.");
                        int tuslama = Convert.ToInt32(Console.ReadLine());
                        if (tuslama == 9)
                        {
                            goto DON;
                        }
                        else if (tuslama == 0)
                        {
                            Environment.Exit(0);
                        }

                        else if (tuslama == 1) //kredi kartı seçerse
                        {
                            double kartBorcu = 1250;
                            while (true)
                            {
                                Console.WriteLine("Lütfen 12 Haneli Kredi Kartı Numaranızı Giriniz: ");
                                string girilenKartNo = Console.ReadLine();

                                if (girilenKartNo == kartNo)
                                {
                                    if (bakiye >= kartBorcu)
                                    {
                                        bakiye -= kartBorcu;
                                        Console.WriteLine("Kart Borcunuz Ödendi.");
                                        break;
                                    }
                                    else if (bakiye < kartBorcu)
                                    {
                                        Console.WriteLine("Bakiye Yetersiz!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hatalı Tuşalama Yaptınız.");
                                        break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Kart Numarası Hatalı!");
                                    double tuslama2 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız. ");
                                    if (tuslama2 == 9)
                                    {
                                        goto DON;
                                    }
                                    else if (tuslama2 == 0)
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                                    }
                                }
                            }
                        }
                        else if (tuslama == 2) //kendi hesabına para yatırmak
                        {
                            Console.WriteLine("Yatırmak İstediğiniz Miktarı Giriniz:");
                            double paraYatirma = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Yeni Bakiyeniz: " + (bakiye + paraYatirma));
                            goto DON;
                        }

                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        }
                    }
                    else if (secim == 3) //EFT - Havale Yapma
                    {
                        Console.WriteLine("Başka Hesaba EFT Yapmak İçin 1'i \n Başka Hesaba Havale Yapmak için 2'yi Tuşlayınız.");
                        Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız.");
                        int havale = Convert.ToInt32(Console.ReadLine());
                        string eftNo = "TR-112233445566";
                        if (havale == 1) // EFT 
                        {
                            Console.WriteLine("Lütfen TR- ile Başlayan 12 Haneli EFT Numarasını Giriniz.");
                            string girilenEftNo = Console.ReadLine();
                            if (girilenEftNo == eftNo)
                            {
                                Console.WriteLine("Göndermek İstediğiniz Tutarı Giriniz.");
                                double eftTutar = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= eftTutar)
                                {
                                    Console.WriteLine("İşleminiz Gerçekleşti.");
                                }
                                else if (bakiye < eftTutar)
                                {
                                    Console.WriteLine("Bakiye Yetersiz Olduğu İçin İşleminiz Yapılamadı.");
                                    goto DON;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı İşlem Girdiniz.");
                                    goto DON;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Yanlış veya Eksik Tuşlama Yaptınız. Lütfen Tekrar Deneyiniz.");
                            }

                        }
                        else if (havale == 2) // Havale
                        {
                            string hesapNo = "11234567890";
                            Console.WriteLine("11 Haneli Hesap Numarasını Giriniz.");
                            string girilenHesapNo = Console.ReadLine();
                            if (girilenHesapNo == hesapNo)
                            {
                                Console.WriteLine("Göndermek İstediğiniz Tutarı Giriniz.");
                                double havaleTutar = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= havaleTutar)
                                {
                                    Console.WriteLine("İşleminiz Gerçekleşti.");
                                }
                                else if(bakiye < havaleTutar)
                                {
                                    Console.WriteLine("Bakiye Yetersiz Olduğu İçin İşleminiz Yapılamadı");
                                    goto DON;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                                    goto DON;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                            }

                        }
                        else if (havale == 9)
                        {
                            goto DON;
                        }
                        else if (havale == 0)
                        {
                            Environment.Exit(0);
                        }

                    }
                    else if (secim == 4) // Eğitim Ödemeleri
                    {
                        Console.WriteLine("Eğitim Ödemeleri Sayfası Arızalı Olduğu İçin İşleminizi Şuan Gerçekleştiremiyoruz. Lütfen Daha Sonra Tekrar Deneyiniz.");
                        int tuslama3 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız. ");
                        if (tuslama3 == 9)
                        {
                            goto DON;
                        }
                        else if (tuslama3 == 0)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                        }

                    }
                    else if (secim == 5) //Faturalar
                    {
                        Console.WriteLine("Elektrik Faturası Ödemek İçin 1'i \n Telefon Faturası Ödemek İçin 2'yi \n İnternet Faturası Ödemek İçin 3'ü \n Su Faturası Ödemek İçin 4'ü \n OGS Ödemeleri İçin 5'i Tuşlayınız.");
                        Console.WriteLine("Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız. ");
                        int faturaNo = Convert.ToInt32(Console.ReadLine());
                        if (faturaNo == 1 || faturaNo == 2 || faturaNo == 3 || faturaNo == 4 || faturaNo == 5)
                        {
                            Console.WriteLine("Faturanızın Tutarını Giriniz:");
                            double faturaTutari = Convert.ToDouble(Console.ReadLine());
                            if (faturaTutari<0)
                            {
                                Console.WriteLine("Fatura Tutarı 0'dan Küçük Olamaz!");
                            }
                            else if (faturaTutari <= bakiye)
                            {
                                Console.WriteLine("Faturanız Ödendi.");
                            }
                            else if (faturaTutari > bakiye)
                            {
                                Console.WriteLine("Yetersiz Bakiye");
                            }
                        }

                        else if (faturaNo == 9)
                        {
                            goto DON;
                        }
                        else if (faturaNo == 0)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                        }
                    }
                    else if (secim == 6) // Bilgi Güncelleme
                    {
                        Console.WriteLine("Şifre Değiştirmek İçin 1'i \n Ana Menüye Dönmek İçin 9'u, Çıkmak İçin 0'ı Tuşlayınız.");
                        int secim2 = Convert.ToInt32(Console.ReadLine());
                        if (secim2 == 1)
                        {
                            Console.WriteLine("Mevcut Şifrenizi Giriniz.");
                            string mevcutSifre = Console.ReadLine();
                            if (mevcutSifre == sifre)
                            {
                                Console.WriteLine("Yeni Şifreyi Girin: ");
                                string yeniSifre = (Console.ReadLine());
                                Console.WriteLine("Yeni Şifreyi Tekrar Girin: ");
                                string yeniSifre2= Console.ReadLine();
                                if (yeniSifre == yeniSifre2)
                                {
                                    if (mevcutSifre != yeniSifre)
                                    {
                                        Console.WriteLine("Şifreniz Değiştirildi.");
                                        sifre = yeniSifre;
                                        goto DON;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Yeni Şifre Mevcut Şifreyle Aynı Olamaz!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Şifreler Birbiriyle Eşleşmiyor.");
                                }
                            }
                        }
                        else if (secim2 == 9)
                        {
                            goto DON;
                        }
                        else if (secim2 == 0)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                        }
                    }

                }
            }

            else if (islem == "2")//kartsız işlem kısmı
            {
                Console.WriteLine("Şuan Kartsız İşlem Yapılamıyor. Lütfen Daha Sonra Tekrar Deneyin.");
                goto BASLANGIC;
                
            }

            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız.Yeniden Deneyin.");
                goto BASLANGIC;
            }

        }
    }
}