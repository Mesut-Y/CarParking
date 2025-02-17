using UnityEngine;

public class Car : MonoBehaviour
{
    public bool forward;
    bool isStartPoint = false;
    public GameObject startPoint;
    public GameObject[] wheelTrail;
    public GameManager _GM;
    public Transform parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartPoint)
            transform.Translate(6f * Time.deltaTime * transform.forward);

        if (forward)
            transform.Translate(15f * Time.deltaTime * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("StartPoint"))
        {
            isStartPoint = true;
            //
        }
        else if (collision.gameObject.CompareTag("Parking"))
        {
            forward = false;
            transform.SetParent(parent); //Arabanın platformda kalmasını sağlıyor.
            wheelTrail[0].SetActive(false);
            wheelTrail[1].SetActive(false);
            _GM.GetNewCar();
        }
        else if (collision.gameObject.CompareTag("OrtaGobek"))
        {
            Destroy(gameObject); //canvas çıkacak // obje havuzu eklenince false yapılacak.
        }
        else if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject); //obje havuzu eklenince false yapılacak.
        }
    }
}
