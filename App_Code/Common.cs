using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common: IDisposable
{
    private bool alreadyDisposed = false;
    SqlConnection Con = null;
    SqlCommand Cmd = null;
    SqlDataAdapter DA = null;
    string ConnectionString = "";
    private static Common hrinstance = null;

    Common(string constr)
    {
        ConnectionString = constr;
        Con = new SqlConnection(ConnectionString);
        Con.Open();
    }



    public static Common getInstance()
    {
        if (hrinstance == null)
        {
            hrinstance = new Common(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        else
        {
            hrinstance.Con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            hrinstance.Con.Open();
        }
        return hrinstance;
    }

    ~Common()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }
    public void Dispose(bool explicitCall)
    {
        if (!this.alreadyDisposed)
        {
            if (explicitCall)
            {
                if (Con.State == ConnectionState.Open) Con.Close();
                if (null != Con) Con.Dispose();
                if (null != Cmd) Cmd.Dispose();
                if (null != DA) DA.Dispose();
                ConnectionString = null;
            }
        }
        alreadyDisposed = true;
    }

    public int ExecuteQuery(string SqlStr)
    {
        try
        {
            Cmd = new SqlCommand(SqlStr);
            Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Con;
            int i = Cmd.ExecuteNonQuery();
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet ExecuteProcedure_DataSet(string ProcName, Hashtable HT)
    {
        DataSet dt1 = new DataSet();
        try
        {
            conn();
            Cmd = new SqlCommand(ProcName, Con);
            Cmd.CommandTimeout = 600;
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(Cmd);

            foreach (SqlParameter pr in Cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(dt1);
            return dt1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != Cmd) Cmd.Dispose();
        }
    }

    private void conn()
    {
        if (Con.State != ConnectionState.Closed)
        {
            Con.Close();
        }
        Con.Open();
    }

    public DataSet ExecuteCmd(string sSql)
    {
        DataSet dst = new DataSet();

        using (SqlConnection scn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
        {
            using (SqlCommand sCmd = new SqlCommand(sSql, scn))
            {
                sCmd.CommandTimeout = 180;
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = sCmd;
                    da.Fill(dst, "Table1");
                }
                sCmd.Dispose();
            }
            if (scn.State == ConnectionState.Open) { scn.Close(); }
        }
        return dst;
    }


    public void ExecuteProcedure(string ProcName, Hashtable HT)
    {
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand(ProcName, Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (SqlParameter pr in cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != cmd) cmd.Dispose();
        }
    }
    public void ExecuteProcedure(SqlConnection Con, SqlCommand cmd, Hashtable HT)
    {
        try
        {
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (SqlParameter pr in cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != cmd) cmd.Dispose();
        }
    }

    public Hashtable ExecuteProcedure_out(string ProcName, Hashtable HT)
    {
        SqlCommand cmd = null;
        Hashtable OutT = new Hashtable(); ;
        try
        {
            cmd = new SqlCommand(ProcName, Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (SqlParameter pr in cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            cmd.ExecuteNonQuery();

            foreach (SqlParameter pr in cmd.Parameters)
            {

                if (pr.Direction == ParameterDirection.Output || pr.Direction == ParameterDirection.InputOutput || pr.Direction == ParameterDirection.ReturnValue)
                {
                    OutT.Add(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1), pr.Value);
                }
            }
            return OutT;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != cmd) cmd.Dispose();
        }
    }

    public Hashtable ExecuteProcedure_out(SqlConnection Con, SqlCommand cmd, Hashtable HT)
    {
        Hashtable OutT = new Hashtable(); ;
        try
        {
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (SqlParameter pr in cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            cmd.ExecuteNonQuery();

            foreach (SqlParameter pr in cmd.Parameters)
            {

                if (pr.Direction == ParameterDirection.Output || pr.Direction == ParameterDirection.InputOutput || pr.Direction == ParameterDirection.ReturnValue)
                {
                    OutT.Add(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1), pr.Value);
                }
            }
            return OutT;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != cmd) cmd.Dispose();
        }
    }


    public DataTable ExecuteProcedure_GetTable(string ProcName, Hashtable HT)
    {
        DataTable dt1 = new DataTable();
        try
        {
            Cmd = new SqlCommand(ProcName, Con);
            Cmd.CommandTimeout = 600;
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(Cmd);

            foreach (SqlParameter pr in Cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(dt1);
            return dt1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != Cmd) Cmd.Dispose();
        }
    }

    public DataSet ExecuteProcedure_GetDataset(string ProcName, Hashtable HT)
    {
        DataSet dt1 = new DataSet();
        try
        {
            Cmd = new SqlCommand(ProcName, Con);
            Cmd.CommandTimeout = 600;
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(Cmd);

            foreach (SqlParameter pr in Cmd.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    if (HT.Contains(pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)))
                    {
                        pr.Value = HT[pr.ParameterName.Substring(1, pr.ParameterName.Length - 1)];
                    }
                }
            }
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(dt1);
            return dt1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != Cmd) Cmd.Dispose();
        }
    }

    public DataTable GetTable(string SqlStr)
    {
        DataTable dt1 = new DataTable();
        try
        {
            Cmd = new SqlCommand(SqlStr);
            Cmd.Connection = Con;
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(dt1);
            return dt1;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }

    }

    public string GetValue(string Sqlstr)
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string Value = "";
        try
        {
            cmd = new SqlCommand(Sqlstr, Con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0] != DBNull.Value)
                {
                    Value = dr[0].ToString();
                }
                else
                {
                    Value = "0.00";
                }
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (null != cmd) cmd.Dispose();
            if (null != dr) dr.Dispose();
        }
        return Value;
    }
}