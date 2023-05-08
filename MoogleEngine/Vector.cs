namespace MoogleEngine;

// Define un Vector de TF*IDF para los documentoss
public class Vector
{
	private double norm = 0;
	private double[] items;

	/**
		Define el tamagno del arreglo de componentes
		del Vector igual al tamagno del banco de palabras
		Para cada palabra del banco de palabras la agnade
		al arreglo de componentes del Vector mediante
		la multiplicacion de su TF en el documento del vector
		y su IDF que viene del objeto del Corpus
		Seguidamente calcula la magnitud del vector para su
		posterior uso en el calculo de la similitud cosenica
	*/
	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.items = new double[idf.Count];
		int i = 0;
		foreach(string key in idf.Keys)
		{
			/**
				El arreglo de componentes en el indice actual se hace
				igual al TF de la palabra mutiplicado por su IDF
				tf.TryGetValue intenta obtener el valor de TF de la
				palabra, en caso de que el documento no la contenga
				en su conjunto de palabras devuelve TF = 0
			*/
			this.items[i] = (tf.TryGetValue(
					key, out double tfValue) ? tfValue : 0)*idf[key];
			i++;
		}
		CalculateNorm();
	}

	/**
		Calcula la magnitud del Vector que es igual a
		la raiz cuadrada de la sumatoria de las componentes
		del Vector elevadas a la potencia de dos
	*/
	private void CalculateNorm()
	{
		for(int i = 0; i < this.items.Length; i++)
		{
			this.norm += Math.Pow(this.items[i], 2);
		}
		this.norm = Math.Sqrt(this.norm);
	}

	public double Norm { get { return this.norm; } }

	public double this[int i] { get { return this.items[i]; } }

	public int Length { get { return this.items.Length; } }
}