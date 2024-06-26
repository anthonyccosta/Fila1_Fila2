﻿
using Fila1_Fila2;

internal class Program
{
    private static void Main(string[] args)
    {
        NumeroFila fila1 = new NumeroFila();
        NumeroFila fila2 = new NumeroFila();
        NumeroFila filaAux = new NumeroFila();
        NumeroFila fila_opcao = new NumeroFila();
        int aleatorio, opcao, opcaofila;

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            fila1.push(geraNumero());
        }

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            fila2.push(geraNumero());
        }

        do
        {
            Console.WriteLine("1 - Verificar o tamanho das filas");
            Console.WriteLine("2 - Verificar maior, menor, média aritmética de uma fila");
            Console.WriteLine("3 - Transferir uma fila para outra ");
            Console.WriteLine("4 - Imprimir números pares/impares de uma fila");
            Console.WriteLine("0 - Sair do programa");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Saindo do programa");
                    break;
                case 1:
                    compararFilas(fila1, fila2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Digite 1 para a fila 1, 2 para a fila 2 ou 3 para a fila 3.");
                        opcaofila = int.Parse(Console.ReadLine());
                    } while ((opcaofila < 1) && (opcaofila > 3));
                    switch (opcaofila)
                    {
                        case 1:
                            fila_opcao = fila1;
                            break;
                        case 2:
                            fila_opcao = fila2;
                            break;
                        default:
                            fila_opcao = filaAux;
                            break;
                    }
                    retornarNumeros(fila_opcao, 2);
                    valoresFilas(fila_opcao);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Digite:\n1 - para transferir da fila 1");
                        Console.WriteLine("2 - para transferir da fila 2");
                        opcaofila = int.Parse(Console.ReadLine());
                    } while ((opcaofila < 1) && (opcaofila > 2));
                    switch (opcaofila)
                    {
                        case 1:
                            filaAux = transferirfila(fila1);
                            break;
                        default:
                            filaAux = transferirfila(fila2);
                            break;
                    }
                    Console.WriteLine($"Todos os números da fila {opcaofila} transferida:");
                    retornarNumeros(filaAux, 2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Digite 1 para a fila 1, 2 para a fila 2 ou 3 para a fila 3");
                        opcaofila = int.Parse(Console.ReadLine());
                    } while ((opcaofila < 1) && (opcaofila > 2));
                    switch (opcaofila)
                    {
                        case 1:
                            fila_opcao = fila1;
                            break;
                        case 2:
                            fila_opcao = fila2;
                            break;
                        default:
                            fila_opcao = filaAux;
                            break;
                    }
                    retornarNumeros(fila_opcao, 0);
                    retornarNumeros(fila_opcao, 1);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opcao != 0);
    }
    static void compararFilas(NumeroFila f1, NumeroFila f2)
    {
        int f1s, f2s;
        f1s = f1.getContador();
        f2s = f2.getContador();

        if (f1s == f2s)
        {
            Console.WriteLine($"As filas são de tamanhos iguais: {f1s}.");
        }
        else if (f1s > f2s)
        {
            Console.WriteLine($"A Fila 1 ({f1s}) é maior que a Fila 2 ({f2s})");
        }
        else
        {
            Console.WriteLine($"A Fila 2 ({f2s}) é maior que a Fila 1 ({f1s})");
        }
    }
    static void valoresFilas(NumeroFila fila)
    {
        float resultado = 0;
        resultado = fila.getValores(0);
        Console.WriteLine($"O menor valor da fila é: {resultado}");
        resultado = fila.getValores(1);
        Console.WriteLine($"O maior valor da fila é: {resultado}");
        resultado = fila.getValores(2);
        Console.WriteLine($"A média aritmética fila é: {resultado}");
    }
    static Numero geraNumero()
    {
        Numero numerotemp = new Numero(new Random().Next(1, 100));
        return numerotemp;
    }
    static void retornarNumeros(NumeroFila fila, int tipo)
    {
        switch (tipo)
        {
            case 0:
                Console.WriteLine("Números pares: " + fila.print(0));
                break;
            case 1:
                Console.WriteLine("Números ímpares: " + fila.print(1));
                break;
            case 2:
                Console.WriteLine(fila.print(2));
                break;
        }
    }
    static NumeroFila transferirfila(NumeroFila fila)
    {
        int tamanhofila = 0;

        Numero aux;
        NumeroFila Final = new NumeroFila();

        Console.WriteLine("Todos os Números da fila original:");
        retornarNumeros(fila, 2);
        tamanhofila = fila.getContador(); 
        for (int i = 0; i < tamanhofila; i++)
        {
            aux = new Numero(fila.pop()); 
        }
        return Final; 
    }
}
