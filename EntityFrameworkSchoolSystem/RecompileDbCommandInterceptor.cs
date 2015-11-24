using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace EntityFrameworkSchoolSystem
{
    public class RecompileDbCommandInterceptor : IDbCommandInterceptor
    {
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (!command.CommandText.EndsWith(" option(recompile)"))
            {
                command.CommandText += " option(recompile)";
            }
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<Int32> interceptionContext)
        {
            if (!command.CommandText.EndsWith(" option(recompile)"))
            {
                command.CommandText += " option(recompile)";
            }
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (!command.CommandText.EndsWith(" option(recompile)"))
            {
                command.CommandText += " option(recompile)";
            }
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
}