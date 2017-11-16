using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionListManager : MonoBehaviour {

    [SerializeField]
    private GameObject missionTemplate;

    [SerializeField]
    private int[] intArray;

    private List<GameObject> missions;
    void Start()
    {
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
            mission.GetComponent<MissionButton>().SetText("Button #" + i);

            mission.transform.SetParent(missionTemplate.transform.parent, false);
        }
    }

    public void MissionClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }

}
