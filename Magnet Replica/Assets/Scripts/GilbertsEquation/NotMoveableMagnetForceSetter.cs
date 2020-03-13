using UnityEngine;

public class NotMoveableMagnetForceSetter : MonoBehaviour
{
    [SerializeField] private float magnetForce;
    private Magnet[] magnets;

    // We will try to get all the metals under this gameObject.
    private void Start()
    {
        magnets = GetComponentsInChildren<Magnet>();
    }

    // We can change the force for the metals for Gilberts equation, via this script.
    private void Update()
    {
        for (int i = 0; i < magnets.Length; i++)
        {
            magnets[i].magnetForce = magnetForce;
        }
    }
}
