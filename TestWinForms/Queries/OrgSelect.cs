using Postulate.Sql.Abstract;
using Postulate.WinForms;
using Test2.Models;

namespace TestWinForms.Queries
{
    public class OrgSelect : Query<ListItem<int>>
    {
        public OrgSelect() : base(
            "SELECT [Id] AS [Value], [Name] AS [Text] FROM [dbo].[Organization] ORDER BY [Name]", 
            () => new TdgDb().GetConnection())
        {
        }
    }
}
