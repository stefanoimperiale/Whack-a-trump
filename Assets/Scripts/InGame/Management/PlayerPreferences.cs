using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public static bool GetBool(string key) {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
    public static string GetString(string key) {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetString(key);
        else
            return null;
    }

    public static void SetBool(string key, bool value) {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
     }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
}
