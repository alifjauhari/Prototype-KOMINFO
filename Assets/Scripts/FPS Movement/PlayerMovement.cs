//using Photon.Pun;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region ----- Enums -----
    public enum MovementType { TPP, FPP, AutomaticView }

    #endregion

    #region ------ Variables ------

    [Header("Movement")]
    [SerializeField] MovementType movementType;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f;
    [SerializeField] float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("Camera")]
    [SerializeField] bool lockCursor = true;
    [SerializeField] Transform rootCameraPosition;
    [SerializeField] GameObject cam;
    [SerializeField] Transform parentSwitch;
    [SerializeField] GameObject cinemachine;

    [Header("Disable When Switch Movement Type")]
    [SerializeField] GameObject[] turnOffWhenTPP;
    [SerializeField] GameObject[] turnOffWhenFPP;

    [Header("Jump")]
    [SerializeField] float gravity = -9.81f;
    [SerializeField] bool usingJump = false;
    [SerializeField] float jumpHeight = 3f;
    
    [Header("Animation"), Space(10)]
    [Space(5)] public bool usingAnimation;
    [SerializeField] Animator targetAnimator;
    [SerializeField] bool usingWalkAnimation;

    [Header("UI"), Space(10)]
    [SerializeField] TextMeshProUGUI movementTypeText;

    [Header("Photon")]
    public bool usingPhoton;
    [SerializeField] GameObject[] disableOnNotMine;

    //private PhotonView photonView;

    Vector3 velocity;
    bool isGrounded;

    #endregion

    #region ----- Unity Methods -----
    private void Awake() {
        if (usingPhoton) {
            //InitWithPhoton();
        } else {
            Init();
        }
    }

    void FixedUpdate() {
        //if (usingPhoton) {
        //    if (!photonView.IsMine)
        //        return;
        //}

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        switch (movementType) {
            case MovementType.TPP:
                TppMovement(x, z);
                break;

            case MovementType.FPP:
                FppMovement(x, z);
                break;

            case MovementType.AutomaticView:
                AutoViewMovement(x, z);
                break;

            default:
                return;
        }

        if (usingJump) {
            if (Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        if (!usingAnimation)
            return;

        if (!usingWalkAnimation)
            return;

        if (x != 0 || z != 0) {
            targetAnimator.gameObject.GetComponent<AnimatorPlayer>().SetSpeed(true);
        } else {
            targetAnimator.gameObject.GetComponent<AnimatorPlayer>().SetSpeed(false);
        }
    }

    void TppMovement(float x, float z) {
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        // rotate and move player based on the direction
        if (direction.magnitude >= .1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        SetupCinemachine();
    }

    void FppMovement(float x, float z) {
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void AutoViewMovement(float x, float z) {
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        // rotate and move player based on the direction
        if (direction.magnitude >= .1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }

    #endregion

    #region ----- Initialize ------

    void InitMovement() {
        switch (movementType) {
            case MovementType.TPP:
                // disable mouselook script so player will use camera cihemachine instead
                MouseLook.LockMouseLook(true);
                MouseLook.AutomaticView(false);

                // enable cinemachine
                cinemachine.SetActive(true);

                // disable all object on in the turnOffWhenTPP
                foreach (GameObject item in turnOffWhenTPP) {
                    item.SetActive(false);
                }

                // enable all object on in the turnOffWhenFPP
                foreach (GameObject item in turnOffWhenFPP) {
                    item.SetActive(true);
                }
                break;

            case MovementType.FPP:
                // enable mouselook script so player will this camera
                MouseLook.LockMouseLook(false);
                MouseLook.AutomaticView(false);
                cam.transform.SetParent(transform);

                // disable cinemachine
                cinemachine.SetActive(false);

                // disable all object on in the turnOffWhenFPP
                foreach (GameObject item in turnOffWhenFPP) {
                    item.SetActive(false);
                }

                // enable all object on in the turnOffWhenTPP
                foreach (GameObject item in turnOffWhenTPP) {
                    item.SetActive(true);
                }

                // set camera to the head of avatar
                cam.transform.position = rootCameraPosition.position;
                
                break;

            case MovementType.AutomaticView:
                // enable mouselook script so player will this camera
                MouseLook.LockMouseLook(false);
                MouseLook.AutomaticView(true);

                cam.transform.SetParent(parentSwitch);

                // disable cinemachine
                cinemachine.SetActive(false);

                // disable all object on in the turnOffWhenTPP
                foreach (GameObject item in turnOffWhenTPP) {
                    item.SetActive(false);
                }

                // enable all object on in the turnOffWhenFPP
                foreach (GameObject item in turnOffWhenFPP) {
                    item.SetActive(true);
                }

                // set camera to the head of avatar
                cam.transform.position = rootCameraPosition.position + new Vector3(0f, 5f, -2f);
                cam.transform.LookAt(rootCameraPosition);
                break;
            default:
                break;
        }
        UpdateTextDebug();
    }

    void UpdateTextDebug() {
        if (movementTypeText == null) return;

        movementTypeText.text = movementType.ToString();
    }

    //void InitWithPhoton() {
    //    photonView = GetComponent<PhotonView>();
    //    if (!photonView.IsMine) {
    //        foreach (GameObject item in disableOnNotMine) {
    //            item.SetActive(false);
    //        }
    //    } else {
    //        cinemachine = GameObject.FindGameObjectWithTag("Cinemachine");
    //        InitMovement();
    //        if (lockCursor) {
    //            Cursor.lockState = CursorLockMode.Locked;
    //        }
    //    }
    //}

    void Init() {
        cinemachine = GameObject.FindGameObjectWithTag("Cinemachine");
        MouseLook.CursorInit(lockCursor);
        InitMovement();
        
    }

    #endregion

    #region ------ Cinemachine ------
    void SetupCinemachine() {
        CinemachineFreeLook CM = cinemachine.GetComponent<CinemachineFreeLook>();
        CM.Follow = gameObject.transform;
        CM.LookAt = rootCameraPosition;
    }

    bool isCinemachineLocked = true;

    public void SwitchCinemachineLock() {
        //if (usingPhoton) {
        //    if (!photonView.IsMine) {
        //        return;
        //    }
        //}

        if (movementType != MovementType.TPP) {
            return;
        }

        isCinemachineLocked = !isCinemachineLocked;
        if (isCinemachineLocked) {
            cinemachine.SetActive(true);
        } else {
            cinemachine.SetActive(false);
        }
    }

    #endregion

    #region ----- Switcher -----
    public void SwitchMovementType() {
        //if (usingPhoton) {
        //    if (!photonView.IsMine) {
        //        return;
        //    }
        //}

        switch (movementType) {
            case MovementType.TPP:
                movementType = MovementType.FPP;
                break;
            case MovementType.FPP:
                movementType = MovementType.TPP;
                break;
        }
        InitMovement();
    }

    public void ChooseMovementType(string type) {

        switch (type.Trim()) {
            case "FPP":
                movementType = MovementType.FPP;
                break;
            case "TPP":
                movementType = MovementType.TPP;
                break;
            case "AUTO":
                movementType = MovementType.AutomaticView;
                break;
            default:
                Debug.Log($"There's no movement type [{type}]");
                break;
        }
        
        InitMovement();
    }
    #endregion
}
