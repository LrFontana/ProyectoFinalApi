using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectoFinalAppi.ADO_.NET.Error;

namespace ProyectoFinalApi.Controllers.ExecptionFilter
{
    public class ExceptionManagerFilter : IExceptionFilter
    {
        //Variables.
        private readonly IWebHostEnvironment _hostingEnviroment;
        private readonly IModelMetadataProvider _modelMetaDataProvider;

        //Constructor.
        public ExceptionManagerFilter(IWebHostEnvironment hostingEnviroment, IModelMetadataProvider modelMetaDataProvider) 
        {
            this._hostingEnviroment = hostingEnviroment;
            this._modelMetaDataProvider = modelMetaDataProvider;
        }

        //Metodo context exception.
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CrearErrorException && context.Exception is EliminarErrorException && context.Exception is GetErrorException && context.Exception is ModificarErrorException )
            {
                context.Result = new JsonResult("ERROR EN LA APLICACION!" + _hostingEnviroment.ApplicationName +
                "LA EXCEPCION DEL TIPO: " + context.Exception.GetType());
            }            
        }
    }
}
