using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OkulOtomasyon
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
           SqlConnection baglan =new SqlConnection(@" Data Source = localhost\SQLEXPRESS; Initial Catalog = dbo.OkulOtomasyon; Integrated Security = True ");
            baglan.Open();
            return baglan;

        }

    }
}
