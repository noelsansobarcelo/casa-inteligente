// Termostato.cs
// Hereda de DispositivoDomotico e implementa IControlable

namespace CasaInteligente
{
	public class Termostato : DispositivoDomotico, IControlable
	{
		private double temperaturaObjetivo;
		private bool calefaccionActiva;

		public double TemperaturaObjetivo
		{
			get { return temperaturaObjetivo; }
			set { if (value >= 15 && value <= 30) temperaturaObjetivo = value; }
		}

		public Termostato(string nombre, string ubicacion, double tempObj)
			: base(nombre, ubicacion)
		{
			this.temperaturaObjetivo = tempObj;
			this.calefaccionActiva = false;
		}

		public void Encender() { calefaccionActiva = true; }
		public void Apagar() { calefaccionActiva = false; }
		public bool EstaEncendido() { return calefaccionActiva; }

		public void Regular(Sensor sensor)
		{
			calefaccionActiva = sensor.Leer() < temperaturaObjetivo;
		}

		public override string ObtenerEstado()
		{
			string modo = calefaccionActiva ? "CALENTANDO" : "EN ESPERA";
			return $"[Termostato] {nombre} ({ubicacion}): Obj. {temperaturaObjetivo} C ({modo})";
		}
	}
}
