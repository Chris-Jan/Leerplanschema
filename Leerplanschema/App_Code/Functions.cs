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

    //public static IEnumerable<dynamic> AddEmptyRow()
    //{
    //    Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
    //    var query = "SELECT "

    //}

    public static void InsertTable(int leerjaar, int periode, string onderdeelnaam, string codeleerjaar, string codeonderwijseenheid, string coordinator, string keuze, string vak, int ec, string uitkerenhoofdvak, string wijzewaardering, string slagingsnormond, string woordbeoordeeldond, string geldigvanaf, string geldigtm, string toetscode, string toetsnaam, string toetswijze, int toetsduur, string waardering, string slagingnsnorm, string woordbeoordeeld, int weging,  string toetsmoment1, string toetsmoment2, string volgordelijkheid, string taal, string eindwerk, string examinator)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query1 = "INSERT INTO Studie_onderdelen (leerjaar, periode, onderdeelnaam,codeonderwijseenheid, codeleerjaar,coordinator, keuze, vak, ec, uitkerenhoofdvak,wijzewaardering, slagingsnormond, woordbeoordeeldond, geldigvanaf, geldigtm) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14)";
        var query2 = "INSERT INTO [Toets] (toetscode, toetsnaam, toetswijze, toetsduur,waardering,slagingsnorm, woordbeoordeeld, weging,toetsmoment1, toetsmoment2, volgordelijkheid, taal, eindwerk, examinator) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13) ";
        db.Execute(query1, leerjaar, periode, onderdeelnaam, codeleerjaar, codeonderwijseenheid, coordinator, keuze, vak, ec, uitkerenhoofdvak, wijzewaardering, slagingsnormond, woordbeoordeeldond, geldigvanaf, geldigtm);
        db.Execute(query2, toetscode, toetsnaam, toetswijze, toetsduur, waardering, slagingnsnorm, woordbeoordeeld, weging, toetsmoment1, toetsmoment2, volgordelijkheid, taal, eindwerk, examinator);
    }
        
    
}