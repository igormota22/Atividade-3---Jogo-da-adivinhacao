using System.Collections;
using System.Security.Cryptography;

class Program
{
     static void Main(string[] args)
     {
          while (true)
          {
               string? dificuldade = ExibirMenuEscolhaDificuldade();

               ConfigurarPartida(dificuldade, out int numeroMaximo, out int tentativasMaximas);

               ExecutarPartida(numeroMaximo, tentativasMaximas);

               if (JogadorDesejaContinuar() == true)
               {
                    break;
               }
          }
     }

     static string? ExibirMenuEscolhaDificuldade()
     {
          Console.Clear();

          System.Console.WriteLine("-----------------------------");
          System.Console.WriteLine("JOGO DA ADIVINHAÇÃO");
          System.Console.WriteLine("-----------------------------");
          System.Console.WriteLine("Escolha o nivel de dificuldade: ");
          System.Console.WriteLine("-----------------------------");
          System.Console.WriteLine("1 - Facil (10 tentativas)");
          System.Console.WriteLine("2 - Médio (5 tentativas)");
          System.Console.WriteLine("3 - Dificil (3 tentativas)");
          System.Console.WriteLine("-----------------------------");

          System.Console.Write("Escolha a dificuldade: ");
          string? dificuldade = Console.ReadLine();

          return dificuldade;
     }

     static void ConfigurarPartida(string? dificuldade, out int numeroMaximo, out int tentativasMaximas)
     {

          numeroMaximo = 0;
          tentativasMaximas = 0;

          while (true)
          {
               switch (dificuldade)
               {
                    case "1":
                         numeroMaximo = 20;
                         tentativasMaximas = 10;
                         return;
                    case "2":
                         numeroMaximo = 50;
                         tentativasMaximas = 5;
                         return;
                    case "3":
                         numeroMaximo = 100;
                         tentativasMaximas = 3;
                         return;
                    default:
                         System.Console.WriteLine("Opção invalida");
                         System.Console.Write("Digite ENTER para continuar: ");
                         Console.ReadKey();
                         dificuldade = ExibirMenuEscolhaDificuldade();
                         break;
               }
          }

     }

     static void ExecutarPartida(int numeroMaximo, int tentativasMaximas)
     {
          int[] numerosDigitados = new int[100];
          int contadorNumerosDigitados = 0;
          int pontuacao = 1000;

          int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

          for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)

          {
               Console.Clear();
               System.Console.WriteLine("-----------------------------");
               System.Console.WriteLine($"TENTATIVA {tentativa} DE {tentativasMaximas}");
               System.Console.WriteLine("-----------------------------");

               System.Console.Write($"Digite um valor entre 1 e {numeroMaximo}: ");
               int chute = Convert.ToInt32(Console.ReadLine());

               bool numeroRepetido = false;
               for (int i = 0; i < numerosDigitados.Length; i++)
               {
                    if (numerosDigitados[i] == chute)
                    {
                         numeroRepetido = true;
                         break;
                    }

               }

               if (numeroRepetido == true)
               {
                    System.Console.WriteLine("-----------------------------");
                    System.Console.WriteLine("VOCE JA DIGITOU ESSE NUMERO.TENTE NOVAMENTE");
                    System.Console.WriteLine("-----------------------------");
                    System.Console.Write("Digite ENTER para continuar: ");
                    Console.ReadKey();

                    tentativa--;
                    continue;
               }

               if (contadorNumerosDigitados < numerosDigitados.Length)
               {
                    numerosDigitados[contadorNumerosDigitados] = chute;

                    contadorNumerosDigitados++;
               }


               if (chute == numeroAleatorio)
               {
                    System.Console.WriteLine("-----------------------------");
                    System.Console.WriteLine("PARABÉNS VOCÊ ACERTOU");
                    System.Console.WriteLine("-----------------------------");
                    break;
               }
               else if (chute > numeroAleatorio)
               {

                    System.Console.WriteLine("-----------------------------");
                    System.Console.WriteLine("O NUMERO DIGITADO FOI MAIOR QUE O NUMERO SECRETO");
                    System.Console.WriteLine("-----------------------------");
                    System.Console.Write("Digite ENTER para continuar: ");
               }
               else
               {
                    System.Console.WriteLine("-----------------------------");
                    System.Console.WriteLine("O NUMERO DIGITADO FOI MENOR QUE O NUMERO SECRETO");
                    System.Console.WriteLine("-----------------------------");
                    System.Console.Write("Digite ENTER para continuar: ");

               }

               Console.ReadKey();

               int diferencaNumerica = Math.Abs(numeroAleatorio - chute);

               if (diferencaNumerica >= 10)
               {
                    pontuacao -= 100;
               }
               else if (diferencaNumerica >= 5)
               {
                    pontuacao -= 50;
               }
               else
               {
                    pontuacao -= 20;
               }

               if (tentativa == tentativasMaximas)
               {
                    System.Console.WriteLine("-----------------------------");
                    System.Console.WriteLine($"MAXIMO DE TENTATIVAS ATINGIDO,O NUMERO SECRETO ERA {numeroAleatorio}: ");
                    System.Console.WriteLine("-----------------------------");

               }

               System.Console.WriteLine("------------------------------------------");
               System.Console.WriteLine($"SUA PONTUAÇÃO FOI DE: {pontuacao} ");
               System.Console.WriteLine("------------------------------------------");

          }


     }

     static bool JogadorDesejaContinuar()
     {

          Console.Write("Deseja continuar (s/n)");
          string? opcao = Console.ReadLine();

          if (opcao?.ToUpper() == "N" || opcao?.ToUpper() == "n")
          {
               return true;


          }
          return false;
     }
}


