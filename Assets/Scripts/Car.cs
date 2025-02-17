using UnityEngine;

public class Car : MonoBehaviour
{
    public bool forward;
    //
    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(forward)
            transform.Translate(15f * Time.deltaTime * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Parking"))
        {
            forward = false;
        }
        else if (collision.gameObject.CompareTag("OrtaGobek"))
        {
            Destroy(gameObject); //obje havuzu eklenince false yapılacak.
        }
    }
}
