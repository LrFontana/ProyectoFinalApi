namespace ProyectoFinalAppi.ADO_.NET.Error
{
    public class CrearErrorException : Exception
    {
        //Constructores
        public CrearErrorException() : base() { }
        public CrearErrorException(string message) : base(message) { }
        public CrearErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
