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
        Extensibilidad, Git update (MoogleServer)
        Strings similares:
        +Distancia Levenshtein
        +Similitud cosénica*/

        string[] directoryFiles = Directory.GetFiles("../Content", "*.txt");
        string[] fileSet = new string[directoryFiles.Length];
        for(int i = 0; i < directoryFiles.Length; i++)
            fileSet[i] = File.ReadAllText(directoryFiles[i]).ToLower(); // TODO CATCH EXCEPTION && UTF-8
        string[][] dataSet = new string[fileSet.Length][]; // TODO DATASET TO MATRIX && MAKE DEV
        for(int i = 0; i < fileSet.Length; i++)
            dataSet[i] = Regex.Replace(
                fileSet[i], "[^a-zA-Z0-9\n\t ]", "").Split().Select(w => w.Trim()).ToArray(); // TODO \n\t
        Dictionary<string, float> frequencies = new Dictionary<string, float>();
        foreach(string[] document in dataSet)
            foreach(string word in document)
            {
                if(!frequencies.ContainsKey(word))
                    frequencies.Add(word, 1);
                else
                    frequencies[word] = frequencies[word]++;
            }

        SearchItem[] items = new SearchItem[3] {
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
        };

        return new SearchResult(items, query);
    }
}