using System.Security.Cryptography;

System.Console.WriteLine("-----------------------------");
System.Console.WriteLine("JOGO DA ADIVINHAÇÃO");
System.Console.WriteLine("-----------------------------");

int numeroAleatorio = RandomNumberGenerator.GetInt32(1,21);

Console.ReadLine();

System.Console.Write("Digite um valor entre 1 e 20: ");
string chute = Console.ReadLine();

System.Console.WriteLine($"O valor digitado foi:  {chute}");
System.Console.WriteLine($"O valor era: {numeroAleatorio}");


