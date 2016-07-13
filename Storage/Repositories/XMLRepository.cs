using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using StorageLib.Entities;
using StorageLib.Interfaces;

namespace Storage.Repositories
{
    public class XMLRepository : IRepository
    {
        private IGeneratorId generator;
        private string fileName;

        public XMLRepository(IGeneratorId generator, string fileName)
        {
            this.generator = generator;
            this.fileName = fileName;
        }

        public List<User> Load()
        {
            var formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream xmlFile = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (List<User>)formatter.Deserialize(xmlFile);
            }
        }

        public void Save(List<User> users)
        {
            var formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream xmlFile = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(xmlFile, users);
            }
        }
    }
}
