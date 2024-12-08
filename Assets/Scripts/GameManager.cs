using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string plantTag = "Plant"; // The tag for the plant objects

    void Update()
    {
        if (GameObject.FindGameObjectWithTag(plantTag) == null)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over: No plant found!");
    }
}
