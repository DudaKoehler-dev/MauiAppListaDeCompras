using MauiAppListaDeCompras.Helpers;

namespace MauiAppListaDeCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                            ), "Banco_sqlite_compras.db3"
                        );
                    _db = new SQLiteDatabaseHelper(path);
                }
                return _db;
            }
        }
        public App()
        {

            MainPage = new AppShell();
        }
    }
    }

