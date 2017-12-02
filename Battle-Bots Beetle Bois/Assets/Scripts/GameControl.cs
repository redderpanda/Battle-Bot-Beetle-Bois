using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



//This will be the class that has all of the information about the player. Level, stats, beetles, progress in the game, whatever. '





public class GameControl : MonoBehaviour
{

    public static GameControl currentPlayer;

    public string name;
    public int level;
    public int exp;
    
    public List<BBBBLegs> Legs = new List<BBBBLegs>();
    public List<BBBBArms> Arms = new List<BBBBArms>();
    public List<BBBBBase> Base = new List<BBBBBase>();
    public List<BBBBWings> Wings = new List<BBBBWings>();

  
    public GameObject l;
    
    private void Awake() //There should be only one playerData. If a playerData is made that is not the static currentPlayer, kill it for its existance is blasphemy 
    {
        if (currentPlayer == null)
        {
            DontDestroyOnLoad(gameObject);
            currentPlayer = this;
          

        }
        else if (currentPlayer != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        name = "Player name";
        level = 0;
        exp = 0;

        Load();
     
       
        

    }

    public void Save() //saves the current data into a file supposedly works on every platform
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.name = name;
        data.level = level;
        data.exp = exp;

        
        
        bf.Serialize(file,data);
        file.Close();
    }

    public void Load()
    {
        Debug.Log("Now about to load");
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

     level = data.level;
        name = data.name;
            exp = data.exp;

   //         Legs = data.Legs;
            
        }
    }

    public void setLevel()
    {
        level = 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[Serializable]
class PlayerData //This class exists to hold the data and then be saved 
 {
    public int level;
    public string name;
    public int exp;
    public List<GameObject> Legs = new List<GameObject>();

}