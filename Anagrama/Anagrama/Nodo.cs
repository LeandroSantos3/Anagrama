using System;

namespace Anagrama
{
    /// <summary>
    /// Classe NODO utilizada para guardar as informações
    /// </summary>
    public class Nodo<TKey,TValue>
 {  
  public ParChaveValor<TKey,TValue> info;
  public Nodo<TKey,TValue> esq;	    // apontador para o nodo filho à esquerda
  public Nodo<TKey,TValue> dir;	    // apontador para o nodo filho à direita
  public int balanceamento;			// flag indicadora do balanceamento...

  public Nodo(TKey chave,TValue valor)
   {
  	this.info=new ParChaveValor<TKey,TValue>(chave,valor);
	this.esq=null;
	this.dir=null;
	this.balanceamento=0;
   } 
   
 } // fim da classe nodo
}
