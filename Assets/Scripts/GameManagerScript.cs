using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSettings
{
    public static string Name;
    public static enumPlayerType Type;
}

public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayersStats;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Confined;

        this.PlayersStats.SetActive(false);

        PlayerSettings.Name = "WTF";
        PlayerSettings.Type = enumPlayerType.SapPlayer;
    }

    private void Update()
    {
        this.PlayersStats.SetActive(Input.GetKey(KeyCode.Tab) && this.PlayersStats != null);

        #region EXIT GAME

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        #endregion
    }
}
