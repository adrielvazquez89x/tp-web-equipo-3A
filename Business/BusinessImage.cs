using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessService;

namespace Business
{
    public class BusinessImage
    {
        public List<Image> list(int id = 0)
        {
            List<Image> list = new List<Image>();
            DataAccess data = new DataAccess();

            try
            {
                string query = "SELECT Id, IdArticulo, ImagenUrl from IMAGENES";
                data.setQuery(query);

                if (id != 0)
                {
                    data.setQuery(query += " WHERE IdArticulo = @IdArticulo");
                    data.setParameter("@IdArticulo", id);
                }

                data.executeRead();

                while (data.Reader.Read())
                {
                    Image aux = new Image();
                    aux.Id = (int)data.Reader["Id"];
                    aux.IdArticle = (int)data.Reader["IdArticulo"];
                    aux.UrlImage = (string)data.Reader["ImagenUrl"];

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

        public void AddImage(List<Image> images)
        {
            DataAccess data = new DataAccess();

            try
            {
                foreach (var img in images)
                {
                    if (img.Id == 0)
                    {
                        data.setQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                        data.setParameter("@IdArticulo", img.IdArticle);
                        data.setParameter("@ImagenUrl", img.UrlImage);
                        data.executeAction();

                        data.clearParams();
                        data.closeConnection();
                    }

                }

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

        public void DeleteImage(int id)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("DELETE FROM IMAGENES WHERE Id = @Id");
                data.setParameter("@Id", id);
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

        public void DeleteAllArtImages(int artId)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("DELETE FROM IMAGENES WHERE IdArticulo = @artId");
                data.setParameter("@artId", artId);
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
    }
}