// PanelDeControl.cs
// Demuestra polimorfismo con IControlable

using System;
using System.Collections.Generic;

namespace CasaInteligente
{
	public class PanelDeControl
	{
		private List<IControlable> dispositivos;

		public PanelDeControl()
		{
			dispositivos = new List<IControlable>();
		}

		public void Registrar(IControlable dispositivo)
		{
			dispositivos.Add(dispositivo);
		}

		// Polimorfismo: una sola instrucción para todos
		public void EncenderTodos()
		{
			foreach (var d in dispositivos)
			{
				d.Encender();
			}
		}

		public void ApagarTodos()
		{
			foreach (var d in dispositivos)
			{
				d.Apagar();
			}
		}

		public void MostrarEstado()
		{
			foreach (var d in dispositivos)
			{
				// Upcasting: IControlable a DispositivoDomotico
				if (d is DispositivoDomotico dd)
					Console.WriteLine(dd.ObtenerEstado());
			}
		}
	}
}
