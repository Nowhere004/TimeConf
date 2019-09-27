using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    private static string path = Application.persistentDataPath + "/saves/";
    public static void Save<T>(T objectToSave,string key)
    {
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path + key + ".tk", FileMode.Create))
        {
            formatter.Serialize(fileStream,objectToSave);
        }
    }

    public static T Load<T>(string key)
    {        
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fileStream = new FileStream(path + key + ".tk", FileMode.Open))
        {
          returnValue=(T)formatter.Deserialize(fileStream);
        }
        return returnValue;
    }


    public static bool SaveExists(string key)
    {
        string filePath = Application.persistentDataPath + "/saves/"+key+".tk";
        return File.Exists(filePath);
    }

}
