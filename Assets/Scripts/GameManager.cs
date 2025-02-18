using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("------Car Settings")]
    public GameObject[] CarPool;
    public int howManyCar;
    int indexOftheWorkingCar = 0;
    public GameObject[] imageOfCarCounter;
    public Sprite imageOfReadyCar;
    public TextMeshProUGUI numberOfCarsLeft;

    [Header("------Platform Information")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] speedsOfRotation;

    [Header("------Platform Information")]
    public int diamondCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberOfCarsLeft.text = (howManyCar - indexOftheWorkingCar).ToString();
        for (int i = 0; i < howManyCar; i++)
        {
            imageOfCarCounter[i].SetActive(true);
        }
        CarPool[indexOftheWorkingCar].SetActive(true);
    }

    public void GetNewCar()
    {
        if (indexOftheWorkingCar < howManyCar)
        {
            CarPool[indexOftheWorkingCar].SetActive(true);
        }
        imageOfCarCounter[indexOftheWorkingCar-1].GetComponent<Image>().sprite = imageOfReadyCar;
        numberOfCarsLeft.text = (howManyCar - indexOftheWorkingCar).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CarPool[indexOftheWorkingCar].GetComponent<Car>().forward = true;
            indexOftheWorkingCar++;
        }
        platform_1.transform.Rotate(new Vector3(0,0, speedsOfRotation[0]),Space.Self);
    }
}
