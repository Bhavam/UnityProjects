using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float score=0;
    public List<GameObject> targets;
    private float spawnRate=1; 
    public bool isGameActive=true;
    public Button restartButton;
    public GameObject titleScreen;
     
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {

        while(isGameActive)
        { 
            yield return new WaitForSeconds(spawnRate);
            int index =Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            
        }
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score+=scoreToAdd;
        scoreText.text="Score: "+score;
    }
    public void GameOver()
    {
     restartButton.gameObject.SetActive(true);
     gameOverText.gameObject.SetActive(true);   
     isGameActive=false;
    }
    public void RestartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        isGameActive=true;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate/=difficulty;
    }
}
