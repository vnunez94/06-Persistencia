using System;
using System.Data;
using Microsoft.Data.Sqlite;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //conectar sqlite person.db
            SQLiteConnection conn = new SQLiteConnection("Data Source=person.db;Version=3;");
            conn.Open();
            //crear tabla
            string sql = "create table person (id integer primary key, name varchar(20), age integer)";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
            //insertar datos
            sql = "insert into person (name, age) values ('John Doe', 30)";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
            sql = "insert into person (name, age) values ('Jane Doe', 25)";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
            //leer datos
            sql = "select * from person";
            command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tAge: " + reader["age"]);   
            //cerrar conexion
            conn.Close();

        }
    }
}
 
  
