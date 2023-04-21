# Check DOCs, Evaluation.
# 1. Collect and preprocess your corpus: Collect the documents that you want to use for your search engine and preprocess them by removing stop words, stemming/lemmatizing the remaining words, and converting them to lowercase.
# 2. Build the document-term matrix: Build a document-term matrix where each row represents a document and each column represents a term in the corpus vocabulary. The values in the matrix can be the raw term frequency or the TF-IDF weight of the corresponding term in the document. 
# 3. Normalize the document vectors: Normalize the document vectors to have unit length. This is done by dividing each document vector by its Euclidean length.
# 4. Process the query: Preprocess the query in the same way as the documents.
# 5. Build the query vector: Build a query vector that represents the query in the same vector space as the document vectors. The query vector can be constructed using the same vocabulary and term weighting scheme as the document-term matrix.
# 6. Compute the cosine similarity: Compute the cosine similarity between the query vector and each document vector in the corpus. The cosine similarity measures the angle between two vectors in a high-dimensional space and ranges from -1 (opposite directions) to 1 (same direction). The document vectors with the highest cosine similarity to the query vector are the most relevant to the query.
# 7. Rank the results: Rank the search results by their cosine similarity scores in descending order. The top-ranked documents are the most relevant to the query.
# 8. Present the results: Present the search results to the user in a user-friendly way, such as by displaying the document titles and snippets or by providing links to the full documents.

# I		Leer documentos y dividir palabras.
# II	Hacer matriz de palabras donde cada fila representa un documento y cada columna un termino del documento, los valores son de TF-IDF.
# III	Normalizar vectores de documentos dividiendo por tamagno Euclideano.
# IV	Repetir III y IV con el query.
# V		Computar similitud cosenica entre el vector del query y cada documento.
# VI	Ordenar de mayor a menor los vectores documento segun la similitud cosenica.

- Buscar tambien palabras inexactas.
- Menor Score cuando existen menos palabras exactas o coincidencias.
- El orden de las palabras del Query no importa pero si las apariciones.
- Si aparece misma cantidad de palabras pero uno tiene palabras mas raras, doc tiene score mas alto.
- Si tiene mas elementos de la busqueda luego tiene mas score a no ser que sean comunes los elementos.
- Eliminar preposiciones y conjunciones.
- Documentos de score 0.
- Russian and Chinese, else alphabets.
- Comentarios.
- Simbolo ! no debe aparecer la palabra.
- Simbolo ^ debe aparecer en cualquier documento.
- Simbolo ~ debe hacer que las palabras aparezcan por defecto unidas mientras mas alto mas score.
- Simbolo * adquiere prioridad la palabra por cada uno que aparezca.
- Simbolos >< palabra1 aparece +/- que palabra2.
- Palabras similares misma raiz devolver score menor.
- Palabra similares aun menor score.
- Con menos de 5 resultados brindar suggestion de la clase SearchResult con query similar pero existente.
- Strings similares: Distancia Levenshtein, Similitud cosénica.
# Informe escrito.
# Exposicion: se presentan mejoras.
- 1.a) Representación implícita o explícita de los documentos y consultas como conjuntos de palabras que permita identificar eficientemente si un término aparece en un documento (_eficientemente_ significa con un costo sublineal).
- 1.b) Implementación de un mecanismo para computar un valor de ranking dados un documento y una consulta.
- 1.c) Diseño de una función de ranking que represente alguna noción de relevancia sensata (e.j., TF-IDF).
- 1.d) Implementación de un conjunto de operadores adicionales que modifican el criterio de relevancia.
- 1.e) Implementación de un mecanismo para computar un fragmento (_snippet_) de cada documento que corresponda con algún criterio de relevancia sensato.
- 1.f) Implementación de un mecanismo para computar sugerencias ante términos para los que no se obtienen resultados.
Además de las funcionalidades, se tendrá en cuenta la mantenibilidad y legibilidad del código:
- 1.g) Organización del código de forma modular, con clases y métodos independientes para las funcionalidades principales.
- 1.h) Documentación (comentarios) a nivel de código para las partes más complejas del proyecto.
## 2. Informe escrito
El informe escrito debe describir la solución presentada en suficiente detalle que permita evaluar su correctitud. Por este motivo no debe solamente mencionar las funcionalidades implementadas, sino además explicar en detalle la representación de los documentos y consultas así como cada algoritmo implementado que no sea trivial (e.j., la búsqueda secuencial en un *array* es trivial).
Criterios a tener en cuenta sobre el contenido:
- 2.a) Descripción de la arquitectura básica del proyecto y el flujo de los datos durante la ejecución de la búsqueda.
- 2.b) Descripción de las funcionalidades implementadas en términos de su uso, e.j., los operadores existentes.
- 2.c) Descripción de la modelación empleada para representar los documentos y consultas, y para computar una función de ranking.
- 2.d) Descripción del funcionamiento de los algoritmos no triviales implementados.
Además del contenido, se tendrán en cuenta criterios sobre la redacción del documento.
- 2.e) Correctitud ortográfica y gramatical.
- 2.f) Claridad y legibilidad en las explicaciones.
## 3. Exposición oral
- 3.a) Presentación de las ideas más importantes del proyecto: la arquitectura del sistema, la representación de los documentos y consultas, y el criterio de ranking.
- 3.b) Presentación de los detalles de implementación más notables del proyecto
## 4. Extras
- 4.a) Implementación eficiente del cómputo de ranking a partir de operaciones matriciales.
- 4.b) Implementación de operadores adicionales no descritos en la orientación.
- 4.c) Implementación de transformaciones sintácticas o morfológicas (e.j., _stemming_ o lematización).
- 4.d) Mecanismos de caché para evitar cargar los documentos en cada ejecución.
<!-- Index.razor
- Add cross SVG:
<svg xmlns="http://www.w3.org/2000/svg" fill="lightgray" viewBox="0 0 24 24" width="24" height="24">
	<path d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z"/>
</svg>
- Enter is click. -->