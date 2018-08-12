using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Sprite partSprite;

    void Start()
    {        
        var sprites = Resources.LoadAll<Sprite>("Sprites/sprites");
        partSprite = sprites[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name == this.gameObject.name)
            {
                var pos = this.gameObject.transform.position;

                if (this.gameObject.name.StartsWith("rover_"))
                {
                    CreatePart("part_" + Guid.NewGuid(), pos, partSprite);
                    CreatePart("part_" + Guid.NewGuid(), pos, partSprite);
                    CreatePart("part_" + Guid.NewGuid(), pos, partSprite);
                    GameManager.Score(-3);
                    GameManager.Score(1);
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("rocket_"))
                {
                    CreatePart("part_" + Guid.NewGuid(), pos, partSprite);
                    CreatePart("part_" + Guid.NewGuid(), pos, partSprite);
                    GameManager.Score(-2);
                    GameManager.Score(1);
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.name.StartsWith("part_"))
                {
                    GameManager.Score(1);
                    Destroy(this.gameObject);
                }                
            }
        }
    }

    private GameObject CreatePart(string name, Vector3 position, Sprite sprite)
    {
        var part = new GameObject(name);
        part.transform.position = position;

        SpriteRenderer renderer = part.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        Rigidbody2D rigidbody2D = part.AddComponent<Rigidbody2D>();
        SetPartVelocity(rigidbody2D, position);

        /*BoxCollider2D boxCollider =*/ part.AddComponent<BoxCollider2D>();

        part.AddComponent<ClickManager>();

        return part;
    }

    private void SetPartVelocity(Rigidbody2D rigidbody2D, Vector3 pos)
    {
        float xVel = UnityEngine.Random.Range(-4, 4);
        float yVel = UnityEngine.Random.Range(9, 14);

        if (pos.x < -3)
            xVel = UnityEngine.Random.Range(-1, 6);
        if (pos.x > 3)
            xVel = UnityEngine.Random.Range(-6, 1);

        transform.position = new Vector2(pos.x, -6);

        rigidbody2D.velocity = new Vector2(xVel, yVel);
    }
}
