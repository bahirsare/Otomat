namespace Otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Meyve Suyu", "Su", "Biskuvi", "Kek" };
            int[] prices = { 15, 10, 7, 8 };
            while (true)
            {
                int choice = 0;
                Console.Clear();
                for (int i = 0; i < products.Length; i++) // menü yazdırma
                {
                    Console.Write($"{i + 1}.");
                    Console.Write(products[i]);
                    Console.Write($" {prices[i]} TL\n");
                }
                Console.WriteLine("Seçmek İstediğiniz Ürün Numarasını Giriniz:");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Geçersiz İşlem");
                    Thread.Sleep(1000);
                }
                    catch (FormatException) { Console.WriteLine("Geçersiz Değer");
                    Thread.Sleep(1000);
                }
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
                            attemt = 3;
                            Console.WriteLine("Giriş Başarılı");
                            Thread.Sleep(2000);
                            break;
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
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Menüdeki Ürünler");
                        for (int i = 0; i < products.Length; i++) // menü yazdırma
                        {
                            Console.Write($"{i + 1}.");
                            Console.Write(products[i]);
                            Console.Write($" {prices[i]} TL\n");
                        }
                        Console.WriteLine("\nÜrün Eklemek için 1\nÜrün Silmek için 2\nFiyat Güncellemek için 3\nAnamenüye Dönmek için 9 Tuşlayınız.");
                        string choiceAdmin = Console.ReadLine();
                        if (choiceAdmin == "1") //ürün ekleme
                        {
                            int productPrice = 0;
                            Console.WriteLine("Ürün Adı:");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Ürün Fiyatı");
                            try
                            {
                                productPrice = Convert.ToInt32(Console.ReadLine());
                                if (productPrice <= 0)
                                {
                                    Console.WriteLine("Ürün Fiyatı Sıfır veya Sıfırdan Küçük Olamaz!");
                                    Thread.Sleep(2000);
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Hatalı Giriş!");
                                Thread.Sleep(2000);
                                continue;
                            }                            
                            Array.Resize(ref products, products.Length + 1);
                            Array.Resize(ref prices, prices.Length + 1);
                            products[products.Length - 1] = productName;
                            prices[prices.Length - 1] = productPrice;
                        }
                        else if (choiceAdmin == "2") // ürün silme
                        {
                            string[] productsCopy = new string[products.Length];
                            int[] pricesCopy = new int[prices.Length];
                            Console.WriteLine("Ürün Adı:");
                            string productName = Console.ReadLine();
                            int index = Array.IndexOf(products, productName);
                            Array.Copy(products, productsCopy, products.Length);
                            Array.Copy(prices, pricesCopy, prices.Length);
                            for (int i = 0; i < products.Length - index - 1; i++)
                            {
                                Console.WriteLine("dizi uzunluğu - index - 1" + (products.Length - index - 1) + " index" + (index + 1));

                                products[index + i] = productsCopy[index + i + 1];
                                prices[index + i] = pricesCopy[index + i + 1];

                            }
                            Array.Clear(prices, prices.Length - 1, 1);
                            Array.Clear(products, products.Length - 1, 1);
                            Array.Resize(ref prices, prices.Length - 1);
                            Array.Resize(ref products, products.Length - 1);
                        }
                        else if (choiceAdmin == "3") //fiyat güncelleme
                        {
                            int productPrice = 0;
                            Console.WriteLine("Ürün Adı:");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Yeni Fiyatı");
                            try
                            {
                                productPrice = Convert.ToInt32(Console.ReadLine());
                                if (productPrice <= 0)
                                {
                                    Console.WriteLine("Ürün Fiyatı Sıfır veya Sıfırdan Küçük Olamaz!");
                                    Thread.Sleep(2000);
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Hatalı Giriş!");
                                Thread.Sleep(2000);
                                continue;
                            }
                            int index = Array.IndexOf(products, productName);
                            if (index == -1)
                            {
                                Console.WriteLine("Ürün Bulunamadı!");
                                Thread.Sleep(2000);
                                continue;
                            }
                            prices[index] = productPrice;
                        }
                        else if (choiceAdmin == "9")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz Değer");

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
