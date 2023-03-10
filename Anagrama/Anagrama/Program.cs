/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 19:57
 *  
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
			List<String>listaComparacao = new List<String>(); //lista que sera completada com as permutacoes feitas de acordo com as palavrass do user
			List<String>listaCarregada = new List<String>(); //lista que sera completada com os dados do dicionário

			Stopwatch stopwatch0 = Stopwatch.StartNew();
			
			if(dicionario.CarregarDicionario()!=null)
			{
				stopwatch0.Stop();
				Console.WriteLine("Teste de Anagrama\n A criar dicionario ... Carregado com {0} palavras de {1} no total", dicionario.permutationCount, dicionario.totalDicionario);
				Console.WriteLine("\nTempo de execução total: {0}", stopwatch0.Elapsed);						
			}
          		Menu.TeclaParaContinuar();          	
          	
          	do {
				opcao = menu.MenuSimples();		
				
				switch (opcao) {
					case '1':
						Console.WriteLine("## Teste Anagrama ##\n Permutações com repeticoes ****");
						Console.Write("Insira a palavra para fazer as combinacoes :__ ");
						String palavra = Console.ReadLine();		   		
		   				
						Stopwatch stopwatch = Stopwatch.StartNew(); //inicicar nova contagem
		   		
						if (perm.Validar(palavra) == true) {
							Console.Write("\n Anagrama com repiticoes :\n ");		   			  			
							perm.PermutacaoComRepeticoes(palavra, "");		   			
							perm.Contar();
							
							stopwatch.Stop();//parar a contagem
							Console.WriteLine("\nTempo de execução total: {0}", stopwatch.Elapsed);//printar o tempo da contagem
						}
						break;
					case '2':
						Console.WriteLine("## Teste Anagrama ##\n Permutações sem repeticoes ****");
						Console.Write("Insira a palavra para fazer as combinacoes:__ ");
						String palavra1 = Console.ReadLine();
						
		   				Stopwatch stopwatch2 = Stopwatch.StartNew();
		   				
						if (perm.Validar(palavra1) == true) {
							Console.Write("\n Anagrama sem repiticoes :\n ");		   			  			
							perm.PermutacaoSemRepeticoes(palavra1, "",new List<String>());
							perm.Contar();
							
							stopwatch2.Stop();
							Console.WriteLine("\nTempo de execução total: {0}", stopwatch2.Elapsed);
						}
						break;
					case '3':				
						Console.WriteLine("## Teste Anagrama ##\n Apos permutacao verificar a sua existencia no Dicionario Carregado ****");
						Console.Write("Insira a palavra para fazer as combinacoes e verificar o resultado no Dicionario:__ ");
						String palavra3 = Console.ReadLine();
						
						Stopwatch stopwatch3 = Stopwatch.StartNew();						
						
						if(perm.Validar(palavra3) == true){
						Console.WriteLine("Forarm Geradas essas permutações, depois será analizado se existe no Dicionario");
						perm.PermutacaoSemRepeticoes(palavra3,"",listaComparacao); //já neste quero que seja carregado para uma lista especifica, que será usada para posterior consulta
						perm.Contar();
						listaCarregada = dicionario.CarregarDicionario();
						List<String>listaNova = dicionario.PermutacoesEmDicionario(listaComparacao); //essa lista seria carregado com os resultados da busca binaria na arvore AVL
						
						//Debug para eu ver todos as listas e entender melhor o funcionamento interno
						
						Console.WriteLine("\n\nlista Carregada tem total de "+ listaCarregada.Count +" palavras");
						Console.WriteLine("lista Comparacao tem total de "+ listaComparacao.Count +" palavras");
						Console.WriteLine("lista nova tem total de "+ listaNova.Count +" palavras encontradas no Dicionario:\n");
												
						foreach (var item in listaNova) 
						{
							Console.Write (item + "  /");					
						}
						
						stopwatch3.Stop();
						Console.WriteLine("\n\nTempo de execução total: {0}", stopwatch3.Elapsed);
						listaComparacao.Clear(); //tenho que limpar a lista de permutacao senão ele sempre será carregado com os dados da pesquisa anterior					
						
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

