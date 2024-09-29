using Microsoft.Ajax.Utilities;
using Model;
using System;
using System.Collections.Generic;

namespace tp_web
{
    public partial class PasoDos : System.Web.UI.Page
    {
        public List<Article> ListaDeCosas;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaDeCosas = new List<Article>
            {
                new Article { Id = 1, Name = "Cosa 1", Description = "Descripcion de la cosa 1", Price = 100, UrlImages = new List<Model.Image>{ new Model.Image() } },
                new Article { Id = 2, Name = "Cosa 2", Description = "Descripcion de la cosa 2", Price = 200, UrlImages = new List<Model.Image>{ new Model.Image() } },
                new Article { Id = 3, Name = "Cosa 3", Description = "Descripcion de la cosa 3", Price = 300, UrlImages = new List<Model.Image>{ new Model.Image() } }
            };

            ListaDeCosas[0].UrlImages[0].UrlImage = "https://st2.depositphotos.com/7691758/10586/i/450/depositphotos_105869850-stock-photo-ravioli-with-tomato-sauce-and.jpg";
            ListaDeCosas[1].UrlImages[0].UrlImage = "https://media.minutouno.com/p/c5f011d97f01b34e511d0f8e3bb09cf0/adjuntos/150/imagenes/039/409/0039409544/ravioles.jpg";
            ListaDeCosas[2].UrlImages[0].UrlImage = "https://www.cetraro.com.ar/wp-content/uploads/canelones-con-verdura.jpg";
        }
    }
}