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

    public static void AddOverzicht(string studieOpleiding, int studieCrohonummer, string studieniveau, string studieVariant, string studieFlexOnd, string studieVraFin, string studieVerTra, string studieSpeTra, string studieVesPla)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "INSERT INTO Studie_overzicht (stuOpleiding, stuCroNr, stuNiveau, stuVariant, stuFlexOnderwijs, stuVraFinanciering, stuVerTraject, stuSpeTraject, vestiging) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
        db.Execute(query, studieOpleiding, studieCrohonummer, studieniveau, studieVariant, studieFlexOnd, studieVraFin, studieVerTra, studieSpeTra, studieVesPla);
    }

    public static IEnumerable<dynamic> AddEmptyRow()
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);


    }
}