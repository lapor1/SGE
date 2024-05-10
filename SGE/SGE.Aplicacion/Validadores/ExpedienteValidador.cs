namespace SGE.Aplicacion;

public class ExpedienteValidador
{
<<<<<<< HEAD
=======

    //las validaciones solo validan no dan los mensajes de error
    //eso lo hace las excepciones
>>>>>>> 9304ad55a65341e975da8f1d57ac68dea62e43af
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        if (expediente.IdUsuarioUM <= 0)
        {
<<<<<<< HEAD
            mensajeError = "El usuario es invalido.";
        }
        else if (string.IsNullOrEmpty(expediente.Caratula))
        {
            mensajeError = "La carátula de un expediente no puede estar vacía.";
        }
        return (mensajeError == "");
    }

}
=======
            //mensajeError = "El usuario es invalido.";

            throw new ValidacionException(mensajeError);       
        }
        else if (string.IsNullOrEmpty(expediente.Caratula))
        {
            //mensajeError = "La carátula de un expediente no puede estar vacía.";
            throw new ValidacionException(mensajeError);
        }
        return (mensajeError == "");
    }
}
>>>>>>> 9304ad55a65341e975da8f1d57ac68dea62e43af
