using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using YashilReport.Core;

namespace YashilReport.Infrastructure.ReportClasses.Adapters
{
  public class MssqlAdapter
  {
    private static SqlConnection _connection;
    private static SqlDataReader _reader;
    private static CommandJson _command;

    private static Result End(Result result)
    {
      try
      {
        _reader?.Close();
        _connection?.Close();

        return result;
      }
      catch (Exception e)
      {
        return result;
      }
    }

    private static Result OnError(string message)
    {
      return End(new Result {Success = false, Notice = message});
    }

    private static Result Connect()
    {
      try
      {
        _connection = new SqlConnection(_command.ConnectionString);
        _connection.Open();
        return OnConnect();
      }
      catch (Exception e)
      {
        return OnError(e.Message);
      }
    }

    private static Result OnConnect()
    {
      if (!String.IsNullOrEmpty(_command.QueryString)) return Query(_command.QueryString);
      else return End(new Result {Success = true});
    }

    private static Result Query(string queryString)
    {
      try
      {
        var sqlCommand = new SqlCommand(queryString, _connection);
        _reader = sqlCommand.ExecuteReader();

        return OnQuery();
      }
      catch (Exception e)
      {
        return OnError(e.Message);
      }
    }

    private static Result OnQuery()
    {
      var columns = new List<string>();
      var rows = new List<string[]>();

      for (var index = 0; index < _reader.FieldCount; index++)
      {
        columns.Add(_reader.GetName(index));
      }

      while (_reader.Read())
      {
        var row = new string[_reader.FieldCount];
        for (var index = 0; index < _reader.FieldCount; index++)
        {
          object value = null;
          if (!_reader.IsDBNull(index)) value = _reader.GetValue(index);
          if (value == null) value = "";
          row[index] = value.ToString();
        }

        rows.Add(row);
      }

      return End(new Result {Success = true, Columns = columns.ToArray(), Rows = rows.ToArray()});
    }

    public Result Process(CommandJson command)
    {
      _command = command;
      return Connect();
    }
  }
}
