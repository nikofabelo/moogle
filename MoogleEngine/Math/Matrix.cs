namespace MoogleEngine.Math;

public class Matrix
{
	private double[,] items;

	public Matrix(double[,] items)
	{
		this.items = items;
	}

	public double[,] Items { get { return this.items; } }

	public static Matrix operator *(Matrix a, double s)
	{
		double[,] r = new double[a.Items.GetLength(0), a.Items.GetLength(1)];
		for(int i = 0; i < a.Items.GetLength(0); i++)
		{
			for(int j = 0; j < a.Items.GetLength(1); j++)
			{
				r[i,j] = a.Items[i,j]*s;
			}
		}
		return new Matrix(r);
	}

	public static Matrix operator *(Matrix a, Matrix b)
	{
		// x,y = fila, columna = 0,1
		if(a.Items.GetLength(1) != b.Items.GetLength(0))
			throw new ArgumentException("Matrices dimensions are not compatible for multiplication.");
		double[,] m = new double[a.Items.GetLength(0), b.Items.GetLength(1)];
		for(int i = 0; i < a.Items.GetLength(0); i++)
		{
			for(int j = 0; j < b.Items.GetLength(1); j++)
			{
				double sum = 0;
				for(int k = 0; k < a.Items.GetLength(1); k++)
				{
					sum += a.Items[i,k] * b.Items[k,j];
				}
				m[i,j] = sum;
			}
		}
		return new Matrix(m);
	}

	public static Matrix operator +(Matrix a, Matrix b)
	{
		if(a.Items.GetLength(0) != b.Items.GetLength(0)
			|| a.Items.GetLength(1) != b.Items.GetLength(1))
		{
			throw new ArgumentException("Matrices dimensions are not compatible for addition.");
		}
		double[,] c = new double[a.Items.GetLength(0),a.Items.GetLength(0)];
		for(int i = 0; i < a.Items.GetLength(0); i++)
		{
			for(int j = 0; j < a.Items.GetLength(1); j++)
			{
				c[i,j] = a.Items[i,j] + b.Items[i,j];
			}
		}
		return new Matrix(c);
	}

	public static Matrix operator -(Matrix a, Matrix b)
	{
		if(a.Items.GetLength(0) != b.Items.GetLength(0) || a.Items.GetLength(1) != b.Items.GetLength(1))
		{
			throw new ArgumentException("Matrix dimensions are not compatible for substraction.");
		}
		double[,] r = new double[a.Items.GetLength(0), a.Items.GetLength(1)];
		for(int i = 0; i < a.Items.GetLength(0); i++)
		{
			for(int j = 0; j < a.Items.GetLength(1); j++)
			{
				r[i,j] = a.Items[i,j]-b.Items[i,j];
			}
		}
		return new Matrix(r);
	}
}