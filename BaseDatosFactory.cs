using System;

namespace SUN.FactoryDB
{
    public class BaseDatosFactory
    {
        private static string TipoDB = System.Configuration.ConfigurationManager.AppSettings["TipoDB"];
        public static AdaptadorBD obtenerConector()
        {

            TiposBaseDatos tipo;
            Enum.TryParse<TiposBaseDatos>(TipoDB, out tipo);

            switch (tipo)
            {
                case TiposBaseDatos.SQLServer:
                    return new ConectorSQLServer();
                case TiposBaseDatos.Oracle:
                    return new ConectorOracle();
                default:
                    throw new Exception("No soportado");
            }
        }

        public static AdaptadorBD obtenerConector(string servidor, string baseDatos, string usuario, string password, string esquema)
        {

            TiposBaseDatos tipo;
            Enum.TryParse<TiposBaseDatos>(TipoDB, out tipo);

            switch (tipo)
            {
                case TiposBaseDatos.SQLServer:
                    return new ConectorSQLServer(servidor,baseDatos,usuario,password);
                case TiposBaseDatos.Oracle:
                    return new ConectorOracle(servidor, baseDatos, usuario, password, esquema);
                default:
                    throw new Exception("No soportado");
            }
        }
    }
}
