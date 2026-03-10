using System.Security.Cryptography;

while (true)

{

Console.Clear();

System.Console.WriteLine("-----------------------------");
System.Console.WriteLine("JOGO DA ADIVINHAÇÃO");
System.Console.WriteLine("-----------------------------");

int numeroAleatorio = RandomNumberGenerator.GetInt32(1,21);

System.Console.Write("Digite um valor entre 1 e 20: ");
int chute = Convert.ToInt32(Console.ReadLine());

System.Console.WriteLine($"O valor digitado foi:  {chute}");
System.Console.WriteLine($"O valor era: {numeroAleatorio}");

if (chute == numeroAleatorio)
{
System.Console.WriteLine("-----------------------------");
System.Console.WriteLine("PARABÉNS VOCÊ ACERTOU");
System.Console.WriteLine("-----------------------------");
}
else if (chute > numeroAleatorio)
{
System.Console.WriteLine("-----------------------------");
System.Console.WriteLine("O NUMERO DIGITADO FOI MAIOR QUE O NUMERO SECRETO");
System.Console.WriteLine("-----------------------------");
}
else
{
System.Console.WriteLine("-----------------------------");
System.Console.WriteLine("O NUMERO DIGITADO FOI MENOR QUE O NUMERO SECRETO");
System.Console.WriteLine("-----------------------------");
}

Console.Write("Deseja continuar (s/n)");
string? opcao =  Console.ReadLine();

if (opcao?.ToUpper() == "n" || opcao == "N")
    {
         return;
    }
    
       
    }