
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    //As we need to store information for each level we use one more parameter and use that in PlayerPref key
    //This will Get Best Time 
    public static float GetBestTime(int id, string level)
    {
        return PlayerPrefs.GetFloat("BestTime" + id + "OfLevel" + level);
    }
    //This will Set Best Time for the level
    public static void SetBestTime(int id, string level, float val)
    {
        PlayerPrefs.SetFloat("BestTime" + id + "OfLevel" + level, val);
    }
    //Whenever level completed we increase the count and save that information to playerpref
    //Get Level Completed Counts
    public static int GetBestTimeMaxCount(string level)
    {
        return PlayerPrefs.GetInt("BesTimeMaxCountOf" + level);
    }
    //Set Level Completed Counts
    public static void SetBestTimeMaxCountAdded(int val, string level)
    {
        PlayerPrefs.SetInt("BesTimeMaxCountOf" + level, val);
    }
}
