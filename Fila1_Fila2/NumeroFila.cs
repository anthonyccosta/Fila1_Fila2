﻿using Fila1_Fila2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fila1_Fila2
{
    internal class NumeroFila
    {
        Numero? inicio;
        Numero? fim;

        public NumeroFila()
        {
            this.inicio = null;
            this.fim = null;
        }
        public void push(Numero aux)
        {
            if (IsEmpty())
            {
                this.inicio = this.fim = aux;
            }
            else
            {
                this.fim.setProximo(aux);
                this.fim = aux;
            }
        }
        internal bool IsEmpty()
        {
            return inicio == null && fim == null;
        }
        public int pop()
        {
            int valor = 0;
            if (!IsEmpty())
            {
                if (fim == inicio) // se cabeca = cauda entao so tem 1 elemento na fila
                {
                    valor = this.inicio.getNumero();
                    inicio = fim = null;
                }
                else
                {
                    valor = this.inicio.getNumero();
                    this.inicio = this.inicio.getProximo();
                }
            }
            return valor;
        }
        public int getContador()
        {
            int contador = 0;
            Numero aux = inicio;
            if (!IsEmpty())
            {
                do
                {
                    contador++;
                    aux = aux.getProximo();
                } while (aux != null);
            }
            return contador;
        }
        public float getValores(int tamanho)
        {
            Numero aux = inicio;
            float valor = 0, contador = 0;
            float resultado = 0;
            if (!IsEmpty())
            {
                switch (tamanho)
                {
                    case 0: // pega o menor valor
                        valor = resultado = aux.getNumero();
                        do
                        {
                            aux = aux.getProximo();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor < resultado)
                            {
                                resultado = valor;
                            }
                        } while (aux != null);
                        break;
                    case 1: // pega o maior valor
                        valor = resultado = aux.getNumero();
                        do
                        {
                            aux = aux.getProximo();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor > resultado)
                            {
                                resultado = valor;
                            }
                        } while (aux != null);
                        break;
                    default:
                        valor = aux.getNumero();
                        do
                        {
                            contador++;
                            aux = aux.getProximo();
                            if (aux != null)
                            {
                                valor += aux.getNumero();
                            }
                        } while (aux != null);
                        if (contador > 0)
                        {
                            resultado = (valor / contador);
                        }
                        break;
                }
            }
            return resultado;
        }
        public string print(int tipo)
        {
            Numero aux = inicio;
            string texto = "";
            if (!IsEmpty())
            {
                switch (tipo)
                {
                    case 0: // pares
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 == 0)
                                {
                                    texto += $"{aux.ToString()} ";
                                }
                            }
                            aux = aux.getProximo();
                        } while (aux != null);
                        break;
                    case 1: // impares
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 != 0)
                                {
                                    texto += $"{aux.ToString()} ";
                                }
                            }
                            aux = aux.getProximo();
                        } while (aux != null);
                        break;
                    default: // todos os numeros
                        do
                        {
                            texto += $"{aux.ToString()} ";
                            aux = aux.getProximo();
                        } while (aux != null);
                        break;
                }
            }
            return texto;
        }
    }
}