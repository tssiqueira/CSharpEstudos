using ManipulacaoDeArquivo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastrosDeCarros
{
    public partial class formCadastrar : Form
    {
        public formCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            var carro1 = new Carro();
           
            carro1.Marca = txtMarca.Text;
            carro1.Ano = txtAno.Text;
            carro1.Cor = txtCor.Text;

            carro1.ID = Guid.Parse(txtID.Text);

            var carroJson = JsonConvert.SerializeObject(carro1);
            Arquivo.CrieArquivo(carroJson, carro1.ID + ".json");

            txtMarca.Text = "";
            txtAno.Text = "";
            txtCor.Text = "";

            CarregueCarros();

        }

        private Carro LeiaArquivoParaObjeto(string nomeDoArquivo)
        {
            var texto = Arquivo.LerArquivo(nomeDoArquivo);
            var carro1 = JsonConvert.DeserializeObject<Carro>(texto);
            return carro1;

        }

        private void CarregueCarros()
        {
            var listaDeArquivos = Arquivo.ListArquivos();

            var listaDeCarros = new List<Carro>();

            foreach (var arquivo in listaDeArquivos)
            {
                var carro = LeiaArquivoParaObjeto(arquivo);
                listaDeCarros.Add(carro);
            }

            lstCarros.DataSource = listaDeCarros;
        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            
        }

        private void formCadastrar_Load(object sender, EventArgs e)
        {

            CarregueCarros();

        }

        private void lstCarros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var carroSelecionado = (Carro)lstCarros.SelectedItem;
            txtMarca.Text = carroSelecionado.Marca;
            txtAno.Text = carroSelecionado.Ano;
            txtCor.Text = carroSelecionado.Cor;
            txtID.Text = carroSelecionado.ID.ToString();

        }

        private void carroBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCarros.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");

            }
            else
            {
                var carroSelecionado = (Carro)lstCarros.SelectedItem;
                Arquivo.Deletar(carroSelecionado.ID + ".json");
                
                CarregueCarros();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            txtAno.Text = "";
            txtCor.Text = "";
            txtID.Text = Guid.NewGuid().ToString();
        }
    }
}
