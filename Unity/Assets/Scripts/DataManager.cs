using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Newtonsoft;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

public static class DataManager
{
    private const string DATA_FILE = "profiles.data";

    public static void SaveData(Profiles profiles)
    {
        string jsonProfiles = JsonUtility.ToJson(profiles, true);
        Debug.Log("json: " + jsonProfiles);
        string path = Path.Combine(Application.persistentDataPath, DATA_FILE);
        File.WriteAllText(path, jsonProfiles);

        Debug.Log(path);
    }

    public static Profiles LoadData(string defaultAvatar)
    {
        Profiles profiles;

        string path = Path.Combine(Application.persistentDataPath, DATA_FILE);
 
        try
        {
            if (File.Exists(path))
            {

                string jsonProfiles = File.ReadAllText(path);

                profiles = JsonUtility.FromJson<Profiles>(jsonProfiles);
                
            }
            else
            {
                // Si no existe el archivo cargamos datos por defecto.
                Profile[] gameProfiles = new Profile[6];
                Debug.Log("length game profiles: " + gameProfiles.Length);
                for (int i = 0; i < gameProfiles.Length; i++)
                {
                    gameProfiles[i] = new Profile(defaultAvatar);
                }

                profiles = new Profiles(gameProfiles);

            }
        }
        catch (Exception e)
        {
            Debug.Log(" Se produce una excepcion: " + e.Message);
            // Si no se puede abrir el archivo cargamos datos por defecto y con SaveData sobreescribimos el archivo corrupto
            Profile[] gameProfiles = new Profile[6];
            Debug.Log("length game profiles: " + gameProfiles.Length);
            for (int i = 0; i < gameProfiles.Length; i++)
            {
                gameProfiles[i] = new Profile(defaultAvatar);
            }

            profiles = new Profiles(gameProfiles);

        }

        SaveData(profiles);

        return profiles;

    }

}
