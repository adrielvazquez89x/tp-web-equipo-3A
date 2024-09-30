using DataAccessService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessCustomer
    {
        List<Customer> customerList = new List<Customer>();
        DataAccess data = new DataAccess();
        public List<Customer> list()
        {
            try
            {
                data.setQuery("SELECT C.Id, C.Documento, C.Nombre, C.Apellido, C.Email, C.Direccion, C.Ciudad, C.CP FROM Clientes C");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Customer aux = new Customer();
                    aux.Id=(int)data.Reader["Id"];
                    aux.Document = (string)data.Reader["Documento"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.LastName= (string)data.Reader["Apellido"];
                    aux.Email = (string)data.Reader["Email"];
                    aux.Address = (string)data.Reader["Direccion"];
                    aux.City = (string)data.Reader["Ciudad"];
                    aux.CP = (int)data.Reader["CP"];
                }
                return customerList;
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

        public Customer findCustomerByDNI(string dni)
        {
            try
            {
                data.setQuery("SELECT C.Id, C.Documento, C.Nombre, C.Apellido, C.Email, C.Direccion, C.Ciudad, C.CP FROM Clientes C "+
                              "WHERE C.Documento=@dni");
                data.setParameter("@dni", dni);
                data.executeRead();

                Customer aux = new Customer();
                if (data.Reader.Read())
                {
                    aux.Id = (int)data.Reader["Id"];
                    aux.Document = (string)data.Reader["Documento"]; // o directamente le pongo =dni
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.LastName = (string)data.Reader["Apellido"];
                    aux.Email = (string)data.Reader["Email"];
                    aux.Address = (string)data.Reader["Direccion"];
                    aux.City = (string)data.Reader["Ciudad"];
                    aux.CP = (int)data.Reader["CP"];
                }
                else
                {
                    aux.Id = -1;
                }
                return aux;
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
