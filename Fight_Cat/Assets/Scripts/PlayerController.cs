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

    private void Awake()
    {
        if (PV == null)
        {
            PV = GetComponent<PhotonView>();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
            transform.position += input.normalized * speed * Time.deltaTime;
        }
    }

    void Control()
    {

    }
}
