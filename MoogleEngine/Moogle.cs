using System.IO;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public static class Moogle
{
    public static SearchResult Query(string query) {
        /** Modifique este método para responder a la búsqueda

        TODO Evaluation+DOC
        TODO Moogle.cs, SearchItem, SearchResult, MoogleServer
        Ordenar resultados de la busqueda
        Buscar frases inexactas y no palabras
        Score menor mientras menos palabras coincidan
        El orden del query NO debe importar, pero si debe, apariciones
        Si aparece misma cantidad de palabras pero uno tiene palabras mas raras, doc tiene score mas alto
        Si tiene mas elementos de la busqueda luego tiene mas score a no ser que sean comunes los elementos
        Eliminar preposiciones y conjunciones
        Documentos de score 0
        Russian and Chinese, else alphabets
        Own Subspace
        Convertir a arquitectura de objetos
        MoogleServer skin
        Comentarios
        Informe PDF-like
        Simbolo ! no debe aparecer la palabra
        Simbolo ^ debe aparecer en cualquier documento
        Simbolo ~ debe hacer que las palabras aparezcan por defecto unidas mientras mas alto mas score
        Simbolo * adquiere prioridad la palabra por cada uno que aparezca
        Simbolo Anyelse
        Enter
        Palabras similares misma raiz devolver score menor
        Palabra similares aun menor score
        Con menos de 5 resultados brindar suggestion de la clase SearchResult con query similar pero existente
        Google-like
        Extensibilidad, Git update (MoogleServer) */

        string[] directoryFiles = Directory.GetFiles("../Content")[1..];
        string[] fileSet = new string[directoryFiles.Length];
        for(int i = 0; i < directoryFiles.Length; i++)
            fileSet[i] = File.ReadAllText(directoryFiles[i]); // TODO CATCH EXCEPTION
        string[][] dataSet = new string[fileSet.Length][];
        for(int i = 0; i < fileSet.Length; i++)
        {
            // Regex.Replace(input, "[^a-zA-Z0-9 ]", "");
            dataSet[i] = fileSet[i].Split();
        }

        SearchItem[] items = new SearchItem[3] {
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
        };

        return new SearchResult(items, query);
    }
}
