using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowwhitebox : MonoBehaviour
{
    public Transform player2;
    void Update()
    {
        transform.position = new Vector3(1, player2.position.y + 6,-1); // Camera follows the player but 6 to the right
    }
}
