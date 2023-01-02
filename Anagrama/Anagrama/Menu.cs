/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 18:46
 *  
 */
using System;

namespace Anagrama
	
		//Menu incorporado dos laboratorios feito em aulas
{
	/// <summary>
	/// Menu simples que irá permitir que o usuario faca a interacao com o programa - Anagrama 
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
		 Console.Clear();		 
		 Console.WriteLine("\nTeste Anagrama - trabalho pratico 1:\n");
		 for (int i=0;i<this.opcao.Length;i++)
		 	Console.WriteLine(" {0}... {1}",retorno[i],opcao[i]);
		 Console.Write("\nDigite a sua opção: ");
		 do
		   tecla=Console.ReadKey(true);
		 while (retornos.IndexOf(tecla.KeyChar)==-1);
		 Console.WriteLine();
		return tecla.KeyChar;
		}
			
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

