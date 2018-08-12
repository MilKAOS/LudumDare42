using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 1;
    public GUISkin Layout;  

    public Sprite roverSprite;
    public Sprite rocketSprite;

    private static float secondsBetweenSpawn = 3.0f;
    private static float elapsedTime = 4.0f;

    // Use this for initialization
    void Start()
    {
        var sprites = Resources.LoadAll<Sprite>("Sprites/sprites");
        roverSprite = sprites[0];
        rocketSprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
           
            int enemyType = UnityEngine.Random.Range(1, 3);
            CreateObject(enemyType);
            Score(-1);
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
        else if (PlayerScore >= 100)
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
        obj.transform.position = new Vector3(Screen.width / 2, 20, 10);

        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();

        switch (type)
        {
            case 1: // Rover
                renderer.sprite = roverSprite;
                obj.AddComponent<JumpUpDownMovement>();
                break;

            case 2: // Rocket
                renderer.sprite = rocketSprite;
                obj.AddComponent<JumpAroundMovement>();
                break;
        }
        
        Rigidbody2D rigidbody2D = obj.AddComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = obj.AddComponent<BoxCollider2D>();

        obj.AddComponent<ClickManager>();

        return obj;
    }

    private string GetName(int type)
    {
        switch (type)
        {
            case 1: // Rover
                return "rover_" + Guid.NewGuid();
            case 2: // Rocket
                return "rocket_" + Guid.NewGuid();
            default:
                return "blub";
        }
    }
}