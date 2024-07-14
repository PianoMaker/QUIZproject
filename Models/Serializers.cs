using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Serializers
    {
        public static byte[] SerializeObject<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static T DeserializeObject<T>(byte[] data)
        {            
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(memoryStream);
            }
        }


        public static bool TryDeserializeObject<T>(byte[] data, int dataLength, out T obj)
        {
            
            obj = default;            
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(data, 0, dataLength))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    obj = (T)serializer.ReadObject(memoryStream);
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

    }
}
