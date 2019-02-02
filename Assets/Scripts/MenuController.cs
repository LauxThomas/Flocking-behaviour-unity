using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public HeartOfTheSwarm heart;
    public Boid boid;
    public Button restart, exit;

    public Slider numOfObjects, spawnRadius, maxSpeed, cohesionRadius, separationRadius;
    // Start is called before the first frame update
    void Start()
    {
        initHandleValues();
        
        
        
        restart.onClick.AddListener(restartWithNewCount);
        
        exit.onClick.AddListener(exitGame);
        
        
        
        numOfObjects.onValueChanged.AddListener(changeNumOfObjects);
        spawnRadius.onValueChanged.AddListener(changeSpawnRadius);
        maxSpeed.onValueChanged.AddListener(changeMaxSpeed);
        cohesionRadius.onValueChanged.AddListener(changeCohesionRadius);
        separationRadius.onValueChanged.AddListener(changeSeparationRadius);
        
        
    }

    private void initHandleValues()
    {
        numOfObjects.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + numOfObjects.value;
        spawnRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + spawnRadius.value;
        separationRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + separationRadius.value;
        cohesionRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + cohesionRadius.value;
        maxSpeed.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + maxSpeed.value;
    }

    private void changeNumOfObjects(float arg0)
    {
        numOfObjects.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + numOfObjects.value;
    }

    private void changeSpawnRadius(float newNumber)
    {
        spawnRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + spawnRadius.value;
    }

    private void changeSeparationRadius(float newRadius)
    {
        separationRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + separationRadius.value;
        boid.GetComponent<Boid>().setSeparationRadius(newRadius);
    }

    private void changeCohesionRadius(float newRadius)
    {
        cohesionRadius.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + cohesionRadius.value;
        boid.GetComponent<Boid>().setCohesionRadius(newRadius);
    }

    private void changeMaxSpeed(float newSpeed)
    {
        maxSpeed.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text =
            "" + maxSpeed.value;
        boid.GetComponent<Boid>().setMaxSpeed(newSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartWithNewCount()
    {
        heart.GetComponent<HeartOfTheSwarm>().setNewCounter(Mathf.RoundToInt(numOfObjects.value),Mathf.RoundToInt(spawnRadius.value));
    }
    
}
