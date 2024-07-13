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
            using (MemoryStream memoryStream = new MemoryStream(data, 0, dataLength))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    obj = (T)serializer.ReadObject(memoryStream);
                    Console.Beep(880, 100);
                    return true;
                }
                catch (Exception ex)
                {
                    // Логування або обробка виключення за потреби
                    Console.WriteLine($"Deserialization failed: {ex.Message}");
                    Console.Beep(660, 100);
                    obj = default;
                    return false;
                }
            }
        }


        public static bool TryDeserializeList<T>(byte[] data, int dataLength, out List<T> obj)
        {
            using (MemoryStream memoryStream = new MemoryStream(data, 0, dataLength))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<T>));
                    obj = (List<T>)serializer.ReadObject(memoryStream);
                    if (typeof(T) == typeof(Quiz)) 
                    {
                        Console.Beep(1000, 100);
                    }
                    if (typeof(T) == typeof(SQuiz))
                    {
                        Console.Beep(1200, 100);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed                    
                    Console.Beep(500, 200);
                    obj = default;
                    return false;
                }
            }
        }

    }
}
