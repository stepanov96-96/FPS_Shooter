using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool playerAtack = false;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private float groundDistance = 0.4f;

    [SerializeField]
    private float jumpHeight = 3f;

       
    [SerializeField]
    private GameObject[] TrajectoryLine;

    private Vector3 velosity;

    private bool isGrounded;

    private void Awake()
    {
        playerAtack = false;
    }

    private void Update()
    {

        MoovePlayer();

        if (!playerAtack)
        {
            JumpPlayer();
        }
        
        AccelerateAndSquat();

        PlayerShoot();

    }

    #region controller
    void AccelerateAndSquat()
    {
        if (Input.GetKey(KeyCode.C))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else
        {
            speed = 10;
        }
    }

    void MoovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velosity.y < 0)
        {
            velosity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!playerAtack)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        velosity.y += gravity * Time.deltaTime;
        controller.Move(velosity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velosity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

    void PlayerShoot()
    {
        if (Input.GetMouseButtonDown(0) && GrenadeChoice.addGrenade[GrenadeChoice.currentItem] > 0)
        {

            if (isGrounded)
            {
                for (int i = 0; i < TrajectoryLine.Length; i++)
                {
                    //print("print");
                    TrajectoryLine[i].SetActive(true);
                }

            }

            playerAtack = true;
        }
        //else
        //    UIScripts.Instance.AddAmmunition();
    }
    #endregion

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Granate")
        {
            GrenadeChoice.addGrenade[0]++;
            GrenadeChoice.Instance.NumberGrenade();
            Destroy(other.gameObject);
        }

        if (other.tag == "Granate1")
        {
            GrenadeChoice.addGrenade[1]++;
            GrenadeChoice.Instance.NumberGrenade();
            Destroy(other.gameObject);
        }

        if (other.tag == "Granate2")
        {
            GrenadeChoice.addGrenade[2]++;
            GrenadeChoice.Instance.NumberGrenade();
            Destroy(other.gameObject);
        }
    }
}
