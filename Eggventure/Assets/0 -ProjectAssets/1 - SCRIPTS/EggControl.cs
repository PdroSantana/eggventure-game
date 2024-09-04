using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class EggControl : MonoBehaviour
{
    #region Basic Movement
    [Header("Basic Movement")]
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float pushForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private FloatingJoystick joystick;
    private Vector2 dir;
    #endregion


    #region Visuals and Sound Variables
    [Header("Graphics and Sounds")]
    [SerializeField] private Image transitionImage;
    [SerializeField] private SpriteRenderer damageIndicator;
    [SerializeField] private AudioSource hitGroundSFX;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource damageSFX;
    #endregion

    #region Coin Counter
    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI textCoinCount;
    private float coinCount = 0;

    #endregion

    #region CheckpointSys
    [Header("Respawn")]
    [SerializeField] private Transform spawn;
    private Transform currentSpawn;
    private bool isDead = false;
    private bool inTheEnd = false;
    #endregion
    void Start()
    {
        currentSpawn = spawn;
        playerRB.maxAngularVelocity = 5;
    }

    void Update()
    {
        //Debug.Log(playerRB.angularVelocity);
        #region Input Controls
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        if(joystick.Direction != new Vector2(0, 0))
		{
            dir = joystick.Direction;
        }
        


        //Movement();
        #endregion

        Respawn();
        

    }
    void LateUpdate()
	{
		
	}

    private void FixedUpdate()
    {
        //Movement();
        MoveBasedOnCamera();

        textCoinCount.text = coinCount.ToString();
       
    }
    private void loadendscene()
	{
        SceneManager.LoadScene(2);
    }
    private void Movement()
    {
        playerRB.AddForce(new Vector3(dir.x, 0, dir.y) * pushForce, ForceMode.Acceleration);
        //playerRB.velocity = pushForce * new Vector3(dir.x, 0, dir.y);
    }
    private void MoveBasedOnCamera()
	{
        //Get Plater Inputs
        float playerVerticalInput = dir.y;
        float playerHorizontalInput = dir.x ;

        // cira metores relativos a camera
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //cria vetores relativos a camera + inputs
        Vector3 forwardRelativeVeticalInput = playerVerticalInput * forward;
        Vector3 forwardRelativeHarizontalInput = playerHorizontalInput * right;

        Vector3 cameraRelativeMovement = forwardRelativeHarizontalInput + forwardRelativeVeticalInput;
        playerRB.AddForce(cameraRelativeMovement * pushForce, ForceMode.Acceleration);


    }
    private void Death()
    {
        hitGroundSFX.Play();
        damageSFX.Play();
    }
    public bool Interact(GameObject interactiveObj)
    {
        if (interactiveObj.tag == "Interactable")
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool IsInTheEnd()
	{
        return inTheEnd;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            isDead = true;
            
            Death();
        }

       /* if (collision.gameObject.tag == "Jumpad")
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        }*/
    }

    private void Respawn()
	{
        if (isDead) 
        { 
            isDead = false;
            inTheEnd = false;
            playerRB.transform.position = currentSpawn.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.tag == "Coin")
        {
            coinCount++;
            Destroy(other.gameObject);
        }
        if(other.tag == "End")
		{
            inTheEnd = true;
        }
        if(other.tag == "Opener")
        {
            inTheEnd = false;
        }
        if(other.tag == "Checkpoint")
        {
            currentSpawn = other.gameObject.GetComponent<Checkpoint>().getSpawnPos();
        }
        if(other.tag == "Jumpad")
        {
            other.GetComponent<ParticleActivation>().playParticle();
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        }
        if (other.tag == "CamTrigger")
        {
            Camera.main.GetComponent<NewCameraBehaviour>().ChangeAnchors(other);
        }
		if (other.tag == "Teleporter")
		{
            Debug.Log("Encostou teleporter");
            playerRB.transform.position = other.GetComponent<Teleporter>().GetDestiation().position;
            currentSpawn = other.GetComponent<Teleporter>().GetDestiation();
        }
        else
		{
            return;
		}


    }
    private void OnTriggerStay(Collider other)
    {

       
        if (other.tag == "CamTrigger")
        {
            //Debug.Log("changecam");
            Camera.main.GetComponent<NewCameraBehaviour>().ChangeAnchors(other);
        }
        else
        {
            return;
        }


    }

}
