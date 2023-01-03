 ﻿/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 18:13
 * 
 */
using System;
using System.Collections.Generic;
//using System.Linq;

namespace Anagrama
{
	public class Permutacao{
		
		public int permutationCount = 0;
		private int Result 
		{ 	get { return permutationCount; }
		 	set {permutationCount = value;}}
		
public void PermutacaoComRepeticoes(String s, String answer)
{	
//	List<String> lstPermutacao = new List<String>();
	
    if(s.Length==0){
			
    		Console.Write(answer + "  /");
//    		lstPermutacao.Add(answer);
			Result++;			
    		   	   	
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
/// Metod
/// </summary>
 public void Contar()
 { 
 	
 	int result =permutationCount ;
 	Console.WriteLine("\nGerou {0}",result);
 	Result=0; // senao sempre é ta continjua ta conta e soma
 	return;
 	
 }	
 
 /// <summary>
	/// Metodo que permita fazer a validacao para saber se a palavra esta compreendido entre 3 ~ 11 caracteres 
	/// </summary>
	/// <param name="palavra">string que sera introduzido pelo user</param>
	/// <returns>se for menor que 3 ou maior que 10 return false </3></returns>se></returns>se></returns>
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
 