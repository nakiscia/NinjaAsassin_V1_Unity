using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {


    public GameObject sword;
    public GameObject bow;

    Animator anim;
    CharController characterScript;
    public GameObject arrowPrefab;

    Rigidbody2D rigid;
    int gunState;


    // Use this for initialization

    public void Start()
    {
        anim = GetComponent<Animator>();
        characterScript = GetComponent<CharController>();
        rigid = GetComponent<Rigidbody2D>();




        gunState = 1;
        anim.SetInteger("gunState", gunState);
        ChangeGun();
    }

    public void ChangeWeaponButton()
    {
        gunState++;

        if (gunState > 2)
            gunState = 1;


        anim.SetInteger("gunState", gunState);
        ChangeGun();
    }

    void ChangeGun() {

        if (gunState == 1)
        {
            bow.SetActive(false);
            sword.SetActive(true);
        }
        if (gunState == 2)
        {
            sword.SetActive(false);
            bow.SetActive(true);
        }
    }


    public void runArrow(int value)
    {
        if (characterScript.rightFace)
        {
            GameObject tmp = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<ArrowController>().Initialize(Vector2.right);
        }
        else
        {

            GameObject tmp = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<ArrowController>().Initialize(Vector2.left);

        }

    }







}
