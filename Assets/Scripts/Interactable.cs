using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public
    public float Radius = 3f;
    public Transform InteractionTransform;
    //private
    private bool _isFocus = false;
    private bool _hasIntercted = false;
    private Transform _player;

    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }

    private void Update()
    {
        if (_isFocus && !_hasIntercted)
        {
            float distance = Vector3.Distance(_player.position, InteractionTransform.position);
            if(distance <= Radius)
            {
                Interact();
                _hasIntercted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        _isFocus = true;
        _player = playerTransform;
        _hasIntercted = false;
    }
    public void OnDefocus()
    {
        _isFocus = false;
        _player = null;
        _hasIntercted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(InteractionTransform == null)
            InteractionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, Radius);
    }
}
