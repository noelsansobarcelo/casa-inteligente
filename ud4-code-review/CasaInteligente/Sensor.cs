// Sensor.cs
// Refactorizado para heredar de DispositivoDomotico
// El sensor NO implementa IControlable (no se enciende ni apaga)

namespace CasaInteligente
{
	public class Sensor : DispositivoDomotico
	{
		private double valorActual;
		private string unidad;

		public double ValorActual
		{
			get { return valorActual; }
			set { if (value >= -50 && value <= 150) valorActual = value; }
		}

		public string Unidad { get { return unidad; } }

		public Sensor(string nombre, string ubicacion, double valor, string unidad)
			: base(nombre, ubicacion)
		{
			this.valorActual = valor;
			this.unidad = unidad;
		}

		public double Leer() { return valorActual; }

		public override string ObtenerEstado()
		{
			return $"[Sensor] {nombre} ({ubicacion}): {valorActual} {unidad}";
		}
	}
}
