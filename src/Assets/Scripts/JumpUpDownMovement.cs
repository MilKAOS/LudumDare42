using UnityEngine;

public class JumpUpDownMovement : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float xPos = Random.Range(-7, 7);

        if (transform.position.y < -6)
        {
            xPos = Random.Range(-7, 7);
            transform.position = new Vector2(xPos, -6);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
        }
    }    
}
