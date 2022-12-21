﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace GenPFX.clases
{
    public class PFX
    {
        string cer = "";
        string key = "";
        string clavePrivada = "";
        string clavePFX = "";
        string ArchivoPFX = "";
        string ArchivoKPEM = "";
        string ArchivoCPEM = "";

        public string error = "";
        public string mensajeExito = "";
 
        ///<summary>
        ///
        /// </summary>
 
        /// <param name="cer_">archivo cer a utilizar</param>
        /// <param name="key_">archivo key a utilizar</param>
        /// <param name="clavePrivada_">clave para el archivo pfx</param>
        /// <param name="archivoPfx_">ruta del archivo pfx</param>
        /// <param name="path">ruta para archivos temporales PEM</param>
        public PFX(string cer_, string key_, string clavePrivada_, string archivoPfx_, string pathTemp, string clavePFX_)
        {
            cer = cer_;
            key = key_;
            clavePrivada = clavePrivada_;
            clavePFX = clavePFX_;
            ArchivoKPEM = pathTemp + "k.pem";
            ArchivoCPEM = pathTemp + "c.pem";
            ArchivoPFX = archivoPfx_;
        }

        public bool creaPFX()
        {
            bool exito = false;

            //validaciones
            if (!File.Exists(cer))
            {
                error = "No existe el archivo cer en el sistema";
                return false;
            }
            if (!File.Exists(key))
            {
                error = "No existe el archivo key en el sistema";
                return false;
            }
            if (clavePrivada.Trim().Equals(""))
            {
                error = "No existe una clave privada aun en el sistema";
                return false;
            }

            //creamos objetos Process
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
            System.Diagnostics.Process proc3 = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc2.EnableRaisingEvents = false;
            proc3.EnableRaisingEvents = false;

            try
            {
                //openssl x509 -inform DER -in certificado.cer -out certificado.pem
                proc.StartInfo.FileName = "openssl";
                proc.StartInfo.Arguments = "x509 -inform DER -in \"" + cer + "\" -out \"" + ArchivoCPEM + "\"";
                proc.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el archivo pem; " + ex.Message);
            }

            try
            { 
                //openssl pkcs8 -inform DER -in llave.key -passin pass:a0123456789 -out llave.pem
                proc2.StartInfo.FileName = "openssl";
                proc2.StartInfo.Arguments = "pkcs8 -inform DER -in \"" + key + "\" -passin pass:" + clavePrivada + " -out \"" + ArchivoKPEM + "\"";
                proc2.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
                proc2.Start();
                proc2.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el archivo pem; " + ex.Message);
            }

            try
            {
                //openssl pkcs12 -export -out archivopfx.pfx -inkey llave.pem -in certificado.pem -passout pass:clavedesalida
                proc3.StartInfo.FileName = "openssl";
                proc3.StartInfo.Arguments = "pkcs12 -export -out \"" + ArchivoPFX + "\" -inkey \"" + ArchivoKPEM + "\" -in \"" + ArchivoCPEM + "\" -passout pass:" + clavePFX;
                proc3.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
                proc3.Start();
                proc3.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el archivo pem; " + ex.Message);
            }

            proc.Dispose();
            proc2.Dispose();
            proc3.Dispose();

            //enviamos mensaje exitoso
            if (System.IO.File.Exists(ArchivoPFX))
                mensajeExito = "Se ha creado el archivo PFX ";
            else
            {
                error = "Error al crear el archivo PFX, puede ser que el cer o el key no sean archivos con formato correcto";
                return false;
            }

            //eliminamos los archivos pem
            if (System.IO.File.Exists(ArchivoCPEM)) System.IO.File.Delete(ArchivoCPEM);
            if (System.IO.File.Exists(ArchivoKPEM)) System.IO.File.Delete(ArchivoKPEM);

            exito = true;

            return exito;
        }
    }
}
