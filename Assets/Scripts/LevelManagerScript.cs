using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalPlayerSettings
{
    public static string Name;
    public static bool IsLocalPlayer;
    public static enumPlayerType Type;
    public static string Tag
    {
        get
        {
            switch (Type)
            {
                case enumPlayerType.GisPlayer:
                    return Resources.Tags.GisPlayer;
                default:
                    return Resources.Tags.SapPlayer;
            }
        }
    }

    public static int Layer
    {
        get
        {
            switch (Type)
            {
                case enumPlayerType.GisPlayer:
                    return LayerMask.NameToLayer(Resources.Layers.GisPlayers);
                default:
                    return LayerMask.NameToLayer(Resources.Layers.SapPlayers);
            }
        }
    }
}

public class LevelManagerScript : MonoBehaviour
{
    public GameObject PlayersStats;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Confined;

        this.PlayersStats.SetActive(false);
    }

    private void Update()
    {
        this.PlayersStats.SetActive(Input.GetKey(KeyCode.Tab) && this.PlayersStats != null);

        #region EXIT GAME

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

            // or load MenuScene?
        }

        #endregion

        #region UPDATE STATS

        if (Time.frameCount % 30 == 0)
        {
            this.UpdateStats(Resources.Tags.GisPlayer);
            this.UpdateStats(Resources.Tags.SapPlayer);
        }

        #endregion
    }

    private void UpdateStats(string playersTag)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playersTag);

        for (int i = 0; i < players.Length; i++)
        {

        }
    }
}