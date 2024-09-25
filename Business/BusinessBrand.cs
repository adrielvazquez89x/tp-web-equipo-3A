using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Business
{
    public class BusinessBrand
    {
        public List<Brand> list()
        {
            List<Brand> list = new List<Brand>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("select Id,Descripcion from MARCAS");
                data.executeRead();


                while (data.Reader.Read())
                {
                    Brand aux = new Brand();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Description = (string)data.Reader["Descripcion"];

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void add(Brand newBrand)
        {
            DataAccess data = new DataAccess();


            try
            {
                data.setQuery("insert into Marcas (Descripcion) values ('" + newBrand.Description + "')");
                data.executeAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }

        }

        public void delete(int id)
        {
            try
            {
                DataAccess datos = new DataAccess();
                datos.setQuery("delete from Marcas where id = @id");
                datos.setParameter("@id", id);
                datos.executeAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
