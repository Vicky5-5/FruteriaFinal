using Fruteria_vgarcia.ViewModels;
using LogicaBiblioteca.Managers;
using LogicaBiblioteca.Modelos;
using System;
using System.Web;
using System.Web.UI;

public sealed class LoginManager
{
    private static LoginManager instance = null;
    private string currentUser;

    LoginManager()
    {
        // Constructor privado para evitar instanciación externa
    }

    public static LoginManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginManager();
            }
            return instance;
        }
    }

    public bool Login(string email, string password, UsuariosViewModel entrar)
    {
        var info = UsuariosViewModel.GetUsuario(entrar.idUsuario);
        DateTime dateTime = DateTime.Now;
        bool bloqueo = false;
        var login = UserManager.Login(email,password);
        var hash = UserManager.HashPassword(password);
        int cuenta = 0;
        int contador = 0;
        if (hash == login.Password && email == login.Email && login.Estado == true && /*HttpContext.Current.Session["Usuario"] != null &&*/ bloqueo == false)
        {
            currentUser = info.Nombre;
            HttpContext.Current.Session["Bienvenida"] = "Bienvenido/a: " + info.Nombre;
            return true;
        }
        else if (hash != login.Password || login.Email != email)
        {
            bloqueo = false;
            cuenta = contador++;
            HttpContext.Current.Session["Incorrecto"] = "La contraseña o el email están incorrectos. Inténtalo de nuevo";

            throw new System.Exception("La contraseña o el email están incorrectos. Inténtalo de nuevo");
        }
        if (cuenta > 3)
        {
            HttpContext.Current.Session["Mensaje"] = "Se ha superado el número de intentos (3). Inténtelo de nuevo en 10 minutos";
            HttpContext.Current.Session["Bloqueado"] = dateTime.AddMinutes(10);
            bloqueo = true;
            
        }
        return false;
    }

    public string GetCurrentUser()
    {
        return currentUser;
    }
}
