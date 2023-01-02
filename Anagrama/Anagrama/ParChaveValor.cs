using System;

namespace Anagrama
{
    /// <summary>
    /// Estrutura que agrupa num �nico identificador as informa��es de
    /// chave e valor dos dados a guardar numa qualquer estrutura de dados
    /// </summary>
    public struct ParChaveValor<TKey,TValue>
	{
	 /// <summary>
	 /// tipo do campo chave 
	 /// </summary>
	 public TKey   chave;
	 
	 /// <summary>
	 /// tipo do campo valor
	 /// </summary>
	 public TValue valor;   // informa��o Completa 
	 
	 /// <summary>
	 /// Construtor da Classe ParChave
	 /// </summary>
	 /// <param name="chave">valor do campo  chave</param>
	 /// <param name="valor">valor do campo valor</param>
	 public ParChaveValor(TKey chave, TValue valor)
	 {this.chave=chave;
	  this.valor=valor;	 	
	 }		
}	
}
