using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadScene : MonoBehaviour
{
    public float waitToLoad;
    public string mapToload;
    private void Awake()
    {
        StartCoroutine(loadNextScene());

    }
    IEnumerator loadNextScene()
    {
       Cursor.visible = false;

        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(mapToload);

    }
}
