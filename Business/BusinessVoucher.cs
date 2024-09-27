using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessService;

namespace Business
{
    public class BusinessVoucher
    {
        public void AddVaucher()
        {
            DataAccess data = new DataAccess();

            try
            {
                string lastCode = GetLastCode();
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
    }
}
