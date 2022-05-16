using System;
using System.Collections.Generic;

namespace console_app
{
    public class CardManager
    {
        public static void InitCardManager()
        {
            double grandTotal = 0;
            var controlVar = 0;
            var itemList = new List<string>();

            Console.WriteLine("Insira o limite do cartão");
            int limite = int.Parse(Console.ReadLine());

            while (controlVar == 0)
            {
                Console.WriteLine("Adicionar novo item? \n -Digite 1 para adicionar um item \n -Digite 2 para finalizar");
                var continueOp = Console.ReadLine();

                if (continueOp == "1" && controlVar != 1)
                {
                    Console.WriteLine("Insira o nome do produto");
                    var productDescription = Console.ReadLine();

                    Console.WriteLine("Insira o valor produto");
                    var productValue = double.Parse(Console.ReadLine());

                    controlVar = CheckValue(limite, (productValue + grandTotal));

                    if (controlVar == 1)
                    {
                        Console.WriteLine("A lista de compras alcançou o limite do cartão!\n");
                        continue;
                    }

                    itemList.Add(AddItem(productDescription, productValue));
                    grandTotal += productValue;
                }

                if (continueOp == "2")
                {
                    controlVar = 1;
                    continue;
                }
            }
 
            Console.WriteLine("Lista de items\n");
            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Valor total de compras: R$" + grandTotal);

            return;
        }

        public static int CheckValue(int limite, double value)
        {
            if(value > limite)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static string AddItem(string productDescription, double productValue)
        { 
            var message = "Descrição do produto: " + productDescription + "\nValor: R$" + productValue; 
            return message;
        }
    }
}
