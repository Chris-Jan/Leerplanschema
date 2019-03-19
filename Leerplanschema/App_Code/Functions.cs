using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{
    public const string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
    public const string provider = "System.Data.SqlClient";


    /// <summary>
    /// With this function you allow people to login IF the usename AND password are the same as in the db
    /// </summary>
    /// <param name="naam"></param>
    /// <param name="wachtwoord"></param>
    /// <returns></returns>
    /// 
    public static bool Login(string naam, string wachtwoord)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "SELECT Username, Password FROM Docent WHERE naam = @0 AND wachtwoord = @1";
        var userCheck = db.QuerySingle(query, naam, wachtwoord);
        if (userCheck != null)
        {
            return true;
        }

        return false;
    }
}