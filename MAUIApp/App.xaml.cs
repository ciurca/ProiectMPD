using System;
using MirthApp.Data;
using System.IO;

namespace MirthApp
{
    public partial class App : Application
    {
        static ReleaseDatabase database;

        public static ReleaseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    ReleaseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Release.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
