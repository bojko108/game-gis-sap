using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public InputField PlayerNameField;
    public GameObject GISTeamTank;
    public GameObject SAPTeamTank;

    public string PlayerName
    {
        get { return LocalPlayerSettings.Name; }
        set { Debug.Log(value); LocalPlayerSettings.Name = value; }
    }
    
    public void SelectTeam(string team)
    {
        //this.GISTeamTank.transform.localScale *= team.Equals("GIS") ? 1.5f : 0.5f;
        //this.SAPTeamTank.transform.localScale *= team.Equals("GIS") ? 1.5f : 0.5f;

        switch (team)
        {
            case "SAP":
                this.GISTeamTank.transform.localScale = new Vector3(15f, 15f, 15f);
                this.SAPTeamTank.transform.localScale = new Vector3(60f, 60f, 60f);
                LocalPlayerSettings.Type = enumPlayerType.SapPlayer;
                break;
            default:
                this.GISTeamTank.transform.localScale = new Vector3(60f, 60f, 60f);
                this.SAPTeamTank.transform.localScale = new Vector3(15f, 15f, 15f);
                LocalPlayerSettings.Type = enumPlayerType.GisPlayer;
                break;
        }
    }
}
