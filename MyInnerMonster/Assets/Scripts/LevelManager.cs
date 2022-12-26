using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private Animator anim;
    public CandyCounter candys;
    public ItemCollector _collectables;
    //public int levelToLoad;
    //public int currentLevel;
    public bool isPlayerDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }
    public void OnFadeComplete()
    {
        if (isPlayerDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            candys.candys = _collectables.candys;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Respawn()
    {
        isPlayerDead = true;
        anim.SetTrigger("fade");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
