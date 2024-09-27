using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Model;


namespace tp_web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwap_Click(object sender, EventArgs e)
        {
            try 
            {
                BusinessVoucher business = new BusinessVoucher();
                if (txtVoucherCode.Text != "") //aunque ya se verifica con bootstrap
                {
                    string code = txtVoucherCode.Text;
                    Voucher aux = business.getVoucherByCode(code);
                    if (aux.IDClient==-1)
                    {
                        LabelPrueba.Text = "no existe el codigo de voucher";
                        LabelPrueba.Visible = true;
                    }
                    else
                    {
                        if (aux.DateExchange.Year==1 ) 
                        {
                            LabelPrueba.Text = "OKKK!";
                            LabelPrueba.Visible = true;
                        }
                        else
                        {
                            LabelPrueba.Text = "ya se uso";
                            LabelPrueba.Visible = true;
                        }
                    }
                }
            } catch (Exception ex) 
            {
                throw ex;
            }
            
            

        }
    }
}