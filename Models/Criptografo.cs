using System;
using System.Security.Cryptography;
using System.Text;


namespace Biblioteca.Models
{
    public class Criptografo
    {
        
            public static string TextoCriptografado( string TextoClaro){

                    MD5 MD5Shasher = MD5.Create();

                    byte[] By = Encoding.Default.GetBytes( TextoClaro);
                    byte[] bytesCriptofrafado = MD5Shasher.ComputeHash(By);

                    StringBuilder SB = new StringBuilder();

                    foreach( byte b in bytesCriptofrafado){

                         string DebugB = b.ToString( "x2" );
                         SB.Append( DebugB);


                    }

                    return SB.ToString();

            }




    }
}