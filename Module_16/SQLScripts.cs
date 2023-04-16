using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Module_16
{
    class SQLScripts
    {
        public void SqlInsert(string sql, SqlDataAdapter da, SqlConnection con)
        {
            sql = @"INSERT INTO TableUser (secondName, firstName, lastName, phoneNumber, email)
                                VALUES (@secondName, @firstName, @lastName, @phoneNumber, @email);
                    set @id = @@IDENTITY;";
            da.InsertCommand = new SqlCommand(sql, con);
            da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            da.InsertCommand.Parameters.Add("@secondName", SqlDbType.NVarChar, 20, "secondName");
            da.InsertCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 20, "firstName");
            da.InsertCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 30, "lastName");
            da.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 12, "phoneNumber");
            da.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 40, "email");
        }
        public void SqlDelete(string sql, SqlDataAdapter da, SqlConnection con)
        {
            sql = "DELETE FROM TableUser WHERE id = @id";
            da.DeleteCommand = new SqlCommand(sql, con);
            da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
        }
        public void SqlUpdate(string sql, SqlDataAdapter da, SqlConnection con)
        {
            sql = @"UPDATE TableUser SET
                           secondName = @secondName,
                           firstName = @firstName,
                           lastName = @lastName,
                           phoneNumber = @phoneNumber,
                           email = @email
                    WHERE id = @id";
            da.UpdateCommand = new SqlCommand(sql, con);
            da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            da.UpdateCommand.Parameters.Add("@secondName", SqlDbType.NVarChar, 20, "secondName");
            da.UpdateCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 20, "firstName");
            da.UpdateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 30, "lastName");
            da.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 12, "phoneNumber");
            da.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 40, "email");
        }
    }
}
