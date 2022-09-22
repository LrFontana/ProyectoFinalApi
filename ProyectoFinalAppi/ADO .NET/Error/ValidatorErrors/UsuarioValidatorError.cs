namespace ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors
{
    public class UsuarioValidatorError : Exception
    {
        //Constructores
        public UsuarioValidatorError() : base() { }
        public UsuarioValidatorError(string message) : base(message) { }
        public UsuarioValidatorError(string message, Exception innerException) : base(message, innerException) { }
    }
}
