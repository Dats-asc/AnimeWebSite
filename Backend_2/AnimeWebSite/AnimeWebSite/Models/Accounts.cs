using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinqToDB.Mapping;

namespace AnimeWebSite.Models
{
    [LinqToDB.Mapping.Table(Name="Accounts")]
    public class Accounts
    {
        [LinqToDB.Mapping.Column("userid")]
        [LinqToDB.Mapping.Column(IsPrimaryKey = true)]
        public Guid User_id { get; set; }
        [LinqToDB.Mapping.Column("login_")]
        public string Login { get; set; }
        
        [LinqToDB.Mapping.Column("password_")]
        public string Password { get; set; }
        
    }
}