using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject playerDeathPrefab;
    public AudioClip deathClip;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //1 Confirm the collision object has the player tag
        if(coll.transform.tag == "Player")
        {
            //2 Confirm there is an audio clip and it is valid if so play death clip
            var audioSource = GetComponent<AudioSource>();
            if(audioSource != null && deathClip != null)
            {
                audioSource.PlayOneShot(deathClip);
            }
            //3 Instatiate the deathprefab at the collision point and swap the saw blade with the hitSprite version
            Instantiate(playerDeathPrefab, coll.contacts[0].point, Quaternion.identity);
            spriteRenderer.sprite = hitSprite;
            //4 Destroy the colliding object (should be the player)
            Destroy(coll.gameObject);
     
            // the 1.25 sec delay should be enough to see the particle effect on death
            GameManager.instance.RestartLevel(1.25f);
        }
    }

}
