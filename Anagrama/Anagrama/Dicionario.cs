/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 01/01/2023
 * Time: 23:50
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Anagrama
{
	/// <summary>
	/// Classe Dicionario será o responsável para criar e carregar os ficheiros de texto com as palavras
	/// </summary>
	public class Dicionario
	{	
		ArvAVL<int, String> arvore;
		
		public int totalDicionario;
		public int permutationCount;

		private int Result
		{ 	get { return permutationCount; }
		 	set {permutationCount = value;}}
	
		public Dicionario() //construtor
		{
			this.totalDicionario = 0;
			this.permutationCount =0;
			arvore = new ArvAVL<int, String>();
		}

		/// <summary>
		/// Metodo encarregue de carregar o Dicionario na pasta raiz da pasta para o projeto
		/// </summary>
		/// <returns>Ele retorna uma lista com todos os dados do dicionario que respeitem o padrão do Protocolo</returns>
		public List<String> CarregarDicionario(){
			
			List<String> dicionario = new List<String>();			
			List<String> lstDicionario = new List<String>();
				
		try {				
				int dimensao;
				StreamReader ficheiro = new StreamReader("../../palavras.txt",System.Text.Encoding.GetEncoding("ISO-8859-1"));
		 
				int.TryParse(ficheiro.ReadLine(),out dimensao);
			 	for (int i=0;i<dimensao;i++)
				 {
				 	String palavra = ficheiro.ReadLine().ToLower();
				 	if(palavra.Length>2 && palavra.Length<=10) //condicao do protocolo
				 	{
	 				//Console.Write(palavra+"/"); //debug na consola, *teste*
			 		
			 		dicionario.Add(palavra); //adicionar ao dicionario
			 		arvore.Add(palavra.GetHashCode(),palavra); //adiciona na ordem do HashCode, assim tornando a busca a frente mais rapida
			 		lstDicionario.Add(palavra);	//adicionar a listaDicionario que irá ser retornado		 		
				 	} 
				 }
			 	totalDicionario = dimensao; //para saber o tamanho original sempre
			 	permutationCount = lstDicionario.Count;
			 	return lstDicionario.ToList();
		}
		catch (Exception e)
		 {
			Console.WriteLine("*** Não foi possivel carregar o dicionario, verifique o nome do ficheiro *** \n ### Trabalhando sem um dicionario ###");
		 	Console.WriteLine("\n *** Erro! ->" + e.Message + "***");
		 	return null;
		 }	
		}
		
		/// <summary>
		/// Metodo criado com a ideia de receber uma lista com todas as permutações da palavra já calculada - a lista "match"
		/// e usando a busca binária da arvore AVL para podermos ter melhor busca e apos encontrar os valores ele preenche uma nova lista
		/// </summary>
		/// <param name="match">lista com todas as permutacoes já feitas</param>
		/// <returns>nova lista com as permutacoes encontradas no dicionario</returns>
		
		public List<String> PermutacoesEmDicionario(List<String> match) 
		{
		  List<String> listaNova = new List<String>();
		  
		  foreach (String item in match) 
		  {
		    
		    ParChaveValor<int, String> valor;
		    bool existe = arvore.Find(item.GetHashCode(), out valor);	//procura pela chave e retorna o valor    
		    
		    if (existe) //achou
		    {
		    	listaNova.Add(valor.valor.ToString()); //quando encontrado o valor ele procura o conteúdo da chave - valor.valor
		    }
		  } 
	  		return listaNova; //lista já preenchida e retornada
		}

	}
}
