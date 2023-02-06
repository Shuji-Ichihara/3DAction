using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private Text _titleText = null;
    [SerializeField]
    private Text _press = null;

    // Start is called before the first frame update
    void Start()
    {
        _titleText.text = "3D Action";
        _press.text = "Press to Enter key"; 
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadSceneAsync("MainGameScene");
        }
    }
}
