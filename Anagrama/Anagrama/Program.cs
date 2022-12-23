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
//		   		if(perm.Validar(palavra)==false)
//		   		   return;
//		   		  else
		   		perm.PermutacaoRepeticoes(palavra);
		   		//perm.Contar();
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
	
	} 
} 
