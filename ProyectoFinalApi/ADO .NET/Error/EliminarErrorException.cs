namespace ProyectoFinalAppi.ADO_.NET.Error
{
    public class EliminarErrorException : Exception
    {
        //Constructores
        public EliminarErrorException() : base() { }
        public EliminarErrorException(string message) : base(message) { }
        public EliminarErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
