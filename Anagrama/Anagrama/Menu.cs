/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Anagrama
{
	/// <summary>
	/// Description of Menu.
	/// Menu que irá permitir que o usuario faca a interacao com o programa - Anagrama 
	/// </summary>
	public class Menu
	{
		private static string retorno = "123456789ABCDEFGHIJKLMNOPQRSTUVWYZ";
		private string[] opcao;
		/// <summary>
		/// Método que recebe uma lista de opções, criando um menu com elas
		/// </summary>
		/// <param name="lista">Opções a serem criadas no menu</param>
		public Menu(params string[] lista)
		{
		 opcao = new string[lista.Length];
		 for (int i=0;i<lista.Length;i++)
		 	opcao[i]=lista[i];
		}

		// mostra o menu em consola e devolve a opção escolhida (na forma de int)
		// só sai depois de digitada uma das opçoes
		public char MenuSimples()
		{
			ConsoleKeyInfo tecla;
		 string retornos = retorno.Substring(0,opcao.Length);
		// Console.BackgroundColor=corFundo;
		 Console.Clear();
		 //Console.ForegroundColor=corOpcoes;
		 Console.WriteLine("\nTeste Anagrama - trab pratico 1:\n");
		 for (int i=0;i<this.opcao.Length;i++)
		 	Console.WriteLine(" {0}... {1}",retorno[i],opcao[i]);
		 Console.Write("\nDigite a sua opção: ");
		 do
		   tecla=Console.ReadKey(true);
		 while (retornos.IndexOf(tecla.KeyChar)==-1);
		 Console.WriteLine();
		return tecla.KeyChar;
		}

//		
//		// Outra forma de mostra o menu em consola e devolve a opção escolhida (na forma de int)
//		// só sai depois de digitada uma das opçoes
//		public char MenuLindo(ConsoleColor corFundo, ConsoleColor corOpcoes)
//		{ConsoleKeyInfo tecla;
//		 int escolha;
//		 string retornos = retorno.Substring(0,opcao.Length);
//		 Console.BackgroundColor=corFundo;
//		 Console.Clear();  // fica no topo esquerdo
//		 Console.ForegroundColor=corOpcoes;
//		 Console.WriteLine("\nOpções Disponíveis:\n");
//		 for (int i=0;i<this.opcao.Length;i++)
//		 	Console.WriteLine(" {0}... {1}",retorno[i],opcao[i]);
//		 Console.Write("\nSeleccione a sua opção (ENTER para activar): ");
//		 escolha=0;
//		 Console.BackgroundColor=corOpcoes;
//		 Console.ForegroundColor=corFundo;
//		 Console.SetCursorPosition(0,escolha+3);
//		 Console.Write(" {0}... {1}",retorno[escolha],opcao[escolha]);		  
//		 do {
//		   tecla=Console.ReadKey(true);
//		   // apagar escolha anterior
//		   Console.BackgroundColor=corFundo;
//		   Console.ForegroundColor=corOpcoes;
//		   Console.SetCursorPosition(0,escolha+3);
//		   Console.Write(" {0}... {1}",retorno[escolha],opcao[escolha]);		 
//		   if (tecla.Key==ConsoleKey.DownArrow && escolha<opcao.Length-1)
//		       escolha=escolha+1;
//		   if (tecla.Key==ConsoleKey.UpArrow && escolha>0)
//		       escolha=escolha-1;
//		   // Salientar escolha actualizada
//		   Console.BackgroundColor=corOpcoes;
//		   Console.ForegroundColor=corFundo;
//		   Console.SetCursorPosition(0,escolha+3);
//		   Console.Write(" {0}... {1}",retorno[escolha],opcao[escolha]);		 
//		 }while (tecla.Key!= ConsoleKey.Enter);
//		 // repor cores e colocar cursor no sítio
//		 Console.BackgroundColor=corFundo;
//		 Console.ForegroundColor=corOpcoes;
//		 Console.SetCursorPosition(0,opcao.Length+6);
//		 return retornos[escolha];
//		}
			
		/// <summary>
		/// Espera que uma tecla seja carregada para continuar
		/// </summary>
		public static void TeclaParaContinuar()
		{
		 Console.WriteLine("\n\nCarregue numa tecla para continuar. . . ");
		 Console.ReadKey(true);	
		}
			
		
	}
}

