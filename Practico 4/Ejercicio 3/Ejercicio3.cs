using ConsoleApp1.DATs.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Practico_4
{

    // Ejercicio Nº 3: Codifique un programa que utilice el algoritmo de Huffman para comprimir un archivo de caracteres ya generado.Nota: hallar la frecuencia de cada caracter
    internal class Ejercicio3
    {
        
       
        
        string filePath = "C:\\Users\\FRANCISCO\\Documents\\Proj\\LCC Ej\\ConsoleApp1\\Practico 4\\SampleText.txt"; //path del archivo a leer

        public void Start()
        {
            HuffmanCompresser HuffmanGenerator = new HuffmanCompresser();
            string content = string.Empty;

            try
            {
                 content = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return;
            }
            
            string pattern = @"[^a-zAZ0-9]+";
            string cleadedContent = Regex.Replace(content, pattern, string.Empty);
            
            HuffmanGenerator.CrearCodigoHuffman(cleadedContent);

            HuffmanGenerator.MostrarFrecuenciaDeCaracteres();

            HuffmanGenerator.MostrarTabla();

            HuffmanGenerator.Comprimir();


        }

    }
}
