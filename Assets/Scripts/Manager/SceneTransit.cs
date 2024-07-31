using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransit : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneTransit transitScene;
    public GameObject fade_in, fade_out;
    private Animator Fin, Fout;
    public void Awake()
    {
        if (transitScene != null)
        {
            Destroy(gameObject);
        }
        else
        {
            transitScene = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Fin = fade_in.GetComponent<Animator>();
        Fout = fade_out.GetComponent<Animator>();
        fade_in.SetActive(false);
        fade_out.SetActive(false);
    }

   
    public IEnumerator Transit()
    {
        FadeIn();
        yield return new WaitForSeconds(1);
        turnOff();
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % EditorBuildSettings.scenes.Length);
        FadeOut();
        yield return new WaitForSeconds(1);
        turnOff();
        
    }
    
    public void FadeIn()
    {
        fade_in.SetActive(true);
        fade_out.SetActive(false);
    }
    public void FadeOut()
    {
        fade_out.SetActive(true);
        fade_in.SetActive(false);
    }
    public void turnOff()
    {
        fade_in.SetActive(false);
        fade_out.SetActive(false);
    }

    public void changeSceneWithIndex(int index)
    {
        StartCoroutine(TransitIndex(index));
    }
    public IEnumerator TransitIndex(int index)
    {
        FadeIn();
        yield return new WaitForSeconds(1);
        turnOff();
        SceneManager.LoadScene(index);
        FadeOut();
        yield return new WaitForSeconds(1);
        turnOff();

    }
    public void ChangeNextScene()
    {
        StartCoroutine(Transit());
    }
}
