using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;

    [Header("Seviyelerde Gerekçleri")]
    [TextArea]
    [SerializeField] private string mesaj = "Seviyelerde kullanacağımız elemanları burada kullanacağız.";

    [Header("Listeler")]
    [SerializeField] private List<GameObject> levellar = new List<GameObject>();
    [SerializeField] private List<Color> planeColors = new List<Color>();
    [SerializeField] private List<Color> lastPlaneColors = new List<Color>();
    [SerializeField] private List<Color> capsuleColors = new List<Color>();
    [SerializeField] private List<Color> seaColors = new List<Color>();
    //[SerializeField] private Dictionary<int, Color[,,,]> colors = new Dictionary<int, Color[,,,]>();
    [SerializeField] private List<Material> objectsThatNeededToChangeColors = new List<Material>();

    //Seviye için gereken attributelar...
    public static int currentLevel;
    public int thisLevel; //Bu global erişim için;
    public static int nextLevel;
    public static int currentScene;
    public static bool restartLevelControl;
    public static bool nextLevelControl;
    public static bool randomizeLevelControl;
    private int newlevel;


    public Color currentColor; //Bunu dotween üzerinde renk değiştirdiğimiz için yazdık böylece erişebiliyoruz.

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }
        main = this;

        if (nextLevelControl && !randomizeLevelControl)
        {
            levellar[nextLevel].SetActive(true);
            nextLevelControl = false;
            //ChangeColors();
            currentLevel = nextLevel;
            thisLevel = currentLevel;
        }
        else if (!nextLevelControl)
        {

            if (PlayerPrefs.GetInt("level") >= levellar.Count)
            {
                levellar[0].SetActive(true);
                currentLevel = 0;
                thisLevel = currentLevel;
                //ChangeColors();
            }
            else if (PlayerPrefs.GetInt("level") < levellar.Count)
            {
                levellar[PlayerPrefs.GetInt("level")].SetActive(true);
                currentLevel = PlayerPrefs.GetInt("level");
                thisLevel = currentLevel;
                //ChangeColors();
            }
        }
        else if (nextLevelControl && randomizeLevelControl)
        {
            int newlevel = Random.Range(0, levellar.Count);
            while (true)
            {
                if (newlevel == currentLevel)
                {
                    Debug.LogError("Hala Aynıyım");
                    newlevel = Random.Range(0, levellar.Count);
                }
                else
                {
                    break;
                }
            }
            levellar[newlevel].SetActive(true);
            currentLevel = nextLevel;
            randomizeLevelControl = false;
            Debug.LogError("Değişmeyi başardım");
            //ChangeColors();
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void RandomizeLevel()
    {
        randomizeLevelControl = true;
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        Debug.LogError("Randomize a girdim");
        SceneManager.LoadScene(currentScene);
    }
    public void NextLevelEarlyBird()
    {

        if (currentLevel + 1 < levellar.Count)
        {
            nextLevelControl = true;
            nextLevel = currentLevel + 1;
            levellar[nextLevel].transform.position = new Vector3(levellar[currentLevel].transform.position.x, levellar[currentLevel].transform.position.y, levellar[currentLevel].transform.position.z + 198.02f);
            levellar[nextLevel].SetActive(true);
        }
        else if (currentLevel + 1 >= levellar.Count)
        {
            while (true)
            {
                if (newlevel == currentLevel)
                {
                    newlevel = Random.Range(0, levellar.Count);
                }
                else
                {
                    break;
                }
            }
            levellar[newlevel].transform.position = new Vector3(levellar[currentLevel].transform.position.x, levellar[currentLevel].transform.position.y, levellar[currentLevel].transform.position.z + 198.02f);
            levellar[newlevel].SetActive(true);
        }
    }
    public void NextLevel()
    {

        if (PlayerPrefs.GetInt("level") + 1 < levellar.Count)
        {
            nextLevelControl = true;
            nextLevel = currentLevel + 1;
            PlayerPrefs.SetInt("level", nextLevel);
            Debug.LogError("Level: " + PlayerPrefs.GetInt("level"));
            SceneManager.LoadScene(currentScene);
        }
        else if (PlayerPrefs.GetInt("level") + 1 >= levellar.Count)
        {
            RandomizeLevel();
        }
    }


    public void RestartLevel()
    {
        for (int i = 0; i < levellar.Count; i++)
        {
            if (levellar[i].activeInHierarchy)
            {
                restartLevelControl = true;
                currentLevel = i;
                SceneManager.LoadScene(currentScene);
                break;
            }
        }
    }

    private void ChangeColors()
    {
        int randomSea = Random.Range(0, seaColors.Count);
        int randomMat = Random.Range(0, planeColors.Count);
        currentColor = planeColors[randomMat];
        objectsThatNeededToChangeColors[0].color = planeColors[randomMat];
        objectsThatNeededToChangeColors[1].color = lastPlaneColors[randomMat];
        objectsThatNeededToChangeColors[2].color = capsuleColors[randomSea];
        objectsThatNeededToChangeColors[3].SetColor("Color_58E0201D", seaColors[randomSea]);
    }
}
