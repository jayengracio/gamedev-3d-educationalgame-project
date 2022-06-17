using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float dist = 3f;

    [SerializeField]
    private LayerMask layerMask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // clear message when not looking at interactable
            playerUI.UpdateText(string.Empty);

            // Creates a ray (of line) at the centre of the camera that shoots outwards
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            // debug
            Debug.DrawRay(ray.origin, ray.direction * dist);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, dist, layerMask))
            {
                if (raycastHit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                    playerUI.UpdateText(interactable.promptMessage);
                    if (inputManager.onFoot.Interact.triggered)
                    {
                        interactable.BaseInteract();
                    }
                }
            }
        }

    }
}
