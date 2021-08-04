using UnityEngine;

public class platformButton : MonoBehaviour
{
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "player2")
        {
            gate.SetActive(true);
            print("coll");
        }
    }
}
