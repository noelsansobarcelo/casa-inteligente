// Sensor.cs
// Clase que modela un sensor genérico del sistema domótico

namespace CasaInteligente
{
	public class Sensor
	{
		// Atributos privados (encapsulación)
		private string tipo;
		private string ubicacion;
		private double valorActual;
		private bool activo;

		// Propiedades públicas con validación
		public string Tipo
		{
			get { return tipo; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					tipo = value;
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

		public double ValorActual
		{
			get { return valorActual; }
			set
			{
				if (value >= -50 && value <= 150)
					valorActual = value;
			}
		}

		public bool Activo
		{
			get { return activo; }
			set { activo = value; }
		}

		// Constructor parametrizado
		public Sensor(string tipo, string ubicacion, double valorInicial)
		{
			this.tipo = tipo;
			this.ubicacion = ubicacion;
			this.valorActual = valorInicial;
			this.activo = true;
		}

		// Constructor sobrecargado (sin ubicación)
		public Sensor(string tipo) : this(tipo, "Sin asignar", 0.0)
		{
		}

		// Métodos de instancia
		public double Leer()
		{
			return valorActual;
		}

		public void Activar()
		{
			activo = true;
		}

		public void Desactivar()
		{
			activo = false;
		}

		public string ObtenerEstado()
		{
			string estado = activo ? "ACTIVO" : "INACTIVO";
			return $"[{tipo}] {ubicacion}: {valorActual} ({estado})";
		}
	}
}
