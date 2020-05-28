using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

namespace LoadingSystem
{
    /// <summary>
    /// provides functionality to save and load models in filesystem
    /// </summary>
    /// <typeparam name="T"> type of Model</typeparam>
    public class FSSingleSaver<T> where T : IFSSavable, ISerializable
    {
        private static readonly string savingFormatPrefix = ".bin";
        private static readonly string root = Application.persistentDataPath;
        /// <summary>
        /// saves the serializable and FS savable model class into filesystem at its implemented path
        /// </summary>
        /// <param name="model">model object to save</param>
        public static void SaveToFS(T model)
        {
            string path = getPath(model);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            var jsonString = Serializer<T>.ToJson(model);
            formatter.Serialize(stream, jsonString);
            stream.Close();
        }
        /// <summary>
        /// Loads saved model into the given object from filesystem
        /// </summary>
        /// <param name="model">object to load data into it</param>
        /// <returns>the loaded model</returns>
        /// <exception cref="IOException">trying to load not saved model</exception>
        public static T LoadFromFS(T model)
        {
            string path = getPath(model);
            if (File.Exists(path))
            {
                
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                var data = formatter.Deserialize(stream) as string;
                model = Serializer<T>.UpdateObjectFromJson(data, model);
                stream.Close();
                return model;
            }
            throw new IOException("File Not Found");
        }

        private static string getPath(T model)
        {
            return root + "/" + model.SavingPath + savingFormatPrefix;
        }
    }
}