using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject car;

    [Header("------Platform Bilgileri")]
    public GameObject platform_1;
    public GameObject platform_2;

    public float[] donusHizlari;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            car.GetComponent<araba>().ilerle = true;
        }
        platform_1.transform.Rotate(new Vector3(0,0,donusHizlari[0]),Space.Self);
    }
}
