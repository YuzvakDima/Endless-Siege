using UnityEngine;
using UnityEngine.SceneManagement;


public class StartLevel : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryLevel();
        }
    }

    public void TryLevel()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "LevelOne")
            {
                SceneManager.LoadScene("Level1");
            }
            if (hit.collider.gameObject.name == "LevelTwo")
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
