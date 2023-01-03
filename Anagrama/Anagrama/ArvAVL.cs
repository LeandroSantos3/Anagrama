using System;
using System.Collections.Generic;

namespace Anagrama
	
	//Arvore AVL - foi incorporado dos projetos feito nos laboratorios em aula
{

	/// <summary>
	/// Implementa uma estrutura em forma de �rvore (balanceada)
	/// </summary>
	public class ArvAVL<TKey,TValue> : ArvBinP<TKey,TValue> where TKey : IComparable<TKey>
 {	
 	
#region atributos
// n�o necessita de os declarar... s�o herdadados de ArvBinP
#endregion
			  
#region Construtor
	/// <summary>
	/// Construtor da AVRP
	/// </summary>
	public ArvAVL()
	{
	 this.raiz=null;
	}
#endregion

#region Propriedades
// s�o as mesmas de ArvBinP
#endregion

#region M�todos P�blicos da ABP
	
	
	
			public void PreencherLista(List<TValue> lista)
		{
		  PreencherLista(raiz, lista);
		}
		
		private void PreencherLista(Nodo <TKey,TValue> node, List<TValue> lista)
		{
		  if (node == null)
		    return;
		}
	
	
		/// <summary>
		/// Faz a inser��o ordenada do par (chave/valor) na ABP
		/// Usa abordagem recursiva para efectuar a inser��o 
		/// </summary>
		/// <param name="chave">Chave a inserir</param>
		/// <param name="valor">Valor a inserir</param>
		public new void Add(TKey chave,TValue valor)
		{
		 Nodo<TKey,TValue> nodoAInserir = new Nodo<TKey,TValue>(chave,valor); // criar nodo
		 bool alteracao=false;
		 this.raiz=InserirRecursivamente(this.raiz,nodoAInserir,ref alteracao);  // inserir nodo
		}
		
		/// <summary>
		/// Faz a remo��o de um elemento da ABP
		/// Usa abordagem recursiva para efectuar a remo��o 
		/// </summary>
		/// <param name="chave">chave do valor a remover</param>
		public new void Remove(TKey chave)
		{
		 this.raiz=RemoverRecursivamente(this.raiz,chave);
		}
		
		/// <summary>
		/// Efectua a pesquisa de uma determinada chave na ABP
		/// N�o necessitamos de o desenvolver, utilizamos o da classe base...
		/// </summary>
		/// public bool Find(TKey chave,out ParChaveValor<TKey,TValue> saida)
		
		/// <summary>
		/// Efectua a passagem dos elementos da �rvore para um vector de elementos
		/// N�o necessitamos de o desenvolver, utilizamos o da classe base...
		/// </summary>
		/// public ParChaveValor<TKey,TValue>[] ToArray(Travessia tipoTravessia)
		
		// m�todo que desenha a �rvore numa Image criada com tamanho comprimentoxaltura
		// necessito de o ter aqui pois a forma de desenhar muda um pouco...

#endregion

#region M�todos Est�ticos da Classe ArvBinP

    private static Nodo<TKey,TValue> BalanceamentoEE(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> nesq = raiz.esq;
     raiz.esq=nesq.dir;
     raiz.balanceamento=0;
     nesq.dir=raiz;
     nesq.balanceamento=0;
     return nesq;
    }

    private static Nodo<TKey,TValue> BalanceamentoED(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> nesq = raiz.esq;
     Nodo<TKey,TValue> nesqdir = nesq.dir;
     nesq.dir=nesqdir.esq;
     raiz.esq=nesqdir.dir;
     if (nesqdir.balanceamento==-1)
        {raiz.balanceamento=0;
     	 nesq.balanceamento=1;     	
        }
     if (nesqdir.balanceamento==0)
        {raiz.balanceamento=0;
     	 nesq.balanceamento=0;     	
        }
     if (nesqdir.balanceamento==1)
        {raiz.balanceamento=-1;
     	 nesq.balanceamento=0;     	
        }
     nesqdir.esq=nesq;
     nesqdir.dir=raiz;
     nesqdir.balanceamento=0;
     return nesqdir;
    }

    private static Nodo<TKey,TValue> BalanceamentoEsq(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> nesq = raiz.esq;
     if (nesq.balanceamento==-1)
      	return BalanceamentoED(raiz);
      else
      	return BalanceamentoEE(raiz);
    }
     
    private static Nodo<TKey,TValue> BalanceamentoDD(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> ndir = raiz.dir;
     raiz.dir=ndir.esq;
     raiz.balanceamento=0;
     ndir.esq=raiz;
     ndir.balanceamento=0;
     return ndir;
    }
    
    private static Nodo<TKey,TValue> BalanceamentoDE(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> ndir = raiz.dir;
     Nodo<TKey,TValue> ndiresq = ndir.esq;
     ndir.esq=ndiresq.dir;
     raiz.dir=ndiresq.esq;
     if (ndiresq.balanceamento==-1)
        {raiz.balanceamento=1;
     	 ndir.balanceamento=0;     	
        }
     if (ndiresq.balanceamento==0)
        {raiz.balanceamento=0;
     	 ndir.balanceamento=0;     	
        }
     if (ndiresq.balanceamento==1)
        {raiz.balanceamento=0;
     	 ndir.balanceamento=-1;     	
        }
     ndiresq.dir=ndir;
     ndiresq.esq=raiz;
     ndiresq.balanceamento=0;
     return ndiresq;
    }

    // processa a parte do balanceamento � direita
    private static Nodo<TKey,TValue> BalanceamentoDir(Nodo<TKey,TValue> raiz)
    {Nodo<TKey,TValue> ndir = raiz.dir;
     if (ndir.balanceamento==-1)
     	return BalanceamentoDD(raiz);
      else
      	return BalanceamentoDE(raiz);
    }
    
    // m�todo que trata dos procedimentos de inser��o de um nodo na �rvore
	private static Nodo<TKey,TValue> InserirRecursivamente(Nodo<TKey,TValue> raiz,Nodo<TKey,TValue> novo, ref bool alteracao)
	{
	 if (raiz==null)
		{alteracao=true;
         return novo;
		}
	 int dif=raiz.info.chave.CompareTo(novo.info.chave);
	 if (dif==0)					// substituir valores do nodo
	   {raiz.info.valor=novo.info.valor;
	 	return raiz;
	   }
	 if (dif>0)
	   {raiz.esq=InserirRecursivamente(raiz.esq,novo,ref alteracao);
	 	if (alteracao==true && raiz.balanceamento==-1)
	 	  {
	 	   raiz.balanceamento=0;
	 	   alteracao=false;
	 	   return raiz;
	 	  }
	 	if (alteracao==true && raiz.balanceamento==0)
	 	  { 
	 	   raiz.balanceamento=1;
	 	   return raiz;
	 	  }
	 	if (alteracao==true && raiz.balanceamento==1)
	 	 {
	 	  raiz=BalanceamentoEsq(raiz);
	 	  alteracao=false;
	 	  return raiz;
	 	 }
	   }		// fim do if (dif>0)
	 else					// se for para inserir do lado direito
	  {
	 	raiz.dir=InserirRecursivamente(raiz.dir,novo,ref alteracao);
	 	if (alteracao==true && raiz.balanceamento==1)
	 	  {
	 	   raiz.balanceamento=0;
	 	   alteracao=false;
	 	   return raiz;
	 	  }
	 	if (alteracao==true && raiz.balanceamento==0)
	 	 {
	 	  raiz.balanceamento=-1;
	 	  return raiz;
	 	 }
	 	if (alteracao==true && raiz.balanceamento==-1)
	 	 {
	 	  raiz=BalanceamentoDir(raiz);
	 	  alteracao=false;
	 	  return raiz;
	 	 }	 	
	  }  // fim do else if (dif>0)
	 return raiz;
	}

		
	// m�todo que faz a Remo��o de um elemento da �rvore
	// NOTA> este m�todo da forma que est� implementado na� mant�m a ARVORE BALANCEADA...
	private static Nodo<TKey,TValue> RemoverRecursivamente(Nodo<TKey,TValue> raiz,TKey chave)
	{if (raiz==null)
		return null;
	 int dif=raiz.info.chave.CompareTo(chave);
	 if (dif==0)								// elemento encontrado
	    {if (raiz.esq==null)					// sem descendentes � esquerda
	        return raiz.dir;
	 	 if (raiz.dir==null)					// ou sem descendentes � direita
	 		return raiz.esq;
	 	 ParChaveValor<TKey, TValue> menor=MenorElemento(raiz.dir);
	     raiz.info=menor;
	     raiz.dir=RemoverRecursivamente(raiz.dir,menor.chave);
	 	 return raiz;
	     }
	 if (dif>0)
	 	raiz.esq=RemoverRecursivamente(raiz.esq,chave);
	  else
	  	raiz.dir=RemoverRecursivamente(raiz.dir,chave);
	return raiz;	
	}
	   
   
	// m�todo que "desenha" a �rvore num objecto do tipo Graphics
	// necessitamos deste m�todo para poder mostrar o balanceamento
#endregion


 }
}
