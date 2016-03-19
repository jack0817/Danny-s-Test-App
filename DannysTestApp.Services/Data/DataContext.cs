using DannysTestApp.Model;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;

namespace DannysTestApp.Services.Data
{
    public class DataContext
    {
        #region Constants
        private const string MODEL_NAMESPACE = "DannysTestApp.Model";
        #endregion

        #region Static Fields
        private static DataContext _shared = new DataContext();
        #endregion

        #region Static Properties
        public static DataContext Shared
        {
            get { return DataContext._shared; }
        }
        #endregion

        #region Tables
        public TableQuery<TestModel> TestModels
        {
            get { return this.Connection.Table<TestModel>(); }
        }

        #endregion

        #region Private Properties
        private SQLiteConnection Connection { get; set; }
        #endregion

        #region Ctors
        private DataContext(){ /*Private Constructor*/ }
        #endregion

        #region Public Instance Methods
        public async Task InitAsync(string path)
        {
            this.Connection = await ConnectionPool.Shared.GetConnection(path);
        }

        public async Task CreateModelAsync()
        {
            await Task.Yield();
            var modelAssembly = Assembly.Load(new AssemblyName(DataContext.MODEL_NAMESPACE));
            var modelTypes = modelAssembly.GetExportedTypes().Where(et => et.Namespace == modelAssembly.GetName().Name);
            foreach (var mt in modelTypes)
            {
                this.Connection.CreateTable(mt);
            }
        }
        #endregion

        #region SQL Async Stack
        public Task<int> InsertAsync(object row)
        {
            return Task.Run(() => this.ExecuteWithLock(() => this.Insert(row)));
        }
        #endregion

        #region SQL Stack
        public int Insert(object row)
        {
            return this.Connection.Insert(row);
        }
        #endregion

        #region Private Instance Methods
        private int ExecuteWithLock(Func<int> sqlFunction)
        {
            lock(this.Connection)
            {
                return sqlFunction();
            }
        }
        #endregion
    }

    internal class ConnectionPool
    {
        private const string DB_NAME = "App.sqlite";

        private static ConnectionPool _shared = new ConnectionPool();
        private static Dictionary<string, SQLiteConnection> ConnPool = new Dictionary<string, SQLiteConnection>();

        public static ConnectionPool Shared
        {
            get { return _shared; }
        }

        internal async Task<SQLiteConnection> GetConnection(string path)
        {
            if (ConnectionPool.ConnPool.ContainsKey(path))
                return ConnectionPool.ConnPool[path];

            var dbFolder = await this.GetDatabaseFolder(path);
            var dbPath = Path.Combine(dbFolder.Path, ConnectionPool.DB_NAME);
            var conn = new SQLiteConnection(new SQLitePlatformWinRT(), dbPath, false);
            ConnectionPool.ConnPool.Add(path, conn);
            return conn;
        }

        private async Task<IStorageFolder> GetDatabaseFolder(string path)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var pathFolder = await localFolder.CreateFolderAsync(path, CreationCollisionOption.OpenIfExists);
            return pathFolder;
        }
    }
}
