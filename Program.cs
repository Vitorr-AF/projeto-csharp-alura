﻿// Screen sound
using System.Security.Cryptography.X509Certificates;

string boasVindas = "Bem vindo ao screen sound";
//List<string> listaDasBandas = new List<string>();

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(boasVindas);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine(" 1. Salvar banda");
    Console.WriteLine(" 2. Mostrar todas as bandas");
    Console.WriteLine(" 3. Avaliar uma banda");
    Console.WriteLine(" 4. Exibir a média de uma banda");
    Console.WriteLine("-1. Sair");
    Console.WriteLine("\nOpção: ");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);

    switch(opcaoEscolhidaNum)
    {
        case 1: Console.WriteLine("Opção 1");
        RegistrarBanda();
            break;
        case 2: Console.WriteLine("Opção 2");
        MostrarBandasRegistradas();
            break;
        case 3: Console.WriteLine("Opção 3");
        AvaliarUmaBanda();
            break;
        case 4: Console.WriteLine("Opção 4");
        ExibirMediaDaBanda();
            break;
        case -1: Console.WriteLine("Opção 5");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }

    
}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void MostrarBandasRegistradas()
{
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas:");
    // for(int i = 0; i <listaDasBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda: {listaDasBandas[i]}");
    // }
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("Aperte um botão para voltar ao menu");
    Console.ReadKey();
    ExibirMenu();
    
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
    //digite qual banda deseja avaliar
    //se a banda existir no dicionário >> atribuir uma nota
    //senão volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}

void ExibirMediaDaBanda()
{
    Console.Clear();
    Console.WriteLine("Digite o nome da banda que você quer ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda}não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}


ExibirMenu();