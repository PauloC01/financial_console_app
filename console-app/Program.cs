using System;

namespace console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, o que você precisa fazer agora? \n -Digite 1 para gerenciar suas compras com cartão de crédito; \n -Digite 2 para calcular o rendimento da poupança;");
            var opType = Console.ReadLine();

            switch (opType)
            {
                case "1":
                    {
                        Console.WriteLine("Vamos as compras!"); 
                        CardManager.InitCardManager();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Hora de investir!");
                        InvestmentManager.InitInvestmentManager(); 
                        break;
                    }
            }
        }          
    }
}
