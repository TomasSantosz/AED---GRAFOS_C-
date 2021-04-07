using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        #region Botoes de Algoritmo do Menu
        private void BtParesOrd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(g.paresOrdenados(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtGrafoEuleriano_Click(object sender, EventArgs e)
        {
            if (g.isEuleriano())
                MessageBox.Show("O grafo é Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não é Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtGrafoUnicursal_Click(object sender, EventArgs e)
        {
            if (g.isUnicursal())
                MessageBox.Show("O grafo é Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não é Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtBuscaProfundidade_Click(object sender, EventArgs e)
        {


        }

        #endregion --------------------------------------------------------------------------------------------------

        #region botoes restantes do menu

        private void BtNovo_Click(object sender, EventArgs e)
        {
            g.limpar();
        }

        private void BtAbrir_Click(object sender, EventArgs e)
        {
            if (OPFile.ShowDialog() == DialogResult.OK)
            {
                g.abrirArquivo(OPFile.FileName);
                g.Refresh();
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (SVFile.ShowDialog() == DialogResult.OK)
            {
                g.SalvarArquivo(SVFile.FileName);
            }
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtPeso_Click(object sender, EventArgs e)
        {
            if (BtPeso.Checked)
            {
                BtPeso.Checked = false;
                g.setExibirPesos(false);

            }
            else
            {
                BtPeso.Checked = true;
                g.setExibirPesos(true);
            }
            g.Refresh();
        }

        private void BtPesoAleatorio_Click(object sender, EventArgs e)
        {
            if (BtPesoAleatorio.Checked)
            {
                BtPesoAleatorio.Checked = false;
                g.setPesosAleatorios(false);
            }
            else
            {
                BtPesoAleatorio.Checked = true;
                g.setPesosAleatorios(true);
            }
        }

        private void BtSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editor de Grafos - 2021/1\n\nDesenvolvido por:\nNatan Macedo de Magalhaes\nVirgilio Borges de Oliveira\n\nAlgoritmos e Estruturas de Dados II\nFaculdade COTEMIG\nSomente para fins didáticos.", "Sobre o Editor de Grafos...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion --------------------------------------------------------------------------------------------------

        private void completarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.completarGrafo();
        }

        private void algoritmosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profundidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vertice v = g.getVerticeMarcado();
            if (v == null)
            {
                MessageBox.Show("Escolha a Raiz da busca", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                g.profundidade(v.getNum());
            }            
        }

        private void larguraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vertice v = g.getVerticeMarcado();
            if (v == null)
            {
                MessageBox.Show("Escolha a Raiz da busca", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                g.largura(v.getNum());
            }           
        }
    }
}
