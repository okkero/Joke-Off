using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public AttackType attackType;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Hit()
    {
        GetComponentInParent<Fighter>().Hit(attackType);
    }
}