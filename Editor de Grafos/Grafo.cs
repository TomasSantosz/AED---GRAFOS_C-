using System;
using System.Collections.Generic;
using System.Text;
using Editor_de_Grafos;
using System.Drawing;

namespace Editor_de_Grafos
{
    public class Grafo : GrafoBase, iGrafo
    {
        /* private bool[] visitado; */
                
       
        bool[] visitado = new bool[100];
        
        
        public void AGM(int v)
        {

        }

        public void caminhoMinimo(int i, int j)
        {

        }

        public void completarGrafo()
        {
            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                for (int j = 0; j < matAdj.GetLength(0); j++)
                {
                    if (getAresta(i, j) != null)
                    {
                        base.OnClick(i);
                        if (!drag)
                            f.clicouVertice(this);
                    }
                        
                }
            }
        }

        public bool isEuleriano()
        {
            int i;
            for (i = 0; i < getN(); i++)
            {
                if (grau(i) % 2 != 0)
                    return false;

            }
            if (getN() != 0)
                return true;
            else
                return false;
        }

        public bool isUnicursal()
        {
            int grauImpar = 0;
            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                if (grau(i) % 2 != 0)
                    grauImpar++;
            }
            return (grauImpar == 2);
        }

        public void largura(int v)
        {
            Fila f = new Fila(matAdj.GetLength(0));
            f.enfileirar(v);
            visitado[v] = true; // marca V como visitado
            while (!f.vazia())
            {
                v = f.desenfileirar(); // retira o próximo vértice da fila
                for (int i = 0; i < matAdj.GetLength(0); i++)
                {
                    // se I é adjacente a V e I ainda não foi visitado
                    if (matAdj[v, i] != matAdj[0, 0] && !visitado[i])
                    {
                        getAresta(v, i).setCor(Color.Orange);
                        visitado[i] = true; // marca i como visitado
                        f.enfileirar(i); // enfileira i
                    }
                }
            }
        }

        public void numeroCromatico()
        {
        }

        public string paresOrdenados()
        {
            string msg = "E={";
            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                for (int j = 0; j < matAdj.GetLength(0); j++)
                {
                    if (matAdj[i, j] != matAdj[0, 0])
                        msg += "(" + i + "," + j + "),";
                }
            }
            msg += "}";
            return msg;
        }
        public void profundidade(int v)
        {
            
            visitado[v] = true;
            
            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                if (matAdj[v, i] != matAdj[0, 0] && !visitado[i])
                {
                    getAresta(v, i).setCor(Color.Orange);
                    profundidade(i);
                }
            }
        }
    }
}
