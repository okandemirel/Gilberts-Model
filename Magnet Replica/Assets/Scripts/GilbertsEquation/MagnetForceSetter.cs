using UnityEngine;

[System.Serializable]
public class MagnetForceSetter : MonoBehaviour
{
    [Header("Magnet Force Value")]
    [Range(4, 1000)]
    public float magnetForce; 
    [Space]
    [Header("Child Magnets")]
    [SerializeField] private Magnet[] myMagnets;

    //This function is called when the script is loaded or a value is changed in the Inspector (Called in the editor only).
    private void Update()
    {
        foreach (Magnet magnets in myMagnets)
        {
            magnets.magnetForce = magnetForce;
        }
    }
    public void MagnetForceChange(float value)
    {
        magnetForce = value;
    }
}
