# Moogle!

![](moogle.png)

> Proyecto de Programación I.
> Facultad de Matemática y Computación - Universidad de La Habana.

Moogle! consiste en un servidor web que sirve una página que permite al usuario realizar una búsqueda de un texto en un conjunto de archivos con extensión `.txt`
Para esto utiliza el motor de búsqueda MoogleEngine que funciona haciendo uso de herramientas como el modelo de espacio vectorial y TF-IDF.

Desarrollado en .NET Core 6.0, ejecutar Moogle es tan sencillo como ejecutar desde un terminal Linux dentro de la carpeta del proyecto:
`make dev`

Moogle! es una aplicación *totalmente original* cuyo propósito es buscar inteligentemente un texto en un conjunto de documentos.

Es una aplicación web, desarrollada con tecnología .NET Core 6.0, específicamente usando Blazor como *framework* web para la interfaz gráfica, y en el lenguaje C#.
La aplicación está dividida en dos componentes fundamentales:

- `MoogleServer` es un servidor web que renderiza la interfaz gráfica y sirve los resultados.
- `MoogleEngine` es una biblioteca de clases donde está... ehem... casi implementada la lógica del algoritmo de búsqueda.

Hasta el momento hemos logrado implementar gran parte de la interfaz gráfica (que es lo fácil), pero nos está causando graves problemas la lógica. Aquí es donde entras tú.

## Tu misión

Tu misión (si decides aceptarla) es ayudarnos a implementar el motor de búsqueda de Moogle! (sí, el nombre es así con ! al final). Para ello, deberás modificar el método `Moogle.Query` que está en la clase `Moogle` del proyecto `MoogleEngine`.

Este método devuelve un objeto de tipo `SearchResult`. Este objeto contiene los resultados de la búsqueda realizada por el usuario, que viene en un parámetro de tipo `string` llamado `query`.

Esto es lo que hay ahora en este método:

```cs
public static class Moogle
{
	public static SearchResult Query(string query) {
		// Modifique este método para responder a la búsqueda

		SearchItem[] items = new SearchItem[3] {
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
		};

		return new SearchResult(items, query);
	}
}
```

# Moogle!
Un motor de búsqueda .NET impulsado por Blazor.

## Instrucciones de instalación.
**\*Nota: para compilar este programa, usted debe tener .NET 6.0 correctamente instalado.**

Para compilar y ejecutar este programa introduzca los siguientes comandos en una sesión de terminal:
1. `git clone https://github.com/nikofabelo/moogle`
2. `cd moogle`
3. `make dev`

Una vez que haga esto usted debe abrir una nueva pestaña en su navegador en la dirección [](http://localhost:5000).

## Capturas de pantalla.
![moogle.png](moogle.png)

## Dicho esto...
```cs
Console.WriteLine("Por qué no lo intentas?");
```