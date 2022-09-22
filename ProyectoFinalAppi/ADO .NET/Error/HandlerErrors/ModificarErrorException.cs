namespace ProyectoFinalAppi.ADO_.NET.Error
{
    public class ModificarErrorException : Exception
    {
        //Constructores
        public ModificarErrorException() : base() { }
        public ModificarErrorException(string message) : base(message) { }
        public ModificarErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
