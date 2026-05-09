// Program.cs
// Punto de entrada del sistema refactorizado (UD 4)

using System;

namespace CasaInteligente
{
	class Program
	{
		static void Main(string[] args)
		{
			// Sensores (no son IControlable)
			var tempSalon = new Sensor("Temp. Salón", "Salón", 19.5, "°C");
			var humJardin = new Sensor("Humedad", "Jardín", 65.0, "%");

			// Dispositivos controlables
			var luzSalon = new Luz("Principal", "Salón", 80);
			var luzJardin = new Luz("Exterior", "Jardín", 50);
			var termoSalon = new Termostato("Calefacción", "Salón", 22.0);
			var persianaSalon = new PersianaMotoizada("Veneciana", "Salón");

			// Panel de control polimórfico
			var panel = new PanelDeControl();
			panel.Registrar(luzSalon);
			panel.Registrar(luzJardin);
			panel.Registrar(termoSalon);
			panel.Registrar(persianaSalon);

			// Encender todo con una sola orden
			Console.WriteLine("=== ENCENDIENDO TODOS LOS DISPOSITIVOS ===");
			panel.EncenderTodos();
			panel.MostrarEstado();

			// Regulación con sensor
			Console.WriteLine("\n=== REGULANDO TERMOSTATO ===");
			termoSalon.Regular(tempSalon);
			Console.WriteLine(termoSalon.ObtenerEstado());

			// Sensores (se muestran aparte)
			Console.WriteLine("\n=== ESTADO DE SENSORES ===");
			Console.WriteLine(tempSalon.ObtenerEstado());
			Console.WriteLine(humJardin.ObtenerEstado());

			// Apagar todo
			Console.WriteLine("\n=== APAGANDO TODO ===");
			panel.ApagarTodos();
			panel.MostrarEstado();
		}
	}
}
