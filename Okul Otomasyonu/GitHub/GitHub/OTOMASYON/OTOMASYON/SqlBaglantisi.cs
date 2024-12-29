using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OTOMASYON
{
    internal class SqlBaglantisi
    {
         public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=AKTAS;Initial Catalog=dbo.Otomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
