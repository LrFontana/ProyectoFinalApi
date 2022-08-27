namespace ProyectoFinalAppi.ADO_.NET.Error
{
    public class GetErrorException : Exception
    { 
        //Constructores
        public GetErrorException() : base() { }
        public GetErrorException(string message) : base(message) { }
        public GetErrorException (string message, Exception innerException) : base(message, innerException) { }

    }
}
