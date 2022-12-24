/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 19:57
 *  
 */
using System;
using System.Collections.Generic;

namespace Anagrama
{	
 class Program
	{private static string[] lstMenu = { 
 		"Com Repeticoes     ",
 		"Sem Repeticoes ",
		"Por fazer...     ",
		"Por fazer... ",
		"SAIR" ,
		
								};			
	// Bloco principal do programa
	public static void Main(string[] args)
		{
			Menu menu = new Menu(lstMenu);
		 	char opcao;
		 	Permutacao perm = new Permutacao();
		 
	     do
		  {
     		opcao=menu.MenuSimples();		   
		   	switch (opcao) {
		 	  case '1':
		   		Console.WriteLine("Teste do anagrama, com repeticoes");
		   		Console.Write("Insira a palavra para fazer o jogo: ");
		   		String palavra = Console.ReadLine();
		   		if(Validar(palavra)==true){
		   			perm.PermutacaoRepeticoes(palavra);
		   			//perm.Contar();
		   		}
		   		else{
		   			Console.WriteLine("A palavra deve estar entre 3~10 caracteres");
		   		}	   		
		   		
		 			   break;
		 	  case '2':
		 			   Console.WriteLine("2");
		 			   break;
		 	  case '3':
						Console.WriteLine("3...");
		 			   break;		 			   
		 	  case '4':
		 			   Console.WriteLine("4...");
		 			   break;	 
			  case '5':
		 			   Console.WriteLine("A sair...");
		 			   break;			 			   
		 	 
		 	}
           if (opcao!='5') Menu.TeclaParaContinuar();
          }while (opcao!='5');		 
	     Console.WriteLine("\nPrograma a encerrar...");
		 Console.ReadKey(true);
		}	
	
	/// <summary>
	/// Metodo que permita fazer a validacao para saber se a palavra esta compreendido entre 3 ~ 11 caracteres 
	/// Faz sentido para mim ter o metodo aqui e não na class Permutacao prq deve ser validada antes de sair para o metodo
	/// </summary>
	/// <param name="palavra">string que sera introduzido pelo user</param>
	/// <returns>se for menor que 3 ou maior que 10 return false </3></returns>se></returns>se></returns>
	 public static bool Validar(String palavra) 
	 {
			
			if(palavra.Length<3 || palavra.Length>=11)
				return false;
			return true;
		}
	} 
}
