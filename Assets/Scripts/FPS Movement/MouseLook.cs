using UnityEngine;
//using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    #region ----- Variables -----
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] Transform playerBody;
    [SerializeField] static bool cursorLockState;

    [Header("Camera")]
    [SerializeField] new Camera camera;
    [SerializeField] float defaultFOV;

    [Header("AutomaticView Setting")]
    [SerializeField] float moveSpeed = .05f;
    [SerializeField] float rotationSpeed = .05f;
    [SerializeField] float scrollSpeed = 1;
    [SerializeField] float minHeight = 0;
    [SerializeField] float maxHeight = 10;
    [SerializeField] KeyCode anchoredMoveKey;
    [SerializeField] KeyCode anchoredRotateKey;

    //[SerializeField] GameObject[] destroyOnNotMine;
    //private PhotonView photonView;
    //private PlayerMovement playerMovement;

    static bool automaticView;
    static bool mouseLookLocked;
    float xRotation = 0f;
    #endregion

    #region ----- Unity Methods -----
    void Start()
    {
        //photonView = GetComponentInParent<PhotonView>();
        //playerMovement = GetComponentInParent<PlayerMovement>();

        //if (playerMovement.usingPhoton) {
        //    InitWithPhoton();
        //} else {
        //    Init();
        //}
        cursorLockState = true;
        automaticView = false;
    }

    void Update() {
        //if (playerMovement.usingPhoton) {
        //    if (!photonView.IsMine) {
        //        return;
        //    }
        //}
        if (mouseLookLocked) {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (!automaticView) {
            FirstPersonPerspective(mouseX, mouseY);
        } else {
            AutomaticViewCamera(mouseX, mouseY);
        }
    }
    
    void AutomaticViewCamera(float mouseX, float mouseY) {

        // move

        Vector3 pos = transform.position;

        if (Input.GetKey(anchoredMoveKey)) {
            pos -= transform.right * mouseX;
            pos += transform.forward * -mouseY;
            pos.y = transform.position.y;
        }

        // zoom
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        pos += mouseScrollWheel * transform.forward * scrollSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);

        transform.position = pos;

        // rotate
        if (Input.GetKey(anchoredRotateKey)) {
            transform.RotateAround(transform.position, transform.right, -mouseY * rotationSpeed);
            transform.RotateAround(transform.position, Vector3.up, mouseX * rotationSpeed);
        }

        
    }

    void FirstPersonPerspective(float mouseX, float mouseY) {
        // Zoom Control
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollWheel > 0) {
            camera.fieldOfView--;
        } else if (mouseScrollWheel < 0) {
            camera.fieldOfView++;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Mouse2)) {
            camera.fieldOfView = defaultFOV;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    #endregion

    #region ----- Initialize -----
    //void InitWithPhoton() {
    //    if (!photonView.IsMine) {
    //        foreach (GameObject item in destroyOnNotMine) {
    //            Destroy(item);
    //        }
    //        Destroy(gameObject);
    //        return;
    //    }
    //}

    void Init() {
        // do something when init
    }

    public static void CursorInit(bool isLocked) {
        if (isLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        cursorLockState = isLocked;
    }
    #endregion

    #region ----- Switcher -----
    public void SwitchLockCursor() {
        cursorLockState = !cursorLockState;
        if (cursorLockState) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void LockMouseLook(bool locking) {
        mouseLookLocked = locking;
    }

    public static void AutomaticView(bool isAuto) {
        automaticView = isAuto;
        if (automaticView) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    #endregion
}
