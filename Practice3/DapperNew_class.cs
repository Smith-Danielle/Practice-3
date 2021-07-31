using System;
using System.Data;
using Dapper;

namespace Practice3
{
    public class DapperNew_class : Inew_class
    {
        private readonly IDbConnection _connection;

        public DapperNew_class(IDbConnection connection)
        {
            _connection = connection;
        }

        public void InsertExample(string name, DateTime date)
        {
            _connection.Execute("INSERT INTO my_new_schema.new_table (Name, TableDate) VALUES (@name, @date);",
                new { name = name, date = date });
        }
    }
}
