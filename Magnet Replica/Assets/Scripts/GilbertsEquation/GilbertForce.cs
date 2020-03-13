using UnityEngine;

public class GilbertForce : MonoBehaviour
{
    public float Permeability = 0.05f;
    public float MaxForce = 1000.0f;

    public bool UseScaleForDebugDraw;

    private Vector3 GilbertForceSet(Magnet magnet1, Magnet magnet2)
    {
        Vector3 m1 = magnet1.transform.position;
        Vector3 m2 = magnet2.transform.position;
        Vector3 r = m2 - m1;
        float dist = r.magnitude;
        float part0 = Permeability * magnet1.magnetForce * magnet2.magnetForce;
        float part1 = Mathf.PI * dist;

        float force = (part0 / part1);

        if (magnet1.polerization == magnet2.polerization)
        {
            force = -force;
        }

        return force * r.normalized;
    }

    private void FixedUpdate()
    {
        Magnet[] magnets = FindObjectsOfType<Magnet>();

        for (int i = 0; i < magnets.Length; i++)
        {
            Magnet m1 = magnets[i];
            if (m1.rb == null)
            {
                continue;
            }

            Rigidbody rb1 = m1.rb;
            Vector3 accF1 = Vector3.zero;
            Vector3 accF2 = Vector3.zero;
            for (int j = 0; j < magnets.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                Magnet m2 = magnets[j];

                if (m2.magnetForce < 5.0f)
                {
                    continue;
                }

                if (m1.transform.parent == m2.transform.parent)
                {
                    continue;
                }

                Vector3 force = GilbertForceSet(m1, m2);
                float magnetForce = m1.magnetForce * m2.magnetForce / 1000;

                accF1 += force * magnetForce;
            }

            if (accF1.magnitude > MaxForce)
            {
                accF1 = accF1.normalized * MaxForce;
            }
            rb1.AddForceAtPosition(accF1, m1.transform.position);
        }
    }

}
