using Postulate.Sql.Abstract;
using Postulate.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2.Models;

namespace TestWinForms.Queries
{
    public class StateSelect : Query<ListItem<string>>
    {
        public StateSelect() : base(
            "SELECT [Abbreviation] AS [Value], [Name] AS [Text] FROM [dbo].[State] ORDER BY [Abbreviation]", 
            () => new TdgDb().GetConnection())
        {
        }
    }
}
