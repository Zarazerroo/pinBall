using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using NUnit.Framework;

public class Player
{
     public string name;
     public int score;
     public Player(string name, int score)
     {
         this.name = name;
         this.score = score; 
     }
}
public class Leaderboard : MonoBehaviour
{
    private const string KEY = "LEADERBOARD";
    private string FilePath = "Assets/Scripts/Aziz/Leaderboard.json";
    private List<Player> Players;
    
    public string getLeaderBoard()
    {
        var top10 = "";
        if (Players.Count > 0)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                top10 += $"\n {Players[i].name} : {Players[i].score}";
            }
        }
        return top10;
    }

    public void SaveScore(int score, string name)
    {
        if (name == "")
        {
            name = "John Doe";
        }

        Players.Insert(0,new Player(name,score)); 
        Players = Players.OrderByDescending(p => p.score).ToList();

        if (Players.Count > 10)
        {
            Players.RemoveAt(Players.Count - 1);
        }
        
#if UNITY_WEBGL
        Debug.LogWarning("saving to web");
        SaveToWeb();
        ReadFromWeb();
#endif
#if UNITY_EDITOR
        Debug.LogWarning("saving to local");
        SaveToJson();
        ReadFromJson();
#endif
    }
    
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.LogWarning("reading from local");

        ReadFromJson();
#endif        
#if UNITY_WEBGL
        Debug.LogWarning("reading from web");

        ReadFromWeb();
#endif
    }
    
    /// <summary>
    /// updates the json file with the current version of the players list
    /// </summary>
    private void SaveToJson()
    {
        var streamWrite = new StreamWriter(FilePath, false);
        var jsonToString = JsonConvert.SerializeObject(Players);
        streamWrite.Write(jsonToString);
        streamWrite.Close();
    }

    /// <summary>
    /// reads from a json file and populate the list of players
    /// </summary>
    private void ReadFromJson()
    {
        if (File.Exists(FilePath))
        {
            var streamReader = new StreamReader(FilePath);
            Players = JsonConvert.DeserializeObject<List<Player>>(streamReader.ReadToEnd());
            streamReader.Close();

            if (Players == null)
            {
                Players = new List<Player>();
            }
        }
        else
        {
            Players = new List<Player>();
        }
    }

    /// <summary>
    /// converts the list of current player to readable string,
    /// for use in text view
    /// </summary>
    /// <returns></returns>
    private void SaveToWeb()
    {
        var leaderBoardText = JsonConvert.SerializeObject(Players);
        PlayerPrefs.SetString(KEY,leaderBoardText);
        PlayerPrefs.Save();
    }
    private void ReadFromWeb()
    {
        var leaderBoardText = PlayerPrefs.GetString(KEY,"[{\"name\":\"John Doe\",\"score\":0}]");
        Players = JsonConvert.DeserializeObject<List<Player>>(leaderBoardText);
    }
    /*
     
    private void InsertInPlayerList(List<Player> list ,Player newPlayer)
       {
           // if highest score 
           if(newPlayer.score> Players[0].score)
               Players.Insert(0,newPlayer);
           // if lowest score 
           else if(newPlayer.score <= Players[Players.Count-1].score)
               Players.Insert(Players.Count , newPlayer);
           else
           {
               for (int i = 1; i < Players.Count; i++)
               {
                   if ((Players[i - 1].score <= newPlayer.score) && (newPlayer.score < Players[i].score))
                   {
                       Players.Insert(i, newPlayer);
                       return;
                   }
               }
           }
           
           if(Players.Count >10)
               Players.RemoveAt(Players.Count-1);
       }
       
     */
}
