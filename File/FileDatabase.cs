using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiGuimaraesEletronica.File
{
    public class FileDatabase<T>
    {
        private string _fileName;

        public FileDatabase(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<ICollection<T>> Read()
        {
            if (System.IO.File.Exists(_fileName) == false)
                return new List<T>();

            var data = await System.IO.File.ReadAllTextAsync(_fileName);

            return JsonConvert.DeserializeObject<ICollection<T>>(data);
        }

        public void Save(ICollection<T> data)
        {
            var json = JsonConvert.SerializeObject(data);

            System.IO.File.WriteAllText(_fileName, json);
        }
    }
}