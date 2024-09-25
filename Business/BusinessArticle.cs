using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;


namespace Business
{
    public class BusinessArticle
    {
        List<Article> articleList = new List<Article>();
        DataAccess data = new DataAccess();
        public List<Article> list()
        {
            try
            {
                data.setQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, I.Id AS IdImagen, M.Descripcion AS Brand, C.Descripcion AS Category" +
                              " FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN (SELECT I.Id, I.ImagenUrl, I.IdArticulo" +
                              " FROM IMAGENES I WHERE I.Id IN (SELECT MIN(Id) FROM IMAGENES GROUP BY IdArticulo)) I ON I.IdArticulo = A.Id");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.Reader["IdMarca"];
                    aux.Brand.Description = (string)data.Reader["Brand"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategoria"];
                    aux.Category.Description = (string)data.Reader["Category"];
                    aux.Price = Math.Round((decimal)data.Reader["Precio"], 2);

                    string urlImage = data.Reader["ImagenUrl"] != DBNull.Value ? (string)data.Reader["ImagenUrl"] : "";
                    int idImage = data.Reader["IdImagen"] != DBNull.Value ? (int)data.Reader["IdImagen"] : 0;

                    aux.UrlImages = new List<Image>
                    {
                        new Image { Id = idImage, IdArticle = aux.Id, UrlImage = urlImage }
                    };

                    articleList.Add(aux);
                }
                return articleList;
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

        public void AddArticle(Article article)
        {
            BusinessImage businessImage = new BusinessImage();
            try
            {
                data.setQuery("insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT INSERTED.Id values(@Code, @Name, @Description, @idBrand , @idCategory, @Price)");
                
                data.setParameter("@Code", article.Code);
                data.setParameter("@Name", article.Name);
                data.setParameter("@Description", article.Description);
                data.setParameter("@idBrand", article.Brand.Id);
                data.setParameter("@idCategory", article.Category.Id);
                data.setParameter("@Price", article.Price);
                //data.executeAction();

                int id = data.getIdEcalar();

                foreach(var img in article.UrlImages)
                {
                    img.IdArticle = id;
                }

                data.closeConnection();

                businessImage.AddImage(article.UrlImages);
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

        public void modifyArticle(Article article)
        {
            BusinessImage businessImage = new BusinessImage();
            try
            {
                data.setQuery("update ARTICULOS set Codigo=@Code, Nombre=@Name, Descripcion=@Description, IdMarca=@idBrand, IdCategoria=@idCategory, Precio=@Price where Id=@Id");
                data.setParameter("@Code", article.Code);
                data.setParameter("@Name", article.Name);
                data.setParameter("@Description", article.Description);
                data.setParameter("@idBrand", article.Brand.Id);
                data.setParameter("@idCategory", article.Category.Id);
                data.setParameter("@Price", article.Price);
                data.setParameter("@Id", article.Id);

                data.executeAction();
                data.closeConnection();
                                

                foreach (var img in article.UrlImages)
                {
                    img.IdArticle = article.Id;
                }

                businessImage.AddImage(article.UrlImages);
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

        public void deleteArticle(int id)
        {
            BusinessImage businessImage = new BusinessImage();
            try
            {
                data.setQuery("delete from ARTICULOS where id = @id");
                data.setParameter("@id",id);
                data.executeAction();

                businessImage.DeleteAllArtImages(id);
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
        public List<Article> filter(string field, string match, string filterText)
        {
            List<Article> filteredArtList = new List<Article>();
            try
            {
               string query = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, I.Id AS IdImagen, M.Descripcion AS Brand, C.Descripcion AS Category" +
                    " FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN (SELECT I.Id, I.ImagenUrl, I.IdArticulo" +
                    " FROM IMAGENES I WHERE I.Id IN (SELECT MIN(Id) FROM IMAGENES GROUP BY IdArticulo)) I ON I.IdArticulo = A.Id WHERE ";
                switch (field)
                {
                    case "Name":
                        switch (match)
                        {
                            case "Starts with":
                                query += "Nombre like '" + filterText + "%'";
                                break;
                            case "End with":
                                query += "Nombre like '%" + filterText + "'";
                                break;
                            default:
                                query += "Nombre like '%" + filterText + "%'";
                                break;
                        }
                        break;
                    case "Brand":
                        switch (match)
                        {
                            case "Starts with":
                                query += "M.Descripcion like '" + filterText + "%'";
                                break;
                            case "End with":
                                query += "M.Descripcion like '%" + filterText + "'";
                                break;
                            default:
                                query += "M.Descripcion like '%" + filterText + "%'";
                                break;
                        }
                        break;
                    case "Price":
                        filterText = filterText.Replace(',', '.');
                        switch (match)
                        {
                            case "Less than":
                                query += "Precio < " + filterText;
                                break;
                            case "Greater than":
                                query += "Precio > " + filterText;
                                break;
                            default:
                                query += "Precio = " + filterText;
                                break;
                        }
                        break;
                    case "Category":
                    default:
                        switch (match)
                        {
                            case "Starts with":
                                query += "C.Descripcion like '" + filterText + "%'";
                                break;
                            case "End with":
                                query += "C.Descripcion like '%" + filterText + "'";
                                break;
                            default:
                                query += "C.Descripcion like '%" + filterText + "%'";
                                break;
                        }
                        break;
                }

                this.data.setQuery(query);
                this.data.executeRead();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.Reader["IdMarca"];
                    aux.Brand.Description = (string)data.Reader["Brand"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategoria"];
                    aux.Category.Description = (string)data.Reader["Category"];
                    aux.Price = Math.Round((decimal)data.Reader["Precio"], 2);

                    string urlImage = data.Reader["ImagenUrl"] != DBNull.Value ? (string)data.Reader["ImagenUrl"] : "";
                    int idImage = data.Reader["IdImagen"] != DBNull.Value ? (int)data.Reader["IdImagen"] : 0;

                    aux.UrlImages = new List<Image> { new Image { Id = idImage, IdArticle = aux.Id, UrlImage = urlImage } };

                    filteredArtList.Add(aux);
                }
                return filteredArtList;
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
    
