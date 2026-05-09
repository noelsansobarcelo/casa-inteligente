// PersianaMotoizada.cs
// Nuevo dispositivo añadido sin modificar código existente
// Demuestra el principio Open/Closed

namespace CasaInteligente
{
	public class PersianaMotoizada : DispositivoDomotico, IControlable
	{
		private int porcentajeApertura; // 0 = cerrada, 100 = abierta
		private bool motorActivo;

		public int PorcentajeApertura
		{
			get { return porcentajeApertura; }
			set { if (value >= 0 && value <= 100) porcentajeApertura = value; }
		}

		public PersianaMotoizada(string nombre, string ubicacion)
			: base(nombre, ubicacion)
		{
			this.porcentajeApertura = 0;
			this.motorActivo = false;
		}

		public void Encender() { motorActivo = true; porcentajeApertura = 100; }
		public void Apagar() { motorActivo = false; porcentajeApertura = 0; }
		public bool EstaEncendido() { return motorActivo; }

		public override string ObtenerEstado()
		{
			return $"[Persiana] {nombre} ({ubicacion}): {porcentajeApertura}% abierta";
		}
	}
}
