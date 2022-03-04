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

    //[SerializeField] GameObject[] destroyOnNotMine;
    //private PhotonView photonView;
    //private PlayerMovement playerMovement;

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
    #endregion
}
