using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    public class Tools
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "_");
        }


        #region 序列化到磁盘

        //public static void Serialize<T>(T o, string filePath)
        //{
        //    try
        //    {
        //        XmlSerializer formatter = new XmlSerializer(typeof(T));
        //        StreamWriter sw = new StreamWriter(filePath, false);
        //        formatter.Serialize(sw, o);
        //        sw.Flush();
        //        sw.Close();
        //    }
        //    catch (Exception) { }
        //}

        //public static T DeSerialize<T>(string filePath)
        //{
        //    try
        //    {
        //        XmlSerializer formatter = new XmlSerializer(typeof(T));
        //        StreamReader sr = new StreamReader(filePath);
        //        T o = (T)formatter.Deserialize(sr);
        //        sr.Close();
        //        return o;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return default(T);
        //}

        //public static void Serialize<T>(T o, string filePath)
        //{
        //    try
        //    {
        //        SoapFormatter formatter = new SoapFormatter();
        //        // StreamWriter sw = new StreamWriter(filePath, false);
        //        Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        //        formatter.Serialize(stream, o);
        //        stream.Flush();
        //        stream.Close();
        //    }
        //    catch (Exception) { }
        //}

        //public static T DeSerialize<T>(string filePath)
        //{
        //    try
        //    {
        //        SoapFormatter formatter = new SoapFormatter();
        //       // StreamReader sr = new StreamReader(filePath);
        //        Stream destream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        T o = (T)formatter.Deserialize(destream);
        //        destream.Flush();
        //        destream.Close();
        //        return o;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return default(T);
        //}

        public static void BinarySerialize<T>(T o, string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, o);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public static T BinaryDeSerialize<T>(string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream destream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                T o = (T)formatter.Deserialize(destream);
                destream.Flush();
                destream.Close();
                return o;
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }

        #endregion
    }
}
