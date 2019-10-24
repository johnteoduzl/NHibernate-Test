using NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHibernate_Test
{
    class Sources
    {
        public static ISession getSession()
        {
            ISession sess = null;
            try
            {


                var cfg = new Configuration();


                cfg.DataBaseIntegration(x =>
                {
                    x.ConnectionString =  "Server=localhost;Database=nhibernate;User ID=postgres;Password=root;Enlist=true";
                    x.Driver<NpgsqlDriver>();
                    x.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
                });


                cfg.AddAssembly(Assembly.GetExecutingAssembly());
                var sefact = cfg.BuildSessionFactory();

                sess = sefact.OpenSession();




            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            return sess;
        }










        public static void CloseSession(ISession sess)
        {

            if (sess == null)
            {
                // No current session
                return;
            }

            sess.Close();

        }
    }
}
