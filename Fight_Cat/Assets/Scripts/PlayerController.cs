using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float speed;

    private PhotonView PV;
    public PhotonView _PV
    {
        get { return PV; }
    }
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private int _hp;
    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    [SerializeField] private int _score;
    public int Score
    {
        get { return _score; }  
        set { _score = value; }
    }

    public WeaponType _myWeapon;

    private void Awake()
    {
        if (PV == null)
        {
            PV = GetComponent<PhotonView>();
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (PV.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * speed * Time.deltaTime;
        }
        Animation_Control();
    }

    private void FixedUpdate()
    {
        
    }

    void Animation_Control()
    {
        if (PV.IsMine)
        {
            #region GetKeyDown
            // UP
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("Up", true);
                anim.SetBool("Side", false);
                anim.SetBool("Down", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            // Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("Side", true);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            // Down
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("Down", true);
                anim.SetBool("Side", false);
                anim.SetBool("Up", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            // Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                anim.SetBool("Down", false);
                anim.SetBool("Side", true);
                anim.SetBool("Up", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            #endregion
            #region GetKeyUp
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }
            #endregion
            #region GetKey
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            #endregion
            #region Space

            #endregion
        }
    }
}
