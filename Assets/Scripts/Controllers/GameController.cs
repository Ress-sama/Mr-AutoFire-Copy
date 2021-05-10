using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int loadLevel;

    private GameObject door;
    private Vector3 doorDirection;
    private bool openDoor;

    [SerializeField] GameObject gameOver;
    

    public static GameController INSTANCE { get; set; }


    private void Awake()
    {
        INSTANCE = this;
        door = GameObject.FindGameObjectWithTag(Tags.Door);
        doorDirection = new Vector3(door.transform.position.x, door.transform.position.y+10,0);
    }
    private void Update()
    {
        if (openDoor)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorDirection,0.01f);
        }
    }
    public void OpenDoor()
    {
        openDoor = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(loadLevel);
    }

    public void RestartLevel()
    {
        PlayerData.Health = 100;
        Destroy(MusicController.INSTANCE.gameObject);
        SceneManager.LoadScene(1);
    }
    public void ShowGameOverScreen()
    {
        Instantiate(gameOver,GameObject.Find("Canvas").transform);
    }
}
