/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 01/01/2023
 * Time: 23:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
		ArvAVL<int, string> arvore = new ArvAVL<int, String>();	
		
		public int totalDicionario=0;
		public int permutationCount = 0;
		private int Result 
		{ 	get { return permutationCount; }
		 	set {permutationCount = value;}}
	
		public Dicionario()
		{
		}

		
		public List<String> CarregarDicionario(){
			
			List<String> dicionario = new List<String>();			
			List<String> lstDicionario = new List<String>();
			//ArvAVL<int,String> arvore = new ArvAVL<int,String>();
				
		try {
				
				int dimensao;
				StreamReader ficheiro = new StreamReader("../../palavras.txt",System.Text.Encoding.GetEncoding("ISO-8859-1"));
		 
				int.TryParse(ficheiro.ReadLine(),out dimensao);
			 	for (int i=0;i<dimensao;i++)
				 {
				 	String palavra = ficheiro.ReadLine().ToLower();
				 	if(palavra.Length>2 && palavra.Length<=10){
				 		
				 		//Console.Write(palavra+"/"); //debug na consola, *teste*
				 		dicionario.Add(palavra);
				 		arvore.Add(palavra.GetHashCode(),palavra); //adiciona na ordem do HashCode, assim tornando a busca a frente mais rapida
				 		lstDicionario.Add(palavra);				 		
				 	} 
				 }
			 	totalDicionario = dimensao;
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
		
		
		public List<String> PermutacoesEmDicionario(List<String> match) {
		
	  // Create a new, modifiable list
	  List<String> listaNova = new List<String>();
	  // Iterate through each string in the input list
	  foreach (String item in match) {
	    // Search for the string in the dictionary using the 'arvore' object
	    ParChaveValor<int, String> valor;
	    bool existe = arvore.Find(item.GetHashCode(), out valor);
	    
	    // If the string is found in the dictionary, add it to the new list
	    if (existe) {
	    	listaNova.Add(valor.valor.ToString());
	    }
	  } 
  return listaNova;
}

	}
		}
