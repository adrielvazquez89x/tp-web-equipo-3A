﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using DataAccessService;
using Model;

namespace Business
{
    public class BusinessVoucher
    {
        public string AddVaucher()
        {
            DataAccess data = new DataAccess();
            string newCode = string.Empty;

            try
            {
                string lastCode = GetLastCode(); //y si no hay ninguno?
                newCode = GenerateCode(lastCode);

                data.setQuery("Insert into Vouchers (CodigoVoucher) Values (@newCode)");
                data.setParameter("@newCode", newCode);

                data.executeAction();

                return newCode;
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
                aux.Code = code;
                if (data.Reader.Read())
                {
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
                data.closeConnection();
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

        public void ModifyVoucher(string code, int idCustomer, DateTime date, int idArt)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.clearParams();
                data.setQuery("update Vouchers set IdCliente=@idCustomer, FechaCanje=@date, IdArticulo=@idArt where CodigoVoucher=@code");
                data.setParameter("@idCustomer", idCustomer);
                data.setParameter("@date", date);
                data.setParameter("@idArt", idArt);
                data.setParameter("@code", code);

                data.executeAction();
               // data.closeConnection();
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
