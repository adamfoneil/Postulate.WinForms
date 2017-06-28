using Postulate.Orm.Merge;
using System;
using System.Windows.Forms;
using Test2.Models;

namespace TestWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var sm = new SchemaMerge<TdgDb>();
            sm.CreateIfNotExists((cn, db) =>
            {
                var orgs = new OrgSeedData();
                orgs.Generate(cn, db);

                var states = new StateSeedData();
                states.Generate(cn, db);
            });


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
