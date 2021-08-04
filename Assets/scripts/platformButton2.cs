using UnityEngine;

public class platformButton2: MonoBehaviour
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
        if (collision.collider.tag == "player1")
        {
            gate.SetActive(true);
            print("coll");
        }
    }
}
