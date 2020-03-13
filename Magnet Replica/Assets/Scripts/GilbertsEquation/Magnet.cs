using UnityEngine;

public class Magnet : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    private string text = "All of these magnets were created, has same enum values, which is positive. "
        + "They will push each other. If you want to pull a magnet object, "
        + "you can add one with different enum value, or change one.";

    //This enum will be the critical point for gilberts equation. If different it will pull, otherwise it will push.
    public enum Polerization
    {
        Negative,
        Positive
    }

    public float magnetForce; //This is the the force for pulling and pushing.
    public Polerization polerization; //This is required for inspector selection.
    public Rigidbody rb; //We will move magnets with their rigidbody components.

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>(); //We attach it in here to make sure that is been attached. 
    }
}
