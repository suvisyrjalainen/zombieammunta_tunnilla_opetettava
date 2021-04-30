using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public float speed = 5.0f;

    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public float hyppyvoima = 0f;
    public float painovoima = 0f;

    private bool isGrounded = true;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * 3;

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hyppy");

            nopeus.y += hyppyvoima;
            anim.SetBool("JumpU", true);
        }
        else
        {
            anim.SetBool("JumpU", false);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("hyppy");

            nopeus.y += hyppyvoima;
            anim.SetBool("JumpR", true);
        }
        else
        {
            anim.SetBool("JumpR", false);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("hyppy");

            nopeus.y += hyppyvoima;
            anim.SetBool("JumpL", true);
        }
        else
        {
            anim.SetBool("JumpL", false);
        }




        nopeus.y = nopeus.y - painovoima * Time.deltaTime;

        hahmokontrolleri.Move(nopeus * Time.deltaTime);


        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);

            if (Input.GetKeyDown("left shift"))
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        

    }

    
}
