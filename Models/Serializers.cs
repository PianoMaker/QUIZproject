using System.Runtime.Serialization;

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
