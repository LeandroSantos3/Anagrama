/*
 * Created by SharpDevelop.
 * User: leand
 * Date: 23/12/2022
 * Time: 18:13
 * 
 */
// C# program to implement
// the above approach
// C# program to implement
// the above approach
using System;
using System.Collections.Generic;

namespace Anagrama
{
	public class Permutacao{
	   
static void permute(String s,
                    String answer)
{   
  
    if(s.Length==0){
    	Console.Write(answer + "  ");    	
    }
    
      
    for(int i = 0 ;i < s.Length; i++)
    {
        char ch = s[i];
        String left_substr = s.Substring(0, i);
        String right_substr = s.Substring(i + 1);
        String rest = left_substr + right_substr;
        permute(rest, answer + ch);
        
        
    }
    
}
		
 public void PermutacaoRepeticoes(String palavra )
 {
 	String resposta="";
      
    Console.Write("\n Anagrama com repiticoes :\n ");
    permute(palavra, resposta);
				
}
 
 public void PermutacaoSemRepeticoes(String palavra )
 {
    String resposta="";
      
    Console.Write("\n Anagrama sem repiticoes :\n ");
    permute(palavra, resposta);    
				
}
 
 public int Contar(String palavra)
 {
 	int resul =1;
 	for(int i = 1; i<palavra.Length; i++)
 	{
 		resul = resul *i;
	}
 	return resul;
 }

  

}
}