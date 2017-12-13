using System.Configuration;
using Snails.Data;

namespace WebApplication1.CrossDomain
{
    public class Settings : IDbSettings
    {
        public string ConnectionString => ConfigurationManager.AppSettings["Db.ConnectionString"];
    }
}