using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    public static SaveHandler INSTANCE;
    public const string EXTENSION = ".goo";
    public GameSave currentSave;

    private void Awake()
    {
        if (INSTANCE != null)
            Destroy(this);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static bool SerializeData(string name, object gameSave)
    {
        BinaryFormatter fm = new BinaryFormatter();

        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + name + EXTENSION;

        FileStream file = File.Create(path);
        fm.Serialize(file, gameSave);
        file.Close();
        return true;
    }

    public static object DeserializeData(string path)
    {
        if (!File.Exists(path))
            return null;

        BinaryFormatter fm = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = fm.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at " + path);
            file.Close();
            return null;
        }
    }

    public string[] GetGameSaveLists()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        return Directory.GetFiles(Application.persistentDataPath + "/saves/");
    }

    public void CreateSave()
    {
        GameSave newSave = new GameSave();
        List<PlorbSaveData> plorbs = new List<PlorbSaveData>();

        PlorbData[] list = PlorbDefiner.INSTANCE.GetComponentsInChildren<PlorbData>();

        foreach (PlorbData x in list)
        {
            plorbs.Add(SavePlorb(x));
        }

        newSave.plorbs = plorbs;
        newSave.money = PlayerManager.INSTANCE.Money;

        currentSave = newSave;
    }

    public PlorbSaveData SavePlorb(PlorbData plorb)
    {
        PlorbSaveData save = new PlorbSaveData
        {
            genes = plorb.genes,
            body = plorb.body,
            ear = plorb.ear,
            wing = plorb.wing,
            eye = plorb.eye,

            r = plorb.hue.r,
            g = plorb.hue.g,
            b = plorb.hue.b,

            value = plorb.value,
            age = plorb.Age,

            givenName = plorb.givenName,
            title = plorb.title,

            totalJuiceCapacity = plorb.totalJuiceCapacity,

            hungerDecayRate = plorb.hungerDecayRate,
            happinessDecayRate = plorb.happinessDecayRate,
            juiceIncreaseRate = plorb.juiceIncreaseRate,

            happiness = plorb.Happiness,
            hunger = plorb.Hunger,
            currentJuice = plorb.CurrentJuice,

            deathState = plorb.deathState,
            x = plorb.gameObject.transform.position.x,
            y = plorb.gameObject.transform.position.y
        };

        return save;
    }

}


[System.Serializable]
public class GameSave
{
    public List<PlorbSaveData> plorbs;
    public int money;
}

[System.Serializable]
public class PlorbSaveData
{
    public PlorbGenes genes;

    public BodyStyle body;
    public EarStyle ear;
    public WingStyle wing;
    public EyeStyle eye;

    public float r;
    public float g;
    public float b;

    public int value;
    public int age;

    public string givenName;
    public string title;

    public int totalJuiceCapacity;

    //all in per seconds
    public float hungerDecayRate;
    public float happinessDecayRate;
    public float juiceIncreaseRate;

    public float happiness;
    public float hunger;
    public float currentJuice;

    public DeathState deathState;

    public float x;
    public float y;
}
