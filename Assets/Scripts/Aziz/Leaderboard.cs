using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

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
    private string filePath = "Assets/Scripts/Aziz/Leaderboard.json";
    private List<Player> players;

    private void Awake()
    {
        readFile();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SaveScore(int score, string name)
    {
        
        players.Insert(0,new Player(name,score)); 
        players = players.OrderByDescending(p => p.score).ToList();
        
        if(players.Count > 10)
            players.RemoveAt(players.Count-1);
        
        updatedFile();
        readFile();
    }

    private void updatedFile()
    {
        var streamWrite = new StreamWriter(filePath, false);
        var jsonToString = JsonConvert.SerializeObject(players);
        streamWrite.Write(jsonToString);
        streamWrite.Close();
    }

    private void readFile()
    {
        var streamReader = new StreamReader(filePath);
        players = JsonConvert.DeserializeObject<List<Player>>(streamReader.ReadToEnd());
        streamReader.Close();
    }

    public string getLeaderBoard()
    {
        var top10 = "";
        for (int i = 0; i < players.Count; i++)
        {
            top10 += $"\n {players[i].name} : {players[i].score}";
        }
        return top10;
    }

    private void InsertInPlayerList(List<Player> list ,Player newPlayer)
    {
        // if highest score 
        if(newPlayer.score> players[0].score)
            players.Insert(0,newPlayer);
        // if lowest score 
        else if(newPlayer.score <= players[players.Count-1].score)
            players.Insert(players.Count , newPlayer);
        else
        {
            for (int i = 1; i < players.Count; i++)
            {
                if ((players[i - 1].score <= newPlayer.score) && (newPlayer.score < players[i].score))
                {
                    players.Insert(i, newPlayer);
                    return;
                }
            }
        }
        
        if(players.Count >10)
            players.RemoveAt(players.Count-1);

    }
}
