
using System;
using System.Runtime.Serialization;

namespace Proyecto_2
{
	
	public class FechaYaReservadaException : Exception, ISerializable
	{
		public FechaYaReservadaException()
		{
		}

	 	public FechaYaReservadaException(string message) : base(message)
		{
		}

		public FechaYaReservadaException(string message, Exception innerException) : base(message, innerException)
		{
		}
 
		protected FechaYaReservadaException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}