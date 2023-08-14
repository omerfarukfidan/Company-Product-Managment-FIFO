using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyOrders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
                Random rnd = new Random();
            int genelToplam = 101;
            int quant = 0;
            for (int i = 0; i < 1000; i++)
            {
                
                
                char harf;
               if (i == 0)
                {
                    harf = 'P';
                }
                else if (rnd.Next(10000) % 2 == 0)
                {
                    harf = 'P';
                }
                else
                {
                    harf = 'C';
                }
                

                
               
                if (harf == 'C')
                {
                    
                    quant = rnd.Next(1,30);
                    genelToplam -= quant;


                }
                else if(harf == 'P')
                {
                    quant = rnd.Next(100);
                }
                genelToplam += quant;




                orders.Add(new Order()
                {
                    idx = i + 1,
                    Tip = harf,
                    Quantity = quant,
                    Kalan = (harf == 'P' ? quant : 0),
                    Price = (harf == 'P' ? rnd.Next(1000) : 0),  //inline if else
                    PartiNo = (harf == 'P' ? i+1 : 0) 
                });

            }
            int runningTotal = 0;
            int neededQuantity = 0;


            for ( int t  = 1; t < orders.Count; t++ )
            {


                if (orders[t].PartiNo == 0)
                {
                    //var a =  orders[0];//orders ilk eleman
                    neededQuantity += orders[t].Quantity;

                    while(neededQuantity > 0)
                    {
                        for (int j = 0; j < orders.Count; j++)
                        {
                            if (orders[j].Tip == 'P' &&
                                orders[j].Kalan > 0)
                            {
                                if (neededQuantity > orders[j].Kalan)
                                {
                                    neededQuantity -= orders[j].Kalan;
                                    orders[j].Kalan = 0;
                                }
                                else
                                {
                                    orders[j].Kalan -= neededQuantity;
                                    neededQuantity = 0;
                                }
                            }

                        }
                    }
                }

             
            }




                foreach (var item in orders)
            {         
                
                Console.WriteLine($"idx: {item.idx}, Tip: {item.Tip}, Quantity: {item.Quantity}, Kalan: {item.Kalan}, Price: {item.Price}, PartiNo: {item.PartiNo}");
            }

            


            int CostOfProducts = 0;

            for (int t = 0; t < orders.Count; t++)
                if (orders[t].Kalan > 0)
                    CostOfProducts += orders[t].Kalan * orders[t].Price;

            Console.WriteLine("Cost of leftover products: " + CostOfProducts);
            Console.ReadLine();

        }
    }
}
