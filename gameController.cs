using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public const int columns = 5;
    public const int rows = 4;
    public const float Xspace = 3.5f;
    public const float Yspace = -2.2f;
    [SerializeField] private mainImageScript startObject;
    [SerializeField] private Sprite[] images;

    private int[] Randomiser(int[] locations)
    { 
        int[] array = locations.Clone() as int[];
        for(int i=0; i< array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6 , 6, 7 , 7 ,8 ,8 ,9 ,9 };
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;
        for(int i = 0; i<columns;i++)
        {
            for(int j = 0; j<rows; j++)
            {
                mainImageScript gameImage;
                if(i==0&&j==0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as mainImageScript;
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;
                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private mainImageScript firstOpen;
    private mainImageScript secondOpen;

    private int score = 0;
    private int attemps = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    public bool canOpen
    { 
        get { return secondOpen == null; } 
    }
    public void imageOpened(mainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if(firstOpen.spriteId == secondOpen.spriteId)
        {
            score++;
            scoreText.text = "Puan: " + score;

        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }
        if (score == 10)
        {
            SceneManager.LoadScene(31);
        }

        attemps++;
        attemptsText.text = "Deneme sayýsý: " + attemps;

        firstOpen= null;
        secondOpen= null;
    }
}
