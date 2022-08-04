using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Project_002.MVVM.Model
{
    internal class RepositoryModel<T>
    {
        private static string json;
        private ObservableCollection<T> storage;
        public ObservableCollection<T> Storage
        {
            get { return storage; }
            set { storage = value; }
        }

        public RepositoryModel()
        {
            Storage = new ObservableCollection<T>();
        }
        public ObservableCollection<T> UploadData(List<T> otherGroup)
        {
            foreach (var item in otherGroup)
            {
                Storage.Add(item);
            }
            return Storage;
        }

        static public void SaveToDataBase(ObservableCollection<T> saveDB)
        {
            json = JsonConvert.SerializeObject(saveDB);
            File.WriteAllText("_bankAccount.json", json);
        }
    }
}
