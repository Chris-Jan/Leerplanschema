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
        var query = "SELECT naam, wachtwoord FROM Docent WHERE naam = @0 AND wachtwoord = @1";
        var userCheck = db.QuerySingle(query, naam, wachtwoord);
        if (userCheck != null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="studieOpleiding"></param>
    /// <param name="studieCrohonummer"></param>
    /// <param name="studieniveau"></param>
    /// <param name="studieVariant"></param>
    /// <param name="studieFlexOnd"></param>
    /// <param name="studieVraFin"></param>
    /// <param name="studieVerTra"></param>
    /// <param name="studieSpeTra"></param>
    /// <param name="studieVesPla"></param>

    public static void AddOverzicht(string studieOpleiding, int studieCrohonummer, string studieniveau, string studieVariant, string studieFlexOnd, string studieVraFin, string studieVerTra, string studieSpeTra, string studieVesPla)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "INSERT INTO Studie_overzicht (stuOpleiding, stuCroNr, stuNiveau, stuVariant, stuFlexOnderwijs, stuVraFinanciering, stuVerTraject, stuSpeTraject, vestiging) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
        db.Execute(query, studieOpleiding, studieCrohonummer, studieniveau, studieVariant, studieFlexOnd, studieVraFin, studieVerTra, studieSpeTra, studieVesPla);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="leerjaar"></param>
    /// <param name="periode"></param>
    /// <param name="onderdeelnaam"></param>
    /// <param name="codeleerjaar"></param>
    /// <param name="codeonderwijseenheid"></param>
    /// <param name="coordinator"></param>
    /// <param name="keuze"></param>
    /// <param name="vak"></param>
    /// <param name="ec"></param>
    /// <param name="uitkerenhoofdvak"></param>
    /// <param name="wijzewaardering"></param>
    /// <param name="slagingsnormond"></param>
    /// <param name="woordbeoordeeldond"></param>
    /// <param name="geldigvanaf"></param>
    /// <param name="geldigtm"></param>
    /// <param name="toetscode"></param>
    /// <param name="toetsnaam"></param>
    /// <param name="toetswijze"></param>
    /// <param name="toetsduur"></param>
    /// <param name="waardering"></param>
    /// <param name="slagingnsnorm"></param>
    /// <param name="woordbeoordeeld"></param>
    /// <param name="weging"></param>
    /// <param name="toetsmoment1"></param>
    /// <param name="toetsmoment2"></param>
    /// <param name="volgordelijkheid"></param>
    /// <param name="taal"></param>
    /// <param name="eindwerk"></param>
    /// <param name="examinator"></param>
    public static void InsertRow(string studienaam, string periode, string faseleerjaar, string coordinator, string keuzeverplicht, string titelonderwijs, string studiepunten, string titeltoets, string wijzevtoetsing, string slagingsnorm, string taal, string examinator, string leerjaar)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "INSERT INTO Studie_overview (studienaam, periode, faseleerjaar, coordinator, keuzeverplicht, titelonderwijs, studiepunten, titeltoets, wijzevtoetsing, slagingsnorm, taal, examinator, jaarstudie ) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12)";
        var queryExecute = db.Execute(query, studienaam, periode, faseleerjaar, coordinator, keuzeverplicht, titelonderwijs, studiepunten, titeltoets, wijzevtoetsing, slagingsnorm, taal, examinator, leerjaar);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<dynamic> AddRow(string studienaam)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "SELECT periode, faseleerjaar, coordinator, keuzeverplicht, titelonderwijs, studiepunten, titeltoets, wijzevtoetsing, slagingsnorm, taal, examinator FROM Studie_overview WHERE studienaam = @0";
        var queryCheck = db.Query(query, studienaam);
        return queryCheck;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<dynamic> ShowOverzicht(string naamopleiding)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var sqlCommand = "SELECT stuOpleiding , stuCroNr, stuNiveau, stuVariant , stuFlexOnderwijs, stuVraFinanciering, stuVerTraject, stuSpeTraject, vestiging FROM Studie_overzicht WHERE stuOpleiding = @0";
        var showOverzicht = db.Query(sqlCommand, naamopleiding);
        return showOverzicht;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="studienaam"></param>
    /// <returns></returns>
    public static IEnumerable<dynamic> SelectStudieoverview2(string studienaam, string leerjaar)
    {
        Database db = Database.OpenConnectionString(Functions.connectionstring, Functions.provider);
        var query = "SELECT periode, faseleerjaar, coordinator, keuzeverplicht, titelonderwijs, studiepunten, titeltoets, wijzevtoetsing, slagingsnorm, taal, examinator FROM Studie_overview WHERE studienaam =@0 AND jaarstudie = @1";
        var queryCheck = db.Query(query, studienaam, leerjaar);
        return queryCheck;
    }
}