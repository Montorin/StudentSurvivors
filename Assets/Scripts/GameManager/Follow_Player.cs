using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follow_Player : MonoBehaviour
{
    [SerializeField] GameObject player;
    //quick fix: Alt+Enter
    //auto format: hold ctrl+ press k, release, press D

    //public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        //transform.position = new Vector3(player.position.x , player.position.y, -10);
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float cameraZ = transform.position.z;

        transform.position = new Vector3(playerX, playerY, cameraZ);

    }
}
