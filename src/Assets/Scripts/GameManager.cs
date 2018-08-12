using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public GUISkin Layout;  

    public Sprite rover1Sprite;
    public Sprite rover2Sprite;
    public Sprite rover3Sprite;
    public Sprite rocketSprite;

    private static float secondsBetweenSpawn = 3f;
    private static float elapsedTime = 4.0f;

    private static bool isGameStarted = false;

    // Use this for initialization
    void Start()
    {        
        rover1Sprite = Resources.Load<Sprite>("Sprites/opportunity_front_512");
        rover2Sprite = Resources.Load<Sprite>("Sprites/pathfinder_side_512");
        rover3Sprite = Resources.Load<Sprite>("Sprites/spirit_front_512");
        rocketSprite = Resources.Load<Sprite>("Sprites/falcon9_512");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
           
            int enemyType = UnityEngine.Random.Range(1, 5);
            CreateObject(enemyType);
            Score(-1);

            isGameStarted = true;
        }
    }

    void OnGUI()
    {
        GUI.skin = Layout;
        GUI.Label(new Rect(Screen.width / 2 + 375 + 12, 20, 100, 100), "" + PlayerScore);
        
        if (PlayerScore <= -100)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "HUMANITY WINS, YOU LOSE!");            
        }        
        else if (isGameStarted && PlayerScore == 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "MARS WINS!");
        }
    }

    public static void Score(int value)
    {        
        PlayerScore += value;

        //if (PlayerScore1 == 10 || PlayerScore2 == 10)
        //    ballAudioSource.PlayOneShot(Resources.Load<AudioClip>("win"));
        //else
        //    ballAudioSource.PlayOneShot(Resources.Load<AudioClip>("out"));
    }

    private GameObject CreateObject(int type)
    {       
        var obj = new GameObject(GetName(type));

        var xPos = UnityEngine.Random.Range(-7, 7);        
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();

        switch (type)
        {
            case 1: // Rover Opportunity
                renderer.sprite = rover1Sprite;
                obj.transform.position = new Vector3(xPos, -6, 0);
                break;

            case 2: // Rover Pathfinder
                renderer.sprite = rover2Sprite;
                obj.transform.position = new Vector3(xPos, -6, 0);
                break;

            case 3: // Rover Spirit
                renderer.sprite = rover3Sprite;
                obj.transform.position = new Vector3(xPos, -6, 0);
                break;

            case 4: // Rocket
                renderer.sprite = rocketSprite;
                obj.transform.position = new Vector3(xPos, 15, 0);
                break;
        }

        SetMovement(obj, type);

        var rigidbody = obj.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0.5f;

        obj.AddComponent<PolygonCollider2D>();

        obj.AddComponent<ClickManager>();

        return obj;
    }

    private string GetName(int type)
    {
        switch (type)
        {
            case 1: // Rover
                return "rover1_" + Guid.NewGuid();
            case 2: // Rover
                return "rover2_" + Guid.NewGuid();
            case 3: // Rover
                return "rover3_" + Guid.NewGuid();
            case 4: // Rocket
                return "rocket_" + Guid.NewGuid();
            default:
                return "blub";
        }
    }


    private void SetMovement(GameObject obj, int type)
    {
        int movementType = UnityEngine.Random.Range(1, 3);

        switch (type)
        {
            case 1:
                if (movementType == 1)
                    obj.AddComponent<JumpUpDownMovement>();
                else
                    obj.AddComponent<JumpAroundMovement>();
                break;
            case 2:
                if (movementType == 1)
                    obj.AddComponent<JumpUpDownMovement>();
                else
                    obj.AddComponent<JumpAroundMovement>();
                break;
            case 3:
                if (movementType == 1)
                    obj.AddComponent<JumpUpDownMovement>();
                else
                    obj.AddComponent<JumpAroundMovement>();
                break;
            case 4: // Rocket no special movement
                break;
        }        
    }
}