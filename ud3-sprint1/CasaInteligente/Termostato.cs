// Termostato.cs
// Clase que modela un termostato con regulación automática

namespace CasaInteligente
{
	public class Termostato
	{
		private string ubicacion;
		private double temperaturaObjetivo;
		private bool calefaccionActiva;

		public string Ubicacion
		{
			get { return ubicacion; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					ubicacion = value;
			}
		}

		public double TemperaturaObjetivo
		{
			get { return temperaturaObjetivo; }
			set
			{
				// Validación: rango razonable de temperatura
				if (value >= 15.0 && value <= 30.0)
					temperaturaObjetivo = value;
			}
		}

		public bool CalefaccionActiva
		{
			get { return calefaccionActiva; }
		}

		public Termostato(string ubicacion, double tempObjetivo)
		{
			this.ubicacion = ubicacion;
			this.temperaturaObjetivo = tempObjetivo;
			this.calefaccionActiva = false;
		}

		// Método que interactúa con un objeto Sensor
		public void Regular(Sensor sensorTemperatura)
		{
			double actual = sensorTemperatura.Leer();
			if (actual < temperaturaObjetivo)
			{
				calefaccionActiva = true;
			}
			else
			{
				calefaccionActiva = false;
			}
		}

		public string ObtenerEstado()
		{
			string modo = calefaccionActiva ? "CALENTANDO" : "EN ESPERA";
			return $"[Termostato] {ubicacion}: Objetivo {temperaturaObjetivo} C ({modo})";
		}
	}
}
