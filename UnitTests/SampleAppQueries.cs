using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWinForms.Queries;
using Postulate.WinForms;
using Postulate.Sql.Abstract;

namespace UnitTests
{
    [TestClass]
    public class SampleAppQueries
    {
        [TestMethod]
        public void TestOrgSelect()
        {
            var qry = new OrgSelect();
            qry.Test();
        }
    }
}
