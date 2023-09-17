using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDoBicho
{
    class Program
    {
        static Dictionary<string, List<int>> animais = new Dictionary<string, List<int>>
        {
            { "avestruz", new List<int> { 1, 2, 3, 4 } },
            { "aguia", new List<int> { 5, 6, 7, 8 } },
            { "burro", new List<int> { 9, 10, 11, 12 } },
            { "borboleta", new List<int> { 13, 14, 15, 16 } },
            { "cachorro", new List<int> { 17, 18, 19, 20 } },
            { "cabra", new List<int> { 21, 22, 23, 24 } },
            { "carneiro", new List<int> { 25, 26, 27, 28 } },
            { "camelo", new List<int> { 29, 30, 31, 32 } },
            { "cobra", new List<int> { 33, 34, 35, 36 } },
            { "coelho", new List<int> { 37, 38, 39, 40 } },
            { "cavalo", new List<int> { 41, 42, 43, 44 } },
            { "elefante", new List<int> { 45, 46, 47, 48 } },
            { "galo", new List<int> { 49, 50, 51, 52 } },
            { "gato", new List<int> { 53, 54, 55, 56 } },
            { "jacare", new List<int> { 57, 58, 59, 60 } },
            { "leao", new List<int> { 61, 62, 63, 64 } },
            { "macaco", new List<int> { 65, 66, 67, 68 } },
            { "porco", new List<int> { 69, 70, 71, 72 } },
            { "pavao", new List<int> { 73, 74, 75, 76 } },
            { "peru", new List<int> { 77, 78, 79, 80 } },
            { "touro", new List<int> { 81, 82, 83, 84 } },
            { "tigre", new List<int> { 85, 86, 87, 88 } },
            { "urso", new List<int> { 89, 90, 91, 92 } },
            { "veado", new List<int> { 93, 94, 95, 96 } },
            { "vaca", new List<int> { 97, 98, 99, 0 } }
        };

        static Random random = new Random();

        static int RandomInt(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        static void Main(string[] args)
        {
            MenuPrincipalDoJogo();
        }

        static void MenuPrincipalDoJogo()
        {
            Console.WriteLine("\n\n BEM VINDO AO JOGO DO BICHO\n\n");
            Console.WriteLine("Escolha seu tipo de aposta:\n[1] Apostar no animal\n[2] Apostar na dezena");
            Console.Write("Qual opção? ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ApostarNoAnimal();
                    break;
                case 2:
                    ApostarNaDezena();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        static void ApostarNoAnimal()
        {
            Console.WriteLine("\nAPOSTANDO NO ANIMAL\n");
            Console.Write("Qual animal deseja apostar? ");
            string aposta = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Sua aposta foi: " + aposta);
            Console.Write("Deseja apostar acerca ou em todos? ");
            string apostaAcerca = Console.ReadLine().Trim().ToLower();
            bool acerca = apostaAcerca == "acerca";
            double premio = DefineAnimais(aposta, acerca);
            ValorPremio(premio);
        }

        static double DefineAnimais(string aposta, bool acerca)
        {
            string[] animaisSorteados = new string[5];

            int primeiraDezena = RandomInt(0,99);
            int segundaDezena = RandomInt(0,99);
            int terceiraDezena = RandomInt(0,99);
            int quartaDezena = RandomInt(0,99);
            int quintaDezena = RandomInt(0,99);

            foreach (var animal in animais)
            {
                if (animal.Value.Contains(primeiraDezena)) animaisSorteados[0] = animal.Key;
                if (animal.Value.Contains(segundaDezena)) animaisSorteados[1] = animal.Key;
                if (animal.Value.Contains(terceiraDezena)) animaisSorteados[2] = animal.Key;
                if (animal.Value.Contains(quartaDezena)) animaisSorteados[3] = animal.Key;
                if (animal.Value.Contains(quintaDezena)) animaisSorteados[4] = animal.Key;
            }

            Console.Write($"Quanto deseja apostar na {aposta}? ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("\n\nSORTEANDO DEZENAS\n");
            Console.WriteLine($"A 1ª dezena sorteada foi {primeiraDezena}, deu {animaisSorteados[0]}");
            Console.WriteLine($"A 2ª dezena sorteada foi {segundaDezena}, deu {animaisSorteados[1]}");
            Console.WriteLine($"A 3ª dezena sorteada foi {terceiraDezena}, deu {animaisSorteados[2]}");
            Console.WriteLine($"A 4ª dezena sorteada foi {quartaDezena}, deu {animaisSorteados[3]}");
            Console.WriteLine($"A 5ª dezena sorteada foi {quintaDezena}, deu {animaisSorteados[4]}");

            double premio = 0;
            if (animaisSorteados.Contains(aposta))
            {
                Console.WriteLine("Deu bicho! Você ganhou!");
                premio = valor * 3.6;
                if (acerca)
                {
                    Console.WriteLine("Você ganhou acerca!!");
                    premio = valor * 18;
                }
            }
            else
            {
                Console.WriteLine("Vixi rapaz, não foi dessa vez");
            }
            return premio;
        }

        static void ApostarNaDezena()
        {
            Console.WriteLine("\nApostando na dezena\n");
            Console.Write("Qual dezena deseja apostar? ");
            int aposta = int.Parse(Console.ReadLine());
            Console.WriteLine("Sua aposta foi na dezena: " + aposta);
            Console.Write("Deseja apostar acerca ou em todos? ");
            string apostaAcerca = Console.ReadLine().Trim().ToLower();
            bool acerca = apostaAcerca == "acerca";
            double premio = DefineDezenas(aposta, acerca);
            ValorPremio(premio);
        }

        static double DefineDezenas(int aposta, bool acerca)
        {
            int primeiraDezena = RandomInt(0, 99);
            int segundaDezena = RandomInt(0, 99);
            int terceiraDezena = RandomInt(0, 99);
            int quartaDezena = RandomInt(0, 99);
            int quintaDezena = RandomInt(0, 99);

            Console.Write($"Quanto deseja apostar na dezena {aposta}? ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("\n\nSORTEANDO DEZENAS\n");
            Console.WriteLine($"A 1ª dezena sorteada foi {primeiraDezena}");
            Console.WriteLine($"A 2ª dezena sorteada foi {segundaDezena}");
            Console.WriteLine($"A 3ª dezena sorteada foi {terceiraDezena}");
            Console.WriteLine($"A 4ª dezena sorteada foi {quartaDezena}");
            Console.WriteLine($"A 5ª dezena sorteada foi {quintaDezena}");

            double premio = 0;
            if (new[] { primeiraDezena, segundaDezena, terceiraDezena, quartaDezena, quintaDezena }.Contains(aposta))
            {
                Console.WriteLine("Deu a dezena! Você ganhou");
                premio = valor * 12;
                if (acerca)
                {
                    Console.WriteLine("Você ganhou acerca!!");
                    premio = valor * 60;
                }
            }
            else
            {
                Console.WriteLine("Vixi rapaz, não foi dessa vez");
            }
            return premio;
        }

        static void ValorPremio(double premio)
        {
            Console.WriteLine("Você ganhou: " + premio + "");
            
        }
    }
}
