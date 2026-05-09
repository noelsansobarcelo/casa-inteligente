// Utilidades.cs
// Clase estática con métodos de conversión de unidades

namespace CasaInteligente
{
	public static class Utilidades
	{
		public static double CelsiusAFahrenheit(double celsius)
		{
			return celsius * 9.0 / 5.0 + 32.0;
		}

		public static double FahrenheitACelsius(double fahrenheit)
		{
			return (fahrenheit - 32.0) * 5.0 / 9.0;
		}

		public static int LuxAPorcentaje(double lux)
		{
			// Escala simplificada: 0 lux = 0%, 1000 lux = 100%
			int porcentaje = (int)(lux / 10.0);
			if (porcentaje > 100) porcentaje = 100;
			if (porcentaje < 0) porcentaje = 0;
			return porcentaje;
		}
	}
}
