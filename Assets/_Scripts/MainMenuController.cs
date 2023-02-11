using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    SpawnManager _spawnManagerReference;

    Label _mainLabel;
    Button _piButton;
    Button _iobButton;
    Button _siButton;

    private void Awake()
    {
        _spawnManagerReference.currentStage = SpawnManager.StagesSelector.SelectionMenu;
        var root = GetComponent<UIDocument>().rootVisualElement;

        _mainLabel = root.Q<Label>("MainMenu-label");
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

    // Update is called once per frame
    void Update()
    {
        
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
