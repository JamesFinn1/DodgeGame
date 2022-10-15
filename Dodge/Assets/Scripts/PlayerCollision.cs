using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Text livesText;
    [SerializeField] private Text coinCounter;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private PlayerMovement playerMovment; // For increasing the back to forth speed
    [SerializeField] private PlayerInput playerInput; // For increasing the playermovemnt speed as the game goes on
    [SerializeField] private ProgressionBar progressionBar; // For collsion to handle progress bar
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite mainSprite; // Main player sprite
    [SerializeField] private Sprite newSprite; // Sprite to change to when taken damage

    // Variables interacting with other classes
    [SerializeField] private DamageFlash damageFlash; // For damage representation
    [SerializeField] private DeployFireballs deployFireballs; // To access fireballs being spawned
    [SerializeField] private SpawnPrfab spawnFireballPrefab;

    private int livesRemaining;
    private int coinCount;
    private float playerMovmentSpeed;
    private float fireballRespawnTime;
    private float fireballVelocity;

    // Damage Delay variables
    [SerializeField] private float DamageDelayTime = 10.0f;
    bool isDamageable;
    bool isInvincible;

    public int CoinCount
    {
        get { return coinCount; }
    }
    private void Awake()
    {
        livesText.text = "3";
        livesRemaining = 3;
        coinCounter.text = "0";
        coinCount = 0;
        fireballVelocity = 10f;
    }

    private void Start()
    {
        fireballRespawnTime = deployFireballs.RespawnTime;
        playerMovmentSpeed = playerInput.PlayerMovmentSpeed;
        isDamageable = true;
        isInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Damage"))
        {
            if(isInvincible) { }
            else if (isDamageable)
            {
                DoDamageToPlayer();
                isDamageable = false;
                
                if(livesRemaining == 0) { }
                else
                    this.CallWithDelay(SetIsDamageable, DamageDelayTime);
            }
            else
                Debug.Log("Player not damageable");
            
        }
        else if(collider.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            coinCounter.text = coinCount.ToString();

            if(coinCount % 10 == 0) { // For every 10 coins collected
                if(fireballRespawnTime <= 0.3f) { Debug.Log("Fireball respawn is 0.4 the max!"); }
                else {
                    livesRemaining += 2; livesText.text = livesRemaining.ToString();
                    fireballRespawnTime -= 0.1f;
                }
                if (fireballVelocity <= 200.0f)
                {
                    spawnFireballPrefab.FireBallSpeed = fireballVelocity += 20f;
                    deployFireballs.RespawnTime = fireballRespawnTime;
                    playerMovmentSpeed += 1.5f;
                    playerInput.PlayerMovmentSpeed = playerMovmentSpeed;
                }
                else if (coinCount >= 150)
                {
                    spawnFireballPrefab.FireBallSpeed = fireballVelocity += 100f;
                }

            } // End if for increase of 10
            Destroy(collider); // Removes coin once player collides with coin
        }
        else if(collider.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Gem Collected!");
           
            progressionBar.SetProgressionMax(1f);
            progressionBar.ProgressBarCurrentTime = 0f;
            progressionBar.DisplayProgressBar();// Puts bar on screen

            spriteRenderer.sprite = newSprite;
            isInvincible = true; // Making player Invincible after gem pickup

            playerMovment.LerpMovementSpeed = 0.5f;
            playerInput.PlayerMovmentSpeed += 10;

            // Removes bar from screen with given time
            this.CallWithDelay(RemoveProgressBar, progressionBar.ProgressBarTime);

            Destroy(collider);
        }
    }

    // Damage the player function
    private void DoDamageToPlayer()
    {
        livesRemaining--; // Remove a life
        livesText.text = livesRemaining.ToString(); // Update text widget on screen

        damageFlash.Flash(); // Makes player sprite change color to indicate damage taken

        if (livesRemaining == 0) // Game over condition
        {
            levelManager.DisplayGameOver();
            PlayerDied();
        }
    }

    public void RemoveProgressBar()
    {
        progressionBar.gameObject.SetActive(false);
        isInvincible = false;
        spriteRenderer.sprite = mainSprite;
        playerMovment.LerpMovementSpeed = 0.3f;
        playerInput.PlayerMovmentSpeed -= 10;
    }

    private void PlayerDied()
    {
        gameObject.SetActive(false);
    }

    private void SetIsDamageable()
    {
        isDamageable = true;
    }


}
