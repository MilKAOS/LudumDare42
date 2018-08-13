using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{       
    public Sprite rover1SpriteWreck1;
    public Sprite rover1SpriteWreck2;
    public Sprite rover1SpriteWreck3;    
    public Sprite rover2SpriteWreck1;
    public Sprite rover2SpriteWreck2;
    public Sprite rover2SpriteWreck3;    
    public Sprite rover3SpriteWreck1;
    public Sprite rover3SpriteWreck2;
    public Sprite rover3SpriteWreck3;    
    public Sprite rocketSpriteWreck1;
    public Sprite rocketSpriteWreck2;
    public Sprite rocketSpriteWreck3;

    private AudioManager audioManager;

    void Start()
    {
        rover1SpriteWreck1 = Resources.Load<Sprite>("Sprites/opportunity_front_128_w-1");
        rover1SpriteWreck2 = Resources.Load<Sprite>("Sprites/opportunity_front_128_w-2");
        rover1SpriteWreck3 = Resources.Load<Sprite>("Sprites/opportunity_front_128_w-3");
        rover2SpriteWreck1 = Resources.Load<Sprite>("Sprites/pathfinder_side_128_w-1");
        rover2SpriteWreck2 = Resources.Load<Sprite>("Sprites/pathfinder_side_128_w-2");
        rover2SpriteWreck3 = Resources.Load<Sprite>("Sprites/pathfinder_side_128_w-3");
        rover3SpriteWreck1 = Resources.Load<Sprite>("Sprites/spirit_front_128_w-1");
        rover3SpriteWreck2 = Resources.Load<Sprite>("Sprites/spirit_front_128_w-2");
        rover3SpriteWreck3 = Resources.Load<Sprite>("Sprites/spirit_front_128_w-3");
        rocketSpriteWreck1 = Resources.Load<Sprite>("Sprites/falcon9_128_w-1");
        rocketSpriteWreck2 = Resources.Load<Sprite>("Sprites/falcon9_128_w-2");
        rocketSpriteWreck3 = Resources.Load<Sprite>("Sprites/falcon9_128_w-3");

        var crosshair = GameObject.Find("Crosshair");
        audioManager = crosshair.GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name == this.gameObject.name)
            {
                var pos = this.gameObject.transform.position;

                if (this.gameObject.name.StartsWith("rover1_"))
                {
                    audioManager.DoAudioShot();
                    audioManager.DoAudioExplosion();

                    DoExplosion(pos);
                    GameManager.Score(1);

                    CreatePart("part_" + Guid.NewGuid(), pos, rover1SpriteWreck1);
                    CreatePart("part_" + Guid.NewGuid(), pos, rover1SpriteWreck2);
                    CreatePart("part_" + Guid.NewGuid(), pos, rover1SpriteWreck3);
                    GameManager.Score(-1);

                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("rover2_"))
                {
                    audioManager.DoAudioShot();
                    audioManager.DoAudioExplosion();

                    DoExplosion(pos);
                    GameManager.Score(1);

                    CreatePart("part_" + Guid.NewGuid(), pos, rover2SpriteWreck1);
                    CreatePart("part_" + Guid.NewGuid(), pos, rover2SpriteWreck2);
					CreatePart("part_" + Guid.NewGuid(), pos, rover2SpriteWreck3);
                    GameManager.Score(-1);
                                        
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("rover3_"))
                {
                    audioManager.DoAudioShot();
                    audioManager.DoAudioExplosion();

                    DoExplosion(pos);
                    GameManager.Score(1);

                    CreatePart("part_" + Guid.NewGuid(), pos, rover3SpriteWreck1);
                    CreatePart("part_" + Guid.NewGuid(), pos, rover3SpriteWreck2);
                    CreatePart("part_" + Guid.NewGuid(), pos, rover3SpriteWreck3);
                    GameManager.Score(-1);
                                        
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("rocket_"))
                {
                    audioManager.DoAudioShot();
                    audioManager.DoAudioExplosion();

                    DoExplosion(pos);
                    GameManager.Score(1);

                    CreatePart("part_" + Guid.NewGuid(), pos, rocketSpriteWreck1);
                    CreatePart("part_" + Guid.NewGuid(), pos, rocketSpriteWreck2);
					CreatePart("part_" + Guid.NewGuid(), pos, rocketSpriteWreck3);
                    GameManager.Score(-1);
                    
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("part_"))
                {
                    audioManager.DoAudioShot();
                    audioManager.DoAudioExplosion();

                    DoExplosion(pos);
                    GameManager.Score(1);                    
                    
                    Destroy(this.gameObject);
                }                
            }
			else {
				audioManager.DoAudioShot();
			}
        }
    }

    private GameObject CreatePart(string name, Vector3 position, Sprite sprite)
    {
        var part = new GameObject(name);
        part.transform.position = position;
        //part.transform.localScale = new Vector3(0.1f, 0.1f, 1);

        SpriteRenderer renderer = part.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        Rigidbody2D rigidbody2D = part.AddComponent<Rigidbody2D>();
        SetPartVelocity(rigidbody2D, position);

        /*BoxCollider2D boxCollider =*/ part.AddComponent<PolygonCollider2D>();

        part.AddComponent<ClickManager>();

        return part;
    }

    private void SetPartVelocity(Rigidbody2D rigidbody2D, Vector3 pos)
    {
        float xVel = UnityEngine.Random.Range(-4, 4);
        float yVel = UnityEngine.Random.Range(7, 12);

        if (pos.x < -3)
            xVel = UnityEngine.Random.Range(-1, 6);
        if (pos.x > 3)
            xVel = UnityEngine.Random.Range(-6, 1);

        transform.position = new Vector2(pos.x, -6);

        rigidbody2D.velocity = new Vector2(xVel, yVel);
    }

    private void DoExplosion(Vector3 pos)
    {
        var rnd = UnityEngine.Random.Range(1, 15);
        var effectName = "";

        switch (rnd)
        {
            case 1:
                effectName = "Effects/WFX_Explosion";
                break;
            case 2:
                effectName = "Effects/WFX_Explosion LandMine";
                break;
            case 3:
                effectName = "Effects/WFX_Explosion Simple";
                break;
            case 4:
                effectName = "Effects/WFX_Explosion Small";
                break;
            case 5:
                effectName = "Effects/WFX_Explosion StarSmoke";
                break;
            case 6:
                effectName = "Effects/WFX_ExplosiveSmoke";
                break;
            case 7:
                effectName = "Effects/WFX_ExplosiveSmoke Big";
                break;
            case 8:
                effectName = "Effects/WFX_ExplosiveSmoke Big Alt";
                break;
            case 9:
                effectName = "Effects/WFX_ExplosiveSmoke Small";
                break;
            case 10:
                effectName = "Effects/WFX_ExplosiveSmokeGround";
                break;
            case 11:
                effectName = "Effects/WFX_ExplosiveSmokeGround Big";
                break;
            case 12:
                effectName = "Effects/WFX_ExplosiveSmokeGround Big Alt";
                break;
            case 13:
                effectName = "Effects/WFX_ExplosiveSmokeGround Small";
                break;
            case 14:
                effectName = "Effects/WFX_Nuke";
                break;            
        }

        var effect = Resources.Load<GameObject>(effectName);
        effect.transform.position = pos;
        Instantiate(effect);        
    }    
}
