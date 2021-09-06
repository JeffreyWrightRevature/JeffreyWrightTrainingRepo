using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Storage.Model;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\stores.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    private readonly List<Store> stores;
    public StoreRepository()
    {
      using (var context = new StoreApplicationDBContext())
      {
        stores = context.Stores.FromSqlRaw<Store>("SELECT * FROM Store.Store").ToList();
      }
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Store entry)
    {
      //_fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });
      stores.Add(entry);
      return true;
    }

    public List<Store> Select()
    {
      //return _fileAdapter.ReadFromFile<Store>(_path);
      return stores;
    }

    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}