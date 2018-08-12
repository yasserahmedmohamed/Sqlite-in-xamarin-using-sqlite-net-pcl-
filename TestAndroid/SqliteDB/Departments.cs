using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
namespace AndroidProjectFirst.Classes.SqliteDB
{
    [Table("Departments")]
    class Departments
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
      
        public string FullName { get; set; }

        public Departments() { }
        public Departments(int id) {
            this.Id = id;
        }

    }
}