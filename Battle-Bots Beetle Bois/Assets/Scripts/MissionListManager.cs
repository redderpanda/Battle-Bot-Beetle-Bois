using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionListManager : MonoBehaviour {
    
    [SerializeField]
    private GameObject missionTemplate;

    [SerializeField]
    private int[] intArray;

    //private string[] possibleText;

    private List<GameObject> missions;
    private List<string> possibleText;
    void Start()
    {
        possibleText = new List<string>();
        possibleText.Add("Find and fight the legendary Golden Beetle at Green Hill Zone");
        possibleText.Add("Challenge a gym leader in Macross City");
        possibleText.Add("PLACEHOLDER PLACEHOLDER THIS IS JUST A PLACEHOLDER");
        possibleText.Add("This is just a sample");
        possibleText.Add("OOOH MY GOD Bettle Lord Frank is nearby. KILLLLLLLLLL");
        possibleText.Add("I kindly request that you use your Beetle Boys to solve all the issues ");
        possibleText.Add("Go forth and challenge those that stand before you");
        possibleText.Add("Be the very best, like no one ever was");
        possibleText.Add("Kill 5 rats ");
        possibleText.Add("Conduct a raid in the aquaducts");








        missions = new List<GameObject>();
        if(missions.Count > 0)
        {
            foreach (GameObject mission in missions)
            {
                Destroy(mission.gameObject);
            }
            missions.Clear();
        }
        foreach(int i in intArray)
        {
            GameObject mission = Instantiate(missionTemplate) as GameObject;
            mission.SetActive(true);
            mission.GetComponent<MissionButton>().SetText(possibleText[ Random.Range(0,possibleText.Count-1)]);

            mission.transform.SetParent(missionTemplate.transform.parent, false);
        }
    }

    public void MissionClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }

}
