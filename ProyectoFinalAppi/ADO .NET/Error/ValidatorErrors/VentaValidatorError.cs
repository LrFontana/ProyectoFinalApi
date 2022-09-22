namespace ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors
{
    public class VentaValidatorError : Exception
    {
        //Constructores
        public VentaValidatorError() : base() { }
        public VentaValidatorError(string message) : base(message) { }
        public VentaValidatorError(string message, Exception innerException) : base(message, innerException) { }
    }
}
