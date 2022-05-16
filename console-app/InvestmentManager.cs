using System;
using System.Collections.Generic;

namespace console_app
{
    public class InvestmentManager
    {
        public static void InitInvestmentManager()
        {
            var controlVariable = "1";

            while(controlVariable == "1")
            {
                Console.WriteLine("Legal! Fazer investimentos é sempre bom.\n");
                Console.WriteLine("Por favor, Insira o valor a ser investido...");
                int investValue = int.Parse(Console.ReadLine());

                Console.WriteLine("Por quantos meses o valor será investido?");
                int time = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a taxa Selic do ano (%)");
                double selic = double.Parse(Console.ReadLine()) / 100;

                Console.WriteLine("Informe a taxa referencial (%)");
                double tr = double.Parse(Console.ReadLine().Replace(".", ",")) / 100;

                var obj = CalculateInvestiment(investValue, time, selic, tr);

                Console.WriteLine("\nRendimento acumulado ao longo dos meses:\n");

                foreach (var item in obj.MonthlyMessageList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(PrintResult(obj.Result, investValue, time));

                Console.WriteLine("Gostaria de recalcular?\n -Digite 1 se sim\n -Digite 2 caso deseje encerrar");
                controlVariable = Console.ReadLine();
            }
        }

        public static InvestimentResult CalculateInvestiment(int investValue, int time, double selic, double tr)
        {
            double rate;
            double result = investValue;
            var monthlyProfitList = new List<string>();

            if (selic < 0.085)
            {
                rate = (selic / 12 * 0.7) + tr;
            }
            else
            {
                rate = 0.5/100 + tr;
            }

            for (int i = 1; i <= time; i++)
            {
                result = result * (rate + 1);
                monthlyProfitList.Add("Rendimentos dos mês " + i + " R$" + FormatValue(result - investValue) + " acumalado no mês R$" + FormatValue(result));
        }

            return new InvestimentResult
            {
                Result = FormatValue(result),
                MonthlyMessageList = monthlyProfitList
            };
        }

        public static double FormatValue(double value)
        {
            value = Math.Floor(100 * value) / 100;
            string stringfy = value.ToString("N2");
            return double.Parse(stringfy);
        }

        public static string PrintResult(double result, double initialCapital, int time)
        {
            string temporalVariable;

            if (time == 1)
            {
                temporalVariable = "1 mês";
            }
            else
            {
                temporalVariable = time + " meses";
            }
            var message = "\nCom um capital de R$" + initialCapital + " investidos durante " + temporalVariable + " você terá no final aproximadamente R$" + result;
            return message;
        }
    }
}
