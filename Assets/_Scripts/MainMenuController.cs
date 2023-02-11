using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    SpawnManager _spawnManagerReference;

    Button _piButton;
    Button _iobButton;
    Button _siButton;

    private void Awake()
    {
        _spawnManagerReference.currentStage = SpawnManager.StagesSelector.SelectionMenu;
        var root = GetComponent<UIDocument>().rootVisualElement;

        _piButton = root.Q<Button>("PlainIsland-button");
        _iobButton = root.Q<Button>("IsleOfBook-button");
        _siButton = root.Q<Button>("ShrineIsland-button");
    }

    // Start is called before the first frame update
    void Start()
    {
        _piButton.clicked += PlainIslandButton;
        _iobButton.clicked += IsleOfBookButton;
        _siButton.clicked += ShrineIslandButton;
    }

    void PlainIslandButton()
    {
        SceneManager.LoadScene("Plain Island");
    }

    void IsleOfBookButton()
    {
        SceneManager.LoadScene("Isle of Book");
    }

    void ShrineIslandButton()
    {
        SceneManager.LoadScene("Shrine Island");
    }
}
