// Program.cs
// Punto de entrada del sistema domótico (UD 3)

using System;

namespace CasaInteligente
{
	class Program
	{
		static void Main(string[] args)
		{
			// Instanciación de sensores
			Sensor tempSalon = new Sensor("Temperatura", "Salón", 19.5);
			Sensor tempDormitorio = new Sensor("Temperatura", "Dormitorio", 21.0);
			Sensor humedadJardin = new Sensor("Humedad", "Jardín", 65.0);
			Sensor movimiento = new Sensor("Movimiento"); // Constructor sobrecargado

			// Instanciación de luces
			Luz luzSalon = new Luz("Principal", "Salón", 80);
			Luz luzJardin = new Luz("Exterior", "Jardín", 50);

			// Instanciación de termostato con interacción
			Termostato termoSalon = new Termostato("Salón", 22.0);
			termoSalon.Regular(tempSalon); // Consulta el sensor

			// Modificar estados
			luzSalon.Encender();
			luzJardin.Encender();
			tempSalon.ValorActual = 23.0; // El setter valida
			termoSalon.Regular(tempSalon); // Recalcula

			// Mostrar estado de todos los dispositivos
			Console.WriteLine("=== ESTADO DEL SISTEMA ===");
			Console.WriteLine(tempSalon.ObtenerEstado());
			Console.WriteLine(tempDormitorio.ObtenerEstado());
			Console.WriteLine(humedadJardin.ObtenerEstado());
			Console.WriteLine(movimiento.ObtenerEstado());
			Console.WriteLine(luzSalon.ObtenerEstado());
			Console.WriteLine(luzJardin.ObtenerEstado());
			Console.WriteLine(termoSalon.ObtenerEstado());

			// Uso de clase estática
			double fahrenheit = Utilidades.CelsiusAFahrenheit(tempSalon.Leer());
			Console.WriteLine($"Temperatura salón: {fahrenheit:F1} F");
		}
	}
}
