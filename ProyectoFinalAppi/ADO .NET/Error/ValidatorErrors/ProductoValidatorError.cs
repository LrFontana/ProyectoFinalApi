namespace ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors
{
    public class ProductoValidatorError : Exception
    {
        //Constructores
        public ProductoValidatorError() : base() { }
        public ProductoValidatorError(string message) : base(message) { }
        public ProductoValidatorError(string message, Exception innerException) : base(message, innerException) { }
    }
}
