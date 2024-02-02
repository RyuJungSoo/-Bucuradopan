using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialSet : MonoBehaviour
{
    public Image[] image;


    private void Awake()
    {
        foreach(Image i in image)
        {
            i.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        StartCoroutine(ShowImage());
    }

    private void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Battle");
    }
    private IEnumerator ShowImage()
    {

        foreach(Image i in image)
        {
            i.gameObject.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            i.gameObject.SetActive(false);
        }

        ChangeScene();

        yield return null;
    }

}
