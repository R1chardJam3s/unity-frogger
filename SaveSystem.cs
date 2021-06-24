using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    private static string path = Application.persistentDataPath + "/player.bin";

    public static void SavePlayers()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = GameObject.Find("GameManager").GetComponent<GameManager>().getData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadPlayers()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameObject.Find("GameManager").GetComponent<GameManager>().setData(formatter.Deserialize(stream) as PlayerData);
            stream.Close();
        } else
        {
            //Debug.LogError("File " + path + " can not be found");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData();
            data.createBlank();

            formatter.Serialize(stream, data);
            stream.Close();
            LoadPlayers();
        }
    }

    public static void resetSave()
    {
        File.Delete(path);
    }
}
