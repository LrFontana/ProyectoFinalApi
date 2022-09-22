namespace ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors
{
    public class ProductoVendidoValidatorError : Exception
    {
        //Constructores
        public ProductoVendidoValidatorError() : base() { }
        public ProductoVendidoValidatorError(string message) : base(message) { }
        public ProductoVendidoValidatorError(string message, Exception innerException) : base(message, innerException) { }
    }
}
