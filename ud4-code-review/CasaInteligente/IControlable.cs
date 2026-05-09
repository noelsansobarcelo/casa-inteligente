// IControlable.cs
// Contrato que deben cumplir los dispositivos que pueden
// encenderse y apagarse desde el panel central

namespace CasaInteligente
{
	public interface IControlable
	{
		void Encender();
		void Apagar();
		bool EstaEncendido();
	}
}
