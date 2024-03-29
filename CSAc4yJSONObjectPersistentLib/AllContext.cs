using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using d7p4n4Namespace.Final.Class;

namespace d7p4n4Namespace.Context.Class
{
    public class AllContext : DbContext
    {
		private string serverName { get; set; }
        private string baseName { get; set; }
        private string userName { get; set; }
        private string password { get; set; }

        public AllContext(string sName, string bName, string uName, string pwd)
        {
			serverName = sName;
            baseName = bName;
            userName = uName;
            password = pwd;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=" + serverName + ";Database=" + baseName + ";Trusted_Connection=False;User Id=" + userName + ";Password=" + password + ";");
        }

        public DbSet<Ac4yJSONObject> Ac4yJSONObjects { get; set; }


    }
}
