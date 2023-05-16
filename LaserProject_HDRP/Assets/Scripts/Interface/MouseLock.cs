using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] private float mouseX=0;
    [SerializeField] private float mouseY=0;
    public float mouseSensitivity=100f;
    public Transform playerBody;
    private float xRotation = 0f;
    //private float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody.transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localRotation=Quaternion.Euler(Vector3.zero);
        //playerBody = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity* Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") *mouseSensitivity* Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0,0 );
        playerBody.Rotate(Vector3.up*mouseX);
        
        
    }
}
