// DispositivoDomotico.cs
// Superclase abstracta que agrupa atributos y comportamiento
// común a todos los dispositivos del sistema

using System;

namespace CasaInteligente
{
	public abstract class DispositivoDomotico
	{
		// Atributos protegidos: accesibles por las subclases
		protected string nombre;
		protected string ubicacion;
		protected bool activo;

		public string Nombre
		{
			get { return nombre; }
			set { if (!string.IsNullOrEmpty(value)) nombre = value; }
		}

		public string Ubicacion
		{
			get { return ubicacion; }
			set { if (!string.IsNullOrEmpty(value)) ubicacion = value; }
		}

		public bool Activo { get { return activo; } }

		// Constructor de la clase padre
		protected DispositivoDomotico(string nombre, string ubicacion)
		{
			this.nombre = nombre;
			this.ubicacion = ubicacion;
			this.activo = true;
		}

		// Método abstracto: cada subclase define su propio estado
		public abstract string ObtenerEstado();

		// Método concreto heredable
		public virtual void RealizarAccion()
		{
			Console.WriteLine($"{nombre}: acción por defecto.");
		}
	}
}
