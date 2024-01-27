//todo criar uma forma generica de cadastrar bandas
//screen sound

using System;

string mensagemDeBaosVindas = "\n Boas vindas ao screen sound \n";

//List<string> listaDasBandas = new List<string> {"U2","cine","kiss"};

//para salvar as notas da banda foi necessario criar um dicionario,
//pois uma lista nao consegue exibir dois valores em uma so variavel
//desta forma criamos um dicionario no lugar da lista 

Dictionary<string,List<int>>bandasRegistradas= new Dictionary<string,List<int>>();
//void e para basicamente criar uma funçao sem retorno
void ExibirLogo()
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀  ");
}

void BoasVindas()
{
    ExibirLogo();
    Console.WriteLine(mensagemDeBaosVindas);
}
void ExibirOpcoesMenu() 
{
        
        Console.WriteLine("Digite 1 para cadastrar nova banda");
        Console.WriteLine("Digite 2 para mostrar todas as bandas");
        Console.WriteLine("Digite 3 para avaliar banda");
        Console.WriteLine("Digite 4 para exibir media da banda");
        Console.WriteLine("Digite 5 para remover banda da lista");
        Console.WriteLine("digite 0 para sair");

    Console.WriteLine("\nDigite a sua opção: ");
    //para converter string em int usando o int.parse 
    string opcaoEscolhida = Console.ReadLine();
    int opcaoEscolhidaNumerica= int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MostrarMediaBanda();
            break;
        case 5:
            RemoverBanda();
            break;
        case 0:
            Console.WriteLine("Fim!!");
            break;
        default: 
            Console.WriteLine("opçao invalida");
            break;
    }
}
void RegistrarBanda()
{
    //para limpar o console
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine();
    bandasRegistradas.Add(nomeDaBanda,new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada");
    //funçao para esperar um tempo antes de exibir milisegundos
    Thread.Sleep(2000);
    Console.Clear();
    ExibirLogo();
    ExibirOpcoesMenu();
}
void RemoverBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Remover banda");
    Console.WriteLine("Digite o nome da banda que deseja remover");
    string nomeDaBanda = Console.ReadLine();
    bandasRegistradas.Remove(nomeDaBanda, out List<int> Value);
    Console.WriteLine($"A banda removida foi {nomeDaBanda}");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirLogo();
    ExibirOpcoesMenu();
}
void MostrarBandasRegistradas() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    //para percorrer uma lista ja existente devemos criar um loop
    foreach (string banda in bandasRegistradas.Keys) 
    {
        Console.WriteLine($"As bandas resgistardas são {banda}");
    
    }
    Console.WriteLine("Digite qualquel tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
    ExibirOpcoesMenu();
}
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
void AvaliarUmaBanda() 
{
    //qual banda deseja avaliar
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    //verificar se a banda existe
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //depois atribuir nota
        Console.WriteLine($"Qual nota voce deseja colocar na banda {nomeDaBanda}");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A sua nota {nota} para a banda {nomeDaBanda} foi registrada");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirLogo();
        ExibirOpcoesMenu();
    }
    else {
        // se nao tiver banda sair
        Console.WriteLine($"\n o nome da banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.Clear();
        ExibirLogo();
        ExibirOpcoesMenu();
    }

    

}
void MostrarMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média das bandas");
    Console.WriteLine("Qual banda voce deseja ver a média");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();


    }
    else 
    {
        Console.WriteLine($"\n o nome da banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.Clear();
        ExibirOpcoesMenu();
    }


}

BoasVindas();
ExibirOpcoesMenu();




