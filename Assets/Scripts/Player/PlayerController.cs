using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    public bool isDashOn;
    public float dashCooldown = 2f;
    public float dashMaxDelay = .6f;
    private float dashTimer = 0;
    private float LeftDashDelayTimer, RightDashDelayTimer = 0;
    private int leftPresses, rightPresses = 0;

    public float hitCooldown = 2f;
    private float currHitCooldown;
    public int playerDmgEffectSpeed = 2;
    private int spriteFlicker = 0;

    public int health = 3;
    public Texture2D healthTexture;
    public int healthTextureSize = 50;
    public int healthTexturePadding = 4;

    private Rigidbody2D rb;
    private Vector3 lastPos;

    private Vector2 topRightCorner;
    private Vector2 edgeVector;
    private float playerSpriteSize;

    private KeyCode SHOOT = KeyCode.Space;
    protected List<KeyCode> MOVE_LEFT = new List<KeyCode>(){KeyCode.LeftArrow, KeyCode.J};
    protected List<KeyCode> MOVE_RIGHT = new List<KeyCode>(){KeyCode.RightArrow, KeyCode.L};
    protected List<KeyCode> MOVE_UP = new List<KeyCode>(){KeyCode.UpArrow, KeyCode.I};
    protected List<KeyCode> MOVE_DOWN = new List<KeyCode>(){KeyCode.DownArrow, KeyCode.K};

    private SpriteRenderer sr;

    // Audio stuff
    public Audiobank deathSound = null;
    public Audiobank hitSound = null;

    public List<string> damageTags = new List<string>();


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        lastPos = transform.position;

        topRightCorner = new Vector2(1, 1);
        edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        playerSpriteSize = transform.localScale.x;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 dirVector = Vector3.zero;
        if (keysPressed(MOVE_LEFT) && pos.x > -edgeVector.x+playerSpriteSize) { dirVector.x = -1; rightPresses = 0; }

        if (keysPressed(MOVE_RIGHT) && pos.x < edgeVector.x-playerSpriteSize) { dirVector.x = 1; leftPresses = 0; }

        if (keysPressed(MOVE_UP) && pos.y < edgeVector.y-playerSpriteSize) { dirVector.y = 1; leftPresses = rightPresses = 0; }

        if (keysPressed(MOVE_DOWN) && pos.y > -edgeVector.y+playerSpriteSize) { dirVector.y = -1; leftPresses = rightPresses = 0; }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPresses++;
            LeftDashDelayTimer = 0;
            if (LeftDashDelayTimer > dashMaxDelay)
                leftPresses = 0;
            if (leftPresses == 2 && dashTimer > dashCooldown)
                Dash(-1);

            Debug.Log("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPresses++;
            RightDashDelayTimer = 0;
            if (RightDashDelayTimer > dashMaxDelay)
                rightPresses = 0;
            if (rightPresses == 2 && dashTimer > dashCooldown)
                Dash(1);

            Debug.Log("Right");
        }

        rb.velocity = dirVector.normalized * speed;
        dirVector = Vector3.zero;

        currHitCooldown -= Time.deltaTime;
        if (currHitCooldown <= 0)
        {
            currHitCooldown = 0;
            sr.enabled = true;
        }
        else
        {
            // This switches player sprite on and off if player just took damage
            if ((int)Mathf.Floor((spriteFlicker % 60) / 30) == 0)
                sr.enabled = false;
            else
                sr.enabled = true;
        }

        dashTimer += Time.deltaTime;
        LeftDashDelayTimer += Time.deltaTime;
        RightDashDelayTimer += Time.deltaTime;
        spriteFlicker += playerDmgEffectSpeed;
    }

    private void Dash(int dir)
    {
        rb.position = (new Vector2(dir, transform.position.y));
        dashTimer = 0;
        leftPresses = rightPresses = 0;
    }

    private void OnGUI()
    {
        for (int i = 0; i < health; i++)
        {
            GUI.DrawTexture(new Rect(healthTexturePadding + i * healthTextureSize, Screen.height - healthTextureSize - healthTexturePadding, healthTextureSize, healthTextureSize), healthTexture);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (damageTags.Contains(other.gameObject.tag) && currHitCooldown <= 0)
        {
            spriteFlicker = 0;
            health--;
            if (health == 0)
            {
                deathSound.PlayOnce();
                SceneManager.LoadScene("SampleScene");
            }
            hitSound.PlayOnce();
            currHitCooldown = hitCooldown;
        }
    }

    private bool keysPressed(List<KeyCode> keycodes)
    {
        foreach (var keycode in keycodes)
        {
            if (Input.GetKey(keycode))
            {
                return true;
            }
        }
        return false;
    }

    private bool keysPressed(KeyCode keycode)
    {
        if (Input.GetKey(keycode))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
