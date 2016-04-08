using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWshRuntimeLibrary;
using System.IO;
using System.Reflection;


namespace CrearAccesoDirecto
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string target1 = "http://www.euareps.com";
            string target2 = "ftp://208.167.238.68";

            WshShell shell = new WshShell();
            IWshShortcut shortcut1;
            IWshShortcut shortcut2;
            try
            {
                /*Creacion del 1er Acceso Directo*/
                shortcut1 = (IWshShortcut)shell.CreateShortcut(desktopFolder + @"\EUAREPS WEB.lnk");
                shortcut1.TargetPath = target1;
                shortcut1.Description = "";
                shortcut1.IconLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\icono1.ico";
                
                /*Creacion del 2do Acceso Directo*/
                shortcut2 = (IWshShortcut)shell.CreateShortcut(desktopFolder + @"\EUAREPS CATALOGO.lnk");
                shortcut2.TargetPath = target2;
                shortcut2.Description = "";
                shortcut2.IconLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\icono2.ico";
                
                /*Creacion de los dos accesos*/
                shortcut1.Save();
                shortcut2.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
