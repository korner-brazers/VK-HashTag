using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.IO.Compression;
using VKHashTag.Engine.Class;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag
{
    public enum FileDB
    {
        conf,
        job,
        user
    }


    public class CryptoDB
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                          Временные данные для обработки запросов криптографии                      #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static FileStream fs = null;        //Поток для файла
        private static MemoryStream ms = null;      //Поток для отдачи класса
        private static StreamReader sr = null;      //Поток для отдачи класса
        private static CryptoStream crypt = null;   //Криптография данных
        private static Aes aes = CreateAES();       //Ключ AES256
        private static string dir = @"CryptoDB\", DirLast = dir + @"last\";   //Дириктории

        private static Aes CreateAES()
        {
            byte[] IVa = new byte[] { 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x11, 0x11, 0x12, 0x13, 0x14, 0x0e, 0x16, 0x17 };
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(IVa, 0, IVa.Length), Encoding.UTF8.GetBytes(Iron.get));
            Aes _aes = new AesManaged();
            _aes.Key = deriveBytes.GetBytes(256 / 16);
            _aes.IV = _aes.Key;
            IVa = null; deriveBytes = null;
            return _aes;
        }

        private static void Dispose()
        {
            if (crypt != null)
            {
                try
                {
                    crypt.FlushFinalBlock();
                }
                catch { }
                crypt = null;
            }
            if (fs != null) { fs.Close(); fs.Dispose(); fs = null; }
            if (ms != null) { ms.Close(); ms.Dispose(); ms = null; }
            if (sr != null) { sr.Close(); sr.Dispose(); sr = null; }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                         Работа с данными, запись и чтение данных их файлов                         #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Write(FileDB file, object data)
        {
            if (db.IsLoad)
                return;

            try
            {
                Directory.CreateDirectory(dir);     //Создаем каталог для данных
                Directory.CreateDirectory(DirLast); //Создаем каталог для данных
                fs = new FileStream(dir + file.ToString(), FileMode.Create, FileAccess.Write);  //Поток для записи данных в файл
                crypt = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write);    //Записывает шифрованные данные в поток fs 

                //Считываем данные data, конвертируем в json в формете string и разбиваем на байты
                foreach (byte DataByte in Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)))
                {
                    crypt.WriteByte(DataByte);
                }
            }
            catch (Exception e) { MessageBOX.Show(e.Message, e.StackTrace); }

            //Чистим ресурсы
            Dispose(); data = null;

            //Создаем бекап файла
            File.Copy((dir + file.ToString()), (DirLast + file.ToString()), true);
        }


        public static T Read<T>(FileDB file)
        {
            T result = default(T);
            string dirs = dir + file.ToString();

            Reset: try
            {
                ms = new MemoryStream(File.ReadAllBytes(dirs)); //Считываем файл
                crypt = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read); //Расшифровываем файл
                sr = new StreamReader(crypt); //хз, но получаем типа string
                result = JsonConvert.DeserializeObject<T>(sr.ReadToEnd()); //Возвращаем класс после обработчки json
            }
            catch 
            {
                //Берем данные из бекапа
                if (dirs != (DirLast + file.ToString()))
                {
                    dirs = (DirLast + file.ToString());
                    goto Reset;
                }
            }

            //Чистим ресурсы и возвращаем результат
            Dispose();
            return result;
        }
    }
}
