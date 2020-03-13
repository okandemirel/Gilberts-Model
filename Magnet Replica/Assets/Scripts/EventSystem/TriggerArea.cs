using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] ProgressBar progressBar;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            EventSystemCode.current.ObjectHitHole();
            other.gameObject.layer = 12;
            other.gameObject.SetActive(false);
            progressBar.UpdateProgress(.066f);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.layer = 0;
        }
    }
}
