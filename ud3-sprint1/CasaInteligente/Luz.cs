// Luz.cs
// Clase que modela una luz regulable del sistema domótico

namespace CasaInteligente
{
	public class Luz
	{
		private string nombre;
		private string ubicacion;
		private int intensidad;
		private bool encendida;

		public string Nombre
		{
			get { return nombre; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					nombre = value;
			}
		}

		public string Ubicacion
		{
			get { return ubicacion; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					ubicacion = value;
			}
		}

		public int Intensidad
		{
			get { return intensidad; }
			set
			{
				if (value >= 0 && value <= 100)
					intensidad = value;
			}
		}

		public bool Encendida
		{
			get { return encendida; }
		}

		// Constructor parametrizado
		public Luz(string nombre, string ubicacion, int intensidad)
		{
			this.nombre = nombre;
			this.ubicacion = ubicacion;
			this.intensidad = intensidad;
			this.encendida = false;
		}

		public void Encender()
		{
			encendida = true;
		}

		public void Apagar()
		{
			encendida = false;
		}

		public string ObtenerEstado()
		{
			string estado = encendida ?
				$"ENCENDIDA al {intensidad}%" : "APAGADA";
			return $"[Luz] {nombre} ({ubicacion}): {estado}";
		}
	}
}
