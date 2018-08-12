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
// SQL class
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
using System.IO;
using AndroidProjectFirst.Classes.SqliteDB;

namespace AndroidProjectFirst.Classes
{
    class SqlDB
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "department.db3");
        public SqlDB() {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Departments>();

            }


        }

        public void insert(string fullname) {

            var db = new SQLiteConnection(dbPath);
            Departments departments = new Departments();
            departments.FullName = fullname;
            db.Insert(departments);
        }

        public void update(Departments departments) {
            var db = new SQLiteConnection(dbPath);
           
          
            db.Update(departments);
        }

        public void delete(int id) {
            (new SQLiteConnection(dbPath)).Delete(new Departments(id));
        }

        public List<string> Getdepart(string fullname) {

            List<string> alldepartList = new List<string>();

            var db = new SQLiteConnection(dbPath);

            var selectquery = db.Query<Departments>("select * from Departments where fullname = ?", fullname);


            foreach (var depart in selectquery) {
                alldepartList.Add(depart.Id + "- " + depart.FullName);

            }

            return alldepartList;
        }

        public List<string> getAlldeparts() {
            List<string> alldepartList = new List<string>();

            var db = new SQLiteConnection(dbPath);

            var selectquery = db.Query<Departments>("select * from Departments ");


            foreach (var depart in selectquery)
            {
                alldepartList.Add(depart.Id + "- " + depart.FullName);

            }

            return alldepartList;


        }

    }
}