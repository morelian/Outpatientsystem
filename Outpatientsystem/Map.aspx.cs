using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using NpgsqlTypes;
using Outpatientsystem.DataAccessLayer;


namespace Outpatientsystem
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PgsqlHelper pgsqlHelper = new PgsqlHelper();
            DataTable table = pgsqlHelper.Fill();
            dgv_concent.DataSource= table;
            dgv_concent.DataBind();

        }
    }
}