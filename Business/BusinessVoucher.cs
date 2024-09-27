using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessService;
using Model;

namespace Business
{
    public class BusinessVoucher
    {
        public void AddVaucher()
        {
            DataAccess data = new DataAccess();

            try
            {
                string lastCode = GetLastCode(); //y si no hay ninguno?
                string newCode = GenerateCode(lastCode);

                data.setQuery("Insert into Vouchers (CodigoVoucher) Values (@newCode)");
                data.setParameter("@newCode", newCode);

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

        public string GetLastCode()
        {
            DataAccess data = new DataAccess();
            string code = "";
            try
            {
                data.setQuery("Select top 1 CodigoVoucher from Vouchers order by CodigoVoucher desc");
                data.executeRead();

                while (data.Reader.Read())
                {
                    code = (string)data.Reader["CodigoVoucher"];
                }

                return code;
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

        public string GenerateCode(string lastCode)
        {
            string newCode = lastCode.Substring(6);

            int number = int.Parse(newCode) + 1;

            newCode = number < 10 ? "Codigo0" + number : "Codigo" + number;

            return newCode;
        }

        public Voucher getVoucherByCode(string code)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("select CodigoVoucher, IdCliente, FechaCanje, IdArticulo from Vouchers where CodigoVoucher=@code");
                data.setParameter("@code", code);
                data.executeRead();

                SqlDataReader reader = data.Reader;
                Voucher aux = new Voucher();
                if (data.Reader.Read())
                {
                    aux.Code = code;
                   
                    if (reader["FechaCanje"] is DBNull) //caso donde no se canjeo aun
                    {
                        aux.DateExchange = new DateTime(1,1,1);
                    }
                    else
                    {
                        aux.DateExchange = (DateTime)reader["FechaCanje"];
                        aux.IDArticle = (int)reader["IdArticulo"];
                        aux.IDClient = (int)reader["IdCliente"];
                    }
                }
                else 
                {
                    aux.IDClient = -1; //codigo 1 si no existe
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
