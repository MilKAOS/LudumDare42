using UnityEngine;

public class JumpUpDownMovement : MonoBehaviour {

    GameObject bottom;

    // Use this for initialization
    void Start () {
        bottom = GameObject.Find("Bottom");
    }
	
	// Update is called once per frame
	void Update () {

        float xPos = Random.Range(-7, 7);

        //if (transform.position.y < -6)
        if (this.transform.position.y <= (bottom.transform.position.y + 1))
        {
            xPos = Random.Range(-7, 7);
            transform.position = new Vector2(xPos, bottom.transform.position.y + 1); // -6);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
        }
    }    
}
