using System;
using System.Collections.Generic;

namespace Proyecto_2
{
    public class EventoBuilder
    {
        private Evento _evento;
        private Salon_de_Fiesta Salon; // Referencia para validar reglas de negocio

        public EventoBuilder(Salon_de_Fiesta salon)
        {
            Salon = salon;
            _evento = new Evento(); // Constructor vacío inicial
        }

        public void IniciarNuevoEvento(Cliente cliente, DateTime fecha)
        {
            // Validación de negocio pura (sin UI)
            if (Salon.ExisteEvento(cliente.DNI, fecha))
                throw new Exception("Fecha ya reservada.");

            _evento.CLIENTEVENTO = cliente;
            _evento.FECHAYHORA = fecha;
        }

        public void AsignarEncargado(Encargado encargado)
        {
            _evento.ENCARGADO = encargado;
        }

        public void AgregarServicio(Servicio servicio, int cantidad)
        {
            // Aquí puedes validar stock interno si quieres
            Servicio_Contratado nuevo = new Servicio_Contratado(servicio, cantidad);
            _evento.AgregarServicoContratado(nuevo);
            
            // Recalcular costo interno
            _evento.COSTO_TOTAL += nuevo.CalcularSubtotal();
        }

        public void ConfirmarSena(float monto)
        {
            if (monto <= 0 || monto > _evento.COSTO_TOTAL)
                throw new Exception("Monto de seña inválido.");
            _evento.SENA = monto;
        }

        public Evento ObtenerEvento()
        {
            // Validaciones finales antes de entregar
            if (_evento.ENCARGADO == null) throw new Exception("Falta encargado.");
            return _evento;
        }
    }
}