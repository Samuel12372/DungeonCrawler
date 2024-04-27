using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerActions : MonoBehaviour
{
    //movement
    public float walkSpeed = 5f;
    private Rigidbody rb;
	
    //health
    const float MaxHealth = 25f;
    public float health = MaxHealth;
    public Transform HealthBar;

    //dashing
    public float dashForce;

    //gun
    public Transform Gun;

    //Audio
    public AudioMixerSnapshot Game, Menu;
    public List<AudioClip> clips;
    private AudioSource sfx;

    //pause
    public GameObject PauseCanvas;
    public bool IsPaused;
    
	void Start() {
		rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null);
        sfx = GetComponent<AudioSource>();
	}
 
	void Update() 
    {
        //movement
		{ 
            rb.velocity = new Vector3(
                Mathf.Lerp(0, Input.GetAxis("Horizontal")* walkSpeed, 0.8f),
                rb.velocity.y,
                Mathf.Lerp(0, Input.GetAxis("Vertical")* walkSpeed, 0.8f)
            );
            if(Input.GetKeyDown(KeyCode.A))
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = true;
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = false;
            }
        }
        //dash
        {
            StartCoroutine(Dash());
        }
        //health
        {
            MeshRenderer mr = HealthBar.GetComponent<MeshRenderer>();
            Debug.Assert(mr != null);
            Material mat = mr.material;
            if(health <= 23f)
            {
                mat.color = Color.red;
            }
        }
        //pause and unpause
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                IsPaused =!IsPaused;
                PauseCanvas.SetActive(IsPaused);

                Time.timeScale = IsPaused ? 0 : 1;
            }
        }
	}
    //collisions
    void OnTriggerExit(Collider other)
    {
        // if (other.name == "SecretDoor2")
        // { 
        //     other.gameObject.AddComponent<Rigidbody>();
        // }
    }
    //dash
    IEnumerator Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            TrailRenderer tr = GetComponent<TrailRenderer>();
            tr.emitting = true;
            Vector3 dashDirection = DashDirection();
            rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
            //change for dashdistance
            yield return new WaitForSeconds(0.15f);
            tr.emitting = false;
        }
    }
    //dash direction
    Vector3 DashDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 dashDirection = Vector3.forward * verticalInput + Vector3.right * horizontalInput;
        dashDirection.y = 0f; 
        dashDirection.Normalize(); 
        return dashDirection;
    }
}
