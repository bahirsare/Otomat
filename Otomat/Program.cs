namespace Otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] products = { "Meyve Suyu", "su", "Biskuvi", "Kek" };

            int[] prices = { 15, 10, 7, 8 };
            while (true)
            {
                int choice = 0;

                for (int i = 0; i < products.Length; i++) // menü yazdırma
                {
                    Console.Write($"{i + 1}.");
                    Console.Write(products[i]);
                    Console.Write($" {prices[i]} TL\n");
                }
                Console.WriteLine("Seçmek İstediğiniz Ürün Numarasını Giriniz:");
                choice = Convert.ToInt32(Console.ReadLine());


                if (choice == -1) // admin paneline erişim
                {
                    Console.WriteLine("Yönetici Paneline Erişmek için Şifre Giriniz:");
                    string password = "ab18";
                    int attemt = 3;
                    while (attemt > 0)
                    {
                        string entry = Console.ReadLine();
                        if (entry == password)//giriş başarılı
                        {
                            Console.WriteLine("Giriş Başarılı");

                        }
                        else
                        {
                            Console.WriteLine("Şifre Yanlış!!\nTekrar Deneyiniz.");
                            attemt--;
                            if (attemt == 0)
                            {
                                Console.WriteLine("3 kez yanlış şifre girdiniz. Cihaz kitlendi");
                                Thread.Sleep(6000);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    int paymentMethod = 0;
                    try
                    {
                        Console.WriteLine($"{products[choice - 1]} fiyatı {prices[choice - 1]}'dır\n Kart ile ödemek için 1, Nakit yüklemek için 2 tuşlayınız.");
                        paymentMethod = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Geçersiz Seçim!");
                        continue;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Geçersiz Değer");
                        continue;
                    }

                    if (paymentMethod == 1)
                    {
                        Console.WriteLine("Kartınızı Okutunuz!");
                        Thread.Sleep(5000);
                        Console.WriteLine("Ödeme Başarılı!");
                    }
                    else if (paymentMethod == 2)
                    {
                        int money = 0;
                        Console.WriteLine("Lütfen para girişi yapınız.");
                        while (true)
                        {

                            Console.WriteLine("Yatırdığınız Miktar:");
                            money += Convert.ToInt32(Console.ReadLine());
                            if (money < prices[choice - 1])
                            {
                                Console.WriteLine($"Eksik Bakiye!!\n {prices[choice - 1] - money} TL daha eklemeniz gerekmektedir.");
                            }
                            else if (money > prices[choice - 1])
                            {
                                Console.WriteLine("Ödeme Başarılı!!\n Para üstünü almayı unutmayınız.");
                                Thread.Sleep(3000);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ödeme Başarılı!!");
                                Thread.Sleep(3000);
                                break;
                            }
                        }

                    }
                    else { Console.WriteLine("Geçersiz Seçim!"); }
                }
            }
        }
    }
}
