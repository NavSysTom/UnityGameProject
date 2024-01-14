using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public Transform playerPoint;

    private void Start()
    {
        spawnPlayer();
    }
    public void spawnPlayer() 
        //when this code gets called whenever the player goes between scenes, it will put him at the door of the apartment which is this x and y axis coordinate
        // so he doesn't spawn in the middle of the room when entering the house 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(2.85f, -0.56f, 0);
    }
}
