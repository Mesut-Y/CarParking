using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("------Car Settings")]
    public GameObject[] CarPool;
    public int howManyCar;
    int indexOftheWorkingCar = 0;

    [Header("------Canvas Settings")]
    public Sprite imageOfReadyCar;
    public TextMeshProUGUI numberOfCarsLeft;
    public GameObject[] imageOfCarCounter;
    public TextMeshProUGUI[] Textler;

    [Header("------Platform Information")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] speedsOfRotation;

    [Header("------Level Settings")]
    public int diamondCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckDefaultValue();
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

    // BELLEK YÖNETİMİ - MEMORY MANAGEMENT

    void CheckDefaultValue()
    {
        if (!PlayerPrefs.HasKey("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 0);
        }
        Textler[0].text = PlayerPrefs.GetInt("Diamond").ToString();  //Liste 0.eleman elmas sayısı
        Textler[1].text = SceneManager.GetActiveScene().name; //Liste 1. eleman level sayısı

    }
}
