using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public GameObject[] Panels;
    public GameObject[] tapToButtons;

    [Header("------Platform Information")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] speedsOfRotation;
    private bool isRotation;

    [Header("------Level Settings")]
    public int diamondCounter;
    public ParticleSystem explosionEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRotation = true;
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
        else
        {
            GameWin();
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

        if (Input.GetKeyDown(KeyCode.B))
        {
            Panels[0].SetActive(false);
        }
        if (isRotation == true)
        {
            platform_1.transform.Rotate(new Vector3(0, 0, speedsOfRotation[0]), Space.Self);
        }
    }

    public void GameOver()
    {
        Panels[1].SetActive(true);
        Textler[6].text = PlayerPrefs.GetInt("Diamond").ToString();
        Textler[7].text = SceneManager.GetActiveScene().name;
        Textler[8].text = (howManyCar - indexOftheWorkingCar).ToString(); // kalan arac sayısı gösterilir.
        Textler[9].text = diamondCounter.ToString(); //Elmas sayısı gösterilir.
        Invoke("ShowLoseButton",2f);
        isRotation = false;
    }
    void ShowLoseButton()
    {
        tapToButtons[0].SetActive(true); //Unity editörde 0-LosePaneldeki atandı.
    }
    void ShowWinButton()
    {
        tapToButtons[1].SetActive(true); //Unity editörde 1-WinPaneldeki atandı.
    }

    void GameWin()
    {
        Panels[2].SetActive(true);
        PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + diamondCounter); //Üstteki genel elmas sayısı gösterilir.
        Textler[2].text = PlayerPrefs.GetInt("Diamond").ToString();
        Textler[3].text = SceneManager.GetActiveScene().name;
        Textler[4].text = (howManyCar - indexOftheWorkingCar).ToString();
        Textler[5].text = diamondCounter.ToString();
        Invoke("ShowWinButton", 2f);
    }
    // BELLEK YÖNETİMİ - MEMORY MANAGEMENT

    void CheckDefaultValue()
    {
        if (!PlayerPrefs.HasKey("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 0);
            PlayerPrefs.SetInt("Level", 1); //varsayılan index başlangıç verildi.
        }
        Textler[0].text = PlayerPrefs.GetInt("Diamond").ToString();  //Liste 0.eleman elmas sayısı
        Textler[1].text = SceneManager.GetActiveScene().name; //Liste 1. eleman level sayısı
    }

    public void WatchAdds()
    {
        Debug.Log("Reklam");
    }

    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
