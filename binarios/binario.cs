using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace binarios
{
    [Serializable]
    internal class binario
    {
        public List<string> Cells { get; set; } = new List<string>();

        internal List<binario> Deserialize(FileStream fs)
        {
            throw new NotImplementedException();
        }

        internal void Serialize(FileStream fs, List<binario> rows)
        {
            throw new NotImplementedException();
        }
    }
}
