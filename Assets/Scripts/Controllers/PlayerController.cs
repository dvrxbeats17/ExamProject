using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public 
    public Interactable Focus;
    //SerializeField
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask movementMask;
    //private
    private PlayerMotor _motor;

    private void Start()
    {
        mainCamera = Camera.main;
        _motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Movement();
    }

    private void Movement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                _motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null )
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != Focus)
        {
            if(Focus != null)
            {
                Focus.OnDefocus();
            }
            Focus = newFocus;
            _motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(Focus != null)
        {
            Focus.OnDefocus();
        }
        Focus = null;
        _motor.StopFollowingTarget();
    }
} 
