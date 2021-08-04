using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowblackbox : MonoBehaviour
{
    public Transform player1;
    void Update()
    {
        transform.position = new Vector3(1, player1.position.y + 6, -1); // Camera follows the player but 6 to the right
    }
}
