using AnimeWebSite.Models;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace AnimeWebSite
{
    public class DBConnection
    {
        private DataConnection Connection { get; }

        public DBConnection(string GetConnection)
        {
            var options = new LinqToDbConnectionOptionsBuilder();
            options.UseSqlServer(GetConnection);
            Connection = new DataConnection(options.Build());
        }

        public ITable<Accounts> User => Connection.GetTable<Accounts>();

        public void AccountCreate(Accounts user)
        {
            Connection.Insert(user);
        }
    }
}