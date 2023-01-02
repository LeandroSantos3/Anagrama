﻿/*
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
	{
private static string[] lstMenu = { 
			"Permutação com Repetições     ",
			"Permutação sem Repetições ",
			"Mostrar todos os anagramas (existentes no dicionário carregado)     ",
			"Por fazer... ",
			"SAIR",
		
		};
		// Bloco principal do programa
		public static void Main(string[] args)
		{
			Menu menu = new Menu(lstMenu);
			char opcao;
			Permutacao perm = new Permutacao();
			Dicionario dicionario = new Dicionario();
			List<String>listaCarregada = new List<String>();
			
			
			if(dicionario.CarregarDicionario()!=null)
				Console.WriteLine("Teste de Anagrama\n A criar dicionario ... Carregado com {0} palavras de {1} no total", dicionario.permutationCount, dicionario.totalDicionario);
				
          		Menu.TeclaParaContinuar();          	
          	
          	do {
				opcao = menu.MenuSimples();		
				
				switch (opcao) {
					case '1':
						Console.WriteLine("Teste do anagrama, com repeticoes");
						Console.Write("Insira a palavra para fazer o jogo: ");
						String palavra = Console.ReadLine();		   		
		   		
		   		
						if (perm.Validar(palavra) == true) {
							Console.Write("\n Anagrama com repiticoes :\n ");		   			  			
							perm.PermutacaoComRepeticoes(palavra, "");		   			
							perm.Contar();
						}
						break;
					case '2':
						Console.WriteLine("Teste do anagrama, sem repeticoes");
						Console.Write("Insira a palavra para fazer o jogo: ");
						String palavra1 = Console.ReadLine();		   		
		   		
						if (perm.Validar(palavra1) == true) {
							Console.Write("\n Anagrama sem repiticoes :\n ");		   			  			
							perm.PermutacaoSemRepeticoes(palavra1, "",new List<String>());
							perm.Contar();
						}
						break;
					case '3':
						
						Console.Write("Insira a palavra para fazer o jogo: ");
						String palavra3 = Console.ReadLine();
						if(perm.Validar(palavra3) == true){
							
							perm.PermutacaoSemRepeticoes(palavra3,"",new List<String>());
						perm.Contar();
						listaCarregada = dicionario.CarregarDicionario();
						
//							Console.WriteLine(rep.Count);
//						listaCarregada = perm.PermutacaoComRepeticoes(palavra3,"");
						
						if(listaCarregada.Count==null)
								Console.WriteLine("\nficheiro vazio");
						else{
							Console.WriteLine("dicionario no momento tem total de "+ listaCarregada.Count +" palavras");
//							foreach (var element in listaCarregada) {
//								
//								if(listaCarregada.Contains(test))
//								   Console.Write("Achei um");
//							}
							
						}
						
						//Console.WriteLine(" ");
						
							
						}
						
						break;		 			   
					case '4':
						Console.WriteLine("Por fazer...");
						break;	 
					case '5':
						Console.WriteLine("A sair...");
						break;			 			   
		 	 
				}
				if (opcao != '5' && dicionario.CarregarDicionario()!=null)
					Menu.TeclaParaContinuar();
			} while (opcao != '5');		 
			Console.WriteLine("\nPrograma a encerrar...");
			Console.ReadKey(true);
		}
	}
}

