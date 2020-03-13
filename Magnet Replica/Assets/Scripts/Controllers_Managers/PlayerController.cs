using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask layerMask;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, rayLength, layerMask))
            {
                if (hit.collider.CompareTag("Draggable"))
                {
                    hit.collider.transform.GetComponent<Rigidbody>().transform.position = new Vector3(hit.point.x, hit.collider.transform.position.y, hit.point.z);
                }
            }
        }
    }
}
