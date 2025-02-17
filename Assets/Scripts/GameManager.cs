using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("------Car Settings")]
    public GameObject[] CarPool;
    public int howManyCar;
    int IndexOftheWorkingCar = 0;

    [Header("------Platform Information")]
    public GameObject platform_1;
    public GameObject platform_2;

    public float[] speedsOfRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for (int i = 0; i < howManyCar; i++)
        //{
        //    CarPool[i].SetActive(true);
        //}
        CarPool[IndexOftheWorkingCar].SetActive(true);
    }

    public void GetNewCar()
    {
        if (IndexOftheWorkingCar < howManyCar)
        {
            CarPool[IndexOftheWorkingCar].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CarPool[IndexOftheWorkingCar].GetComponent<Car>().forward = true;
            IndexOftheWorkingCar++;
        }
        platform_1.transform.Rotate(new Vector3(0,0, speedsOfRotation[0]),Space.Self);
    }
}
