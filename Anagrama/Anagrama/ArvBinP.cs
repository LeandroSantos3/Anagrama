using System;
using System.Drawing;
using System.Collections;
using System.Runtime.ExceptionServices;

namespace Anagrama
	
	//Arvore Binário de Pesquisa - foi incorporado dos projetos feito nos laboratorios em aula
{
    /// <summary>
    /// Implementa uma Arvore,
    /// </summary>
    public class ArvBinP<TKey,TValue> where TKey : IComparable<TKey>
 {	
 	
#region campos/enumerados P�blicos da Classe
// enumerado que lista as possibilidades de travessia na lista
public enum Travessia {InOrder=1, PreOrder=2, PosOrder=3, EmLinha=4 }
#endregion
 	
#region Campos Privados da Classe 
      /// <summary>
      /// Campo privado que marca a raiz da ABP
      /// </summary>
	  protected Nodo<TKey,TValue> raiz;  
#endregion 	
 	  
#region Construtor
	/// <summary>
	/// Construtor da AVRP
	/// </summary>
	public ArvBinP()
	{
	this.raiz=null; // inicializar a �rvore..
	}
#endregion

#region Propriedades
	/// <summary>
	/// (leitura) Devolve o n�mero de elementos na ABP
	/// </summary>
	public int Count
	{get {
		  return ContarRecursivamente(this.raiz);
		 }
	}
	
	/// <summary>
	/// (leitura) Devolve o n�mero de elementos folha (sem descendentes) existentes na ABP
	/// </summary>
	public int ContaFolhas
	{get { 
		  return ContarFolhasRecursivamente(this.raiz);			
		 }		
	}

	/// <summary>
	/// (leitura): True caso da ABP estar Vazia
	/// </summary>
	public bool Vazia
	{get {
			if (this.raiz==null)
				return true;
			else
				return false;
		 }		
	}
	
#endregion

#region M�todos P�blicos da ABP
	    /// <summary>
	    /// Limpar o cont�udo de uma AVP
	    /// </summary>
		public void Clear()
	    {
		 this.raiz=null; // deixar o garbage collector fazer o "servi�o"
	    }

        public int Nivel()
		{
			return this.Nivel(raiz);
		}

        public int Nivel(Nodo<TKey, TValue> raiz)
        {
            int nivel = 0;
            if (raiz == null)
            {
                return 0;
            }

            int dir = Nivel(raiz.dir);
            int esq = Nivel(raiz.esq);
            if (dir > esq)
            {
                nivel = dir;
            }
            else
            {
                nivel = esq;
            }

            return nivel + 1;

        }

        /// <summary>
        /// Faz a inser��o ordenada do par (chave/valor) na ABP
        /// Usa abordagem recursiva para efectuar a inser��o 
        /// </summary>
        /// <param name="chave">Chave a inserir</param>
        /// <param name="valor">Valor a inserir</param>
        public void Add(TKey chave,TValue valor)
		{
		 Nodo<TKey,TValue> nodoAInserir = new Nodo<TKey,TValue>(chave,valor); // criar nodo
		 this.raiz=InserirRecursivamente(this.raiz,nodoAInserir);  // inserir nodo
		}
		
		/// <summary>
		/// Faz a remo��o de um elemento da ABP
		/// Usa abordagem recursiva para efectuar a remo��o 
		/// </summary>
		/// <param name="chave">chave do valor a remover</param>
		public void Remove(TKey chave)
		{
		 this.raiz=RemoverRecursivamente(this.raiz,chave);
		}
		
		/// <summary>
		/// Efectua a pesquisa de uma determinada chave na ABP
		/// </summary>
		/// <param name="chave">chave a pesquisar</param>
		/// <param name="saida">local onde colocar a infoma��o, caso encontre algo</param>
		/// <returns>True se encontrou</returns>
		public bool Find(TKey chave,out ParChaveValor<TKey,TValue> saida)
		{saida = default(ParChaveValor<TKey, TValue>);
		 return PesquisarRecursivamente(this.raiz,chave,ref saida);
		}
		
		/// <summary>
		/// Efectua a passagem dos elementos da �rvore para um vector de elementos
		/// </summary>
		/// <param name="tipoTravessia">Forma de arranjar os elementos no vector</param>
		/// <returns></returns>
		public ParChaveValor<TKey,TValue>[] ToArray(Travessia tipoTravessia)
		{ParChaveValor<TKey,TValue>[] vector;
		 if (this.Vazia==true)
				return null;
		 vector = new ParChaveValor<TKey, TValue>[this.Count];
		 int i=0;
		 switch(tipoTravessia) {
		 	case Travessia.InOrder:PreencheVectorInOrderRecursivamente(this.raiz,vector,ref i);
		 	                       break;
		 	case Travessia.PreOrder:PreencheVectorPreOrderRecursivamente(this.raiz,vector,ref i);
		 	                        break;
		    case Travessia.PosOrder:PreencheVectorPosOrderRecursivamente(this.raiz,vector,ref i);
								    break;
		    case Travessia.EmLinha :PreencheVectorEmLinha(this.raiz,vector);
								    break;
		 }
		 return vector;			
		}
		
		// m�todo que desenha a �rvore numa Image criada com tamanho comprimentoxaltura
		
#endregion

#region M�todos Est�ticos da Classe ArvBinP

	private static Nodo<TKey,TValue> InserirRecursivamente(Nodo<TKey,TValue> raiz,Nodo<TKey,TValue> novo)
	{if (raiz==null)
		 return novo;
	 int dif = raiz.info.chave.CompareTo(novo.info.chave);
	 if (dif==0)
	 	raiz.info=novo.info;	// substituir informa��o
	 else
	 	if (dif<0)				// inserir � direita
	 		raiz.dir=InserirRecursivamente(raiz.dir,novo);
	     else					// inserir � esquerda
	 		raiz.esq=InserirRecursivamente(raiz.esq,novo);

	 return raiz;
	}

	// m�todo que faz a pesquisa de um elemento
	private static bool PesquisarRecursivamente(Nodo<TKey,TValue> raiz,TKey chave,ref ParChaveValor<TKey,TValue> saida)
	{
	 if (raiz==null)
		return false;
	 int dif = raiz.info.chave.CompareTo(chave);
	 if (dif==0)  // encontrado o valor
	   {
	    saida=raiz.info;
	    return true;
	   }
	 if (dif<0)
	 	return PesquisarRecursivamente(raiz.dir,chave,ref saida);
	 else
	 	return PesquisarRecursivamente(raiz.esq,chave,ref saida);
	}	
	
	// devolve o menor elemento de uma �rvore (default se vazia)
	protected static ParChaveValor<TKey,TValue> MenorElemento(Nodo<TKey,TValue> raiz)
	{if (raiz==null)
	  	return default(ParChaveValor<TKey,TValue>); 
     Nodo<TKey, TValue> aux= raiz;
 
     while (aux.esq!=null)
     	aux=aux.esq;

     return aux.info;
	}
	
	// m�todo que faz a Remo��o de um elemento da �rvore
	private static Nodo<TKey,TValue> RemoverRecursivamente(Nodo<TKey,TValue> raiz,TKey chave)
	{if (raiz==null)
		return null;		// n�o encontrou

     int dif = raiz.info.chave.CompareTo(chave);
	 
	 if (dif>0)		// remover � esquerda
	 	raiz.esq=RemoverRecursivamente(raiz.esq,chave);
	 
	 if (dif<0)		// remover � direira
	 	raiz.dir=RemoverRecursivamente(raiz.dir,chave);
	 
	 if (dif==0) // encontrei o valor a remover
	  {
	 	if (raiz.esq==null)		// � folha ou s� tem desc. � direita
	 		return raiz.dir;
	 	if (raiz.dir==null)		// s� tem desc., � esquerda...
	 		return raiz.esq;
	 	ParChaveValor<TKey, TValue> menor = MenorElemento(raiz.dir);
	 	raiz.info=menor;
	 	raiz.dir=RemoverRecursivamente(raiz.dir,menor.chave);	 	
	  }
	return raiz;	
	}
	
	// m�todo que conta o n�mero de nodos existentes numa ArvBin�ria
	private static int ContarRecursivamente(Nodo<TKey,TValue> raiz)
	{
	 if (raiz==null)
		return 0;
	 return 1 + ContarRecursivamente(raiz.esq)+ ContarRecursivamente(raiz.dir);	 
	}
	
	// m�todo que conta o n�mero de folhas existentes na �rvore
	private static int ContarFolhasRecursivamente(Nodo<TKey,TValue> raiz)
	{
	 if (raiz==null)
		return 0;
	 if (raiz.esq==null && raiz.dir==null)
	    return 1;
      else
	   return ContarFolhasRecursivamente(raiz.esq)+ContarFolhasRecursivamente(raiz.dir);
	}
	
	
   // m�todo que faz a travessia de uma �rvore, colocando os elementos num array, ordenados por chave
   private void PreencheVectorInOrderRecursivamente(Nodo<TKey,TValue> raiz,ParChaveValor<TKey,TValue>[] vector,ref int indice)
   {if (raiz==null)
   		return;
   	PreencheVectorInOrderRecursivamente(raiz.esq,vector,ref indice);
   	vector[indice]=raiz.info;
   	indice++;
   	PreencheVectorInOrderRecursivamente(raiz.dir,vector,ref indice);
   }

   // m�todo que faz a travessia de uma �rvore, m�todo pre Order
   private void PreencheVectorPreOrderRecursivamente(Nodo<TKey,TValue> raiz,ParChaveValor<TKey,TValue>[] vector,ref int indice)
   {if (raiz==null)
   		return;
   	vector[indice]=raiz.info;
   	indice++;
   	PreencheVectorPreOrderRecursivamente(raiz.esq,vector,ref indice);
   	PreencheVectorPreOrderRecursivamente(raiz.dir,vector,ref indice);
   }

   // m�todo que faz a travessia de uma �rvore, m�todo PosOrder
   private void PreencheVectorPosOrderRecursivamente(Nodo<TKey,TValue> raiz,ParChaveValor<TKey,TValue>[] vector,ref int indice)
   {if (raiz==null)
   		return;   	
   	PreencheVectorPosOrderRecursivamente(raiz.esq,vector,ref indice);
   	PreencheVectorPosOrderRecursivamente(raiz.dir,vector,ref indice);
   	vector[indice]=raiz.info;
   	indice++;
   }
   
   // m�todo que faz a travessia de uma �rvore por n�veis, preenchendo um vector ao fazer essa passagem
   // travessia por n�vel (Raiz da �rvore,Descendentes de arv (esq e dir),Descendentes dos descendentes, etc..)
   // nota: Se tiverem alguma dificuldade neste m�todo pensem em usar como auxiliar
   // alguma das estruturas de dados j� anteiromente abordadas na unidade - por exemplo Filas/Queue de Nodos ;)
   private void PreencheVectorEmLinha(Nodo<TKey,TValue> raiz, ParChaveValor<TKey,TValue>[] vector)
   {
   	//...
   	//...
   	//...
   }
   
	// m�todo que "desenha" a �rvore num objecto do tipo Graphics
#endregion


 }
}
