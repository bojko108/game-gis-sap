using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum enumPlayerType
{
    GisPlayer,
    SapPlayer
}

public class SetupLocalPlayer : NetworkBehaviour
{
    public string PlayerName;

    private void Start()
    {
        PlayerSettings.IsLocalPlayer = this.isLocalPlayer;

        if (this.isLocalPlayer)
        {
            GameObject camera = Camera.main.gameObject;
            camera.transform.position = new Vector3(0f, 3f, -6f);
            camera.transform.rotation = Quaternion.Euler(5f, 0f, 0f);
            camera.transform.parent = this.transform;

            this.GetComponent<TankControlScript>().enabled = true;
            this.GetComponent<TankShooting>().enabled = true;
            this.GetComponent<TankHealthScript>().enabled = true;
        }
        else
        {
            this.GetComponent<TankControlScript>().enabled = false;
            this.GetComponent<TankShooting>().enabled = false;
            this.GetComponent<TankHealthScript>().enabled = false;

            GameObject canvas = this.gameObject.FindChildrenByName(Resources.Various.UI)[0];

            if (canvas)
            {
                Vector3 position = canvas.transform.position;
                position.y += 2f;

                canvas.transform.position = position;
            }
        }

        this.SetupPlayer(PlayerSettings.Name, PlayerSettings.Type);
    }

    private void SetupPlayer(string name, enumPlayerType playerType)
    {
        Color color = Color.white;

        this.gameObject.tag = PlayerSettings.Tag;
        this.gameObject.SetLayerRecursively(PlayerSettings.Layer);

        switch (playerType)
        {
            case enumPlayerType.GisPlayer:
                //this.tag = Resources.Tags.GisPlayer;
                color = Color.green;
                break;
            case enumPlayerType.SapPlayer:
                //this.tag = Resources.Tags.SapPlayer;
                color = Color.red;
                break;
        }

        this.SetColor(this.gameObject.FindChildrenByName(Resources.Various.TankChassis)[0], color);
        this.SetColor(this.gameObject.FindChildrenByName(Resources.Various.TankTracksLeft)[0], color);
        this.SetColor(this.gameObject.FindChildrenByName(Resources.Various.TankTracksRight)[0], color);
        this.SetColor(this.gameObject.FindChildrenByName(Resources.Various.TankTurret)[0], color);
    }

    private void SetColor(GameObject gameObject, Color color)
    {
        if (gameObject)
            gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}