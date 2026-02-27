using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SavePosition();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPosition();
        }
    }

    private void SavePosition()
    {
        SaveableVector3 playerPos = new SaveableVector3(_player.position);
        Debug.Log(playerPos);

        string savePath = Application.persistentDataPath + "/PositionSaveFile.json";

        string jsonText = JsonConvert.SerializeObject(playerPos);
        File.WriteAllText(savePath, jsonText);

        Debug.Log("File saved!");
    }

    private void LoadPosition()
    {
        string savePath = Application.persistentDataPath + "/PositionSaveFile.json";
        string json = File.ReadAllText(savePath);
        var data = JsonConvert.DeserializeObject<SaveableVector3>(json);

        _player.position = data.GetVector3();
        Debug.Log("File loaded");
    }

}

[System.Serializable]
public class SaveableVector3
{
    public float _x, _y, _z;

    public SaveableVector3(Vector3 vector)
    {
        _x = vector.x;
        _y = vector.y;
        _z = vector.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(_x, _y, _z);
    }
}
