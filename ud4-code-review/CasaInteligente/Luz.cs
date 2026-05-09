// Luz.cs
// Hereda de DispositivoDomotico e implementa IControlable

namespace CasaInteligente
{
	public class Luz : DispositivoDomotico, IControlable
	{
		private int intensidad;
		private bool encendida;

		public int Intensidad
		{
			get { return intensidad; }
			set { if (value >= 0 && value <= 100) intensidad = value; }
		}

		public Luz(string nombre, string ubicacion, int intensidad)
			: base(nombre, ubicacion)
		{
			this.intensidad = intensidad;
			this.encendida = false;
		}

		// Implementación de IControlable
		public void Encender() { encendida = true; }
		public void Apagar() { encendida = false; intensidad = 0; }
		public bool EstaEncendido() { return encendida; }

		public override string ObtenerEstado()
		{
			string estado = encendida ?
				$"ENCENDIDA al {intensidad}%" : "APAGADA";
			return $"[Luz] {nombre} ({ubicacion}): {estado}";
		}
	}
}
