using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    public GameObject playerHolder;
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public Cinemachine.CinemachineFreeLook thirdPersonCam;
    public Transform zoomedCameraPos;
    public Transform zoomedLookPos;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerHolder.transform.childCount; i++)
        {
            if (playerHolder.transform.gameObject.activeSelf == true && Input.GetMouseButtonUp(1))
            {
                player = playerHolder.transform.transform;
                rb = player.GetComponent<Rigidbody>();
                playerObj = player.transform.GetChild(1).transform;
                orientation = player.transform.GetChild(0).transform;
                thirdPersonCam.LookAt = player;
                thirdPersonCam.Follow = player;
                print(thirdPersonCam.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_ScreenY);
            }
        }

        //zoom in mode (still work in progress)
        if (Input.GetMouseButtonDown(1))
        {
            print("working");
            thirdPersonCam.transform.position = zoomedCameraPos.position;
            //thirdPersonCam.LookAt = zoomedLookPos;
            //thirdPersonCam.Follow = zoomedLookPos;
            thirdPersonCam.LookAt = player;
            thirdPersonCam.Follow = player;
        }


        // rotate orientation 
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        // rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
    }

}
