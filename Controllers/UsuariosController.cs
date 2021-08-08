using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
   
    {

             public IActionResult ListaDeUsuario(){

                 Autenticacao.CheckLogin(this);
                 Autenticacao.verificaSeUsuarioEAdmin(this);

                 return View ( new UsuarioService().Listar() );
            }

     
            public IActionResult EditarUsuario( int id){

                Usuario u = new UsuarioService().Listar( id);

                return View( u ) ;

            }
        
            [HttpPost]

            public IActionResult EditarUsuario( Usuario usuarioEditado){

                 UsuarioService us = new UsuarioService();

                 usuarioEditado.Senha = Criptografo.TextoCriptografado( usuarioEditado.Senha);
                 
                 us.editarUsuario(  usuarioEditado );


                 return RedirectToAction ("ListaDeUsuario", "Usuarios");

            }


           public IActionResult RegistrarUsuario(){

               Autenticacao.CheckLogin(this);
               Autenticacao.verificaSeUsuarioEAdmin(this);
               return View();


           }

           [HttpPost]
           public IActionResult RegistrarUsuario( Usuario novoUser){

               Autenticacao.CheckLogin(this);
               Autenticacao.verificaSeUsuarioEAdmin(this);
  
               novoUser.Senha = Criptografo.TextoCriptografado( novoUser.Senha);

               UsuarioService us = new UsuarioService();
               us.IncluirUsuario( novoUser);


              return RedirectToAction ("CadastroRealizado", "Usuarios");
           }


           public IActionResult ExcluirUsuario( int id){

               return View( new UsuarioService().Listar(id));

           }

           [HttpPost]
           public IActionResult ExcluirUsuario(string decisao, int id ){


                if( decisao == "EXCLUIR"){

                     ViewData[ "mensagem"] = "Exclusao do usuario: " + new UsuarioService().Listar(id).Nome + " REALIZADA";
                     new UsuarioService().excluirUsuario(id);

//                     return  View( "ListaDeUsuario" + new UsuarioService().Listar());
           
                }else{

                    ViewData[ "mensagem"] = "Exclusao cancelada";
//                    return  View( "ListaDeUsuario" + new UsuarioService().Listar());
                }

//                return  View( "/Usuarios/ListaDeUsuario" + new UsuarioService().Listar());
                return RedirectToAction ("ListaDeUsuario", "Usuarios");


           } 

            public IActionResult CadastroRealizado(){

                  Autenticacao.CheckLogin(this);
                  Autenticacao.verificaSeUsuarioEAdmin(this);

                  return View();
            }


           public IActionResult NeedAdmin(){
                  Autenticacao.CheckLogin(this);
                  return View();

           }
 

           public IActionResult Sair(){

                HttpContext.Session.Clear();
                return RedirectToAction ("Index", "Home");


           }

 
    }
}