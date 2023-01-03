 ﻿/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 18:13
 * 
 */
using System;
using System.Collections.Generic;

namespace Anagrama
{
		public class Permutacao{
			
			public int permutationCount;
			private int Result 
			{ 	get { return permutationCount; }
			 	set {permutationCount = value;}}
			
			public Permutacao() //construtor
			{
				permutationCount = 0;
				Result = 0;
			}
		
		//// <summary>
		/// Metodo que faz a combinacao de cada letra da string e suas variacoes
		/// </summary>
		/// <param name="s">palavra introduzida pelo user</param>
		/// <param name="answer">respostas geradas pela recursividade</param>
		
		public void PermutacaoComRepeticoes(String s, String answer)
		{	
		//	List<String> lstPermutacao = new List<String>();
		
		if(s.Length==0){
				
				Console.Write(answer + "  /");
		//    		lstPermutacao.Add(answer);
		
				Result++; //contador interno		    		   	   	
		}			
		 
		for(int i = 0 ;i < s.Length; i++)
		{    	
		    char ch = s[i];
		    String left_substr = s.Substring(0, i);
		    String right_substr = s.Substring(i + 1);
		    String rest = left_substr + right_substr;  
		    PermutacaoComRepeticoes(rest, answer + ch);             
		}  
		//    return lstPermutacao;
		}
			
		/// <summary>
		/// Metodo que faz as permutacoes possivel mas este já leva em conta as repeticoes, eliminando-o sempre
		/// </summary>
		/// <param name="s">palavra introduzida pelo user</param>
		/// <param name="answer">resposta geradas pela recursividade</param>
		/// <param name="lista">lista que aonde será carregue o resultado </param>
		public void PermutacaoSemRepeticoes(String s, String answer, List<String>lista) {
		
		if (s.Length == 0){
			
		if(!lista.Contains(answer)){
		   	Console.Write(answer + "  /");
		    Result++;
		    lista.Add(answer);
		    return;
		}     
		}
		
		for (int i = 0; i < s.Length; i++)
		{
				char ch = s[i];
		    String left_substr = s.Substring(0, i);
		    String right_substr = s.Substring(i + 1);
		    String rest = left_substr + right_substr;  
		    PermutacaoSemRepeticoes(rest, answer + ch,lista );					
			} 
		}
		
		/// <summary>
		/// Metodo que ira trabalhar sobre o contador interno e o contador externo (print)
		/// </summary>
		public void Contar()
		{ 
			
			int result =permutationCount ;
			Console.WriteLine("\n\nGerou {0} permutacoes",result);
			Result=0; // resetar o contador interno
			return;
			
		}	
		
			/// <summary>
		/// Metodo que permita fazer a validacao para saber se a palavra esta compreendido entre 3 ~ 11 caracteres 
		/// </summary>
		/// <param name="palavra">string que sera introduzido pelo user</param>
		/// <returns>boolean</returns>
		 public bool Validar(String palavra) 
		 {
				if(palavra.Length<3 || palavra.Length>=11)
				{
					Console.WriteLine("A palavra deve estar entre 3~10 caracteres");
					return false; 
				}				
				return true;
		}
	}
}
 