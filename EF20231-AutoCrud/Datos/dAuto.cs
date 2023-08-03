using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class dAuto
    {
        //el entity crea previamente los get & set de la clase Auto
        public string RegistrarAuto(Auto objauto)
        {
            using (var contexto = new dbtallerEntities())
            {

                // Verificar si la placa ya existe en la base de datos
                bool placaExiste = contexto.Autos.Any(a => a.placa == objauto.placa);

                //objauto.placa != null
                if (!placaExiste)
                {
                    contexto.Autos.Add(objauto);
                    contexto.SaveChanges();
                    return "Se registro exitosamente un Auto";
                }
                else
                {
                    return "Placa ya existe";
                }
            }
        }

        public List<Auto> ListarAuto()
        {
            var contexto = new dbtallerEntities();
            return contexto.Autos.ToList<Auto>();
        }

        public string ModificarAuto(Auto objauto)
        {
            using (var contexto = new dbtallerEntities())
            {
                var modificado = contexto.Autos.Find(objauto.placa);
                
                //
                modificado.placa = objauto.placa;
                modificado.marca = objauto.marca;
                modificado.modelo= objauto.modelo;
                modificado.color= objauto.color;
                modificado.año = objauto.año;
                modificado.combustible = objauto.combustible;
                contexto.SaveChanges();
                return "Se modifico el Auto";
            }
        }

        public string EliminarAuto(string placa)
        {
            using (var contexto = new dbtallerEntities())
            {
                contexto.Autos.Remove(contexto.Autos.Find(placa));
                contexto.SaveChanges();
                return "Se elimino el auto";
            }
        }


    }

}
