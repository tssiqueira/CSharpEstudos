using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoDeArquivo
{
    public class Arquivo
    {

        public static string[] ListArquivos()
        {
            var arquivos = Directory.GetFiles(@"C:\blp\curso C#\diretorio xpto\");
            return arquivos;

        }

        public static void CrieArquivo(string textoDoArquivo, string nomeDoArquivo)
        {
            var arquivo = File.CreateText(@"C:\blp\curso C#\diretorio xpto\" + nomeDoArquivo);
            arquivo.WriteLine(textoDoArquivo);
            arquivo.Close();

        }

        public static string LerArquivo(string nomeDoArquivo)
        {   
            if(File.Exists(nomeDoArquivo))
            {
                var texto = File.ReadAllText(nomeDoArquivo);
                Console.WriteLine("O conteudo do arquivo 'e: " + texto);
                return texto;
            }
            else
            {
                Console.WriteLine("Arquivo nao encontrado");
                return null;
            }

        }

        public static void Deletar(string nomeDoArquivo)
        {
            File.Delete(@"C:\blp\curso C#\diretorio xpto\" + nomeDoArquivo);
        }
    }
}
