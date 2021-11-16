using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Track Creation")]
    private GameObject trackPiece;
    [SerializeField] private GameObject trackPieceFoward;
    [SerializeField] private GameObject trackPieceSide;
    [SerializeField] private GameObject trackPieceTurnLeft;
    [SerializeField] private GameObject trackPieceTurnRight;
    [SerializeField] private GameObject createPos;
    [SerializeField] private GameObject collectable;
    [SerializeField] private float timeToGenerate;
    [SerializeField] private string currentDirection = "Foward";
    [SerializeField] private string previousDirection = "Foward";
    [SerializeField] private bool canCreateEmpty = true;
    [SerializeField] private bool activateEmpty = false;
    [SerializeField] private float colorTimer = 10f;
    [SerializeField] public int colorType = 1;
    [Header("Player")]
    [SerializeField] private PlayerController player;
    [SerializeField] public bool alive = true;
    [Header("Game Stats")]
    [SerializeField] private int level = 1;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreValue;
    private float distance = 0;
    [SerializeField] private TextMeshProUGUI distanceValue;
    [SerializeField] private float nextLevelDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDifficulty();
        StartCoroutine(GenerateTrackHelper());
        FindObjectOfType<TrackController>().UpdateColor();
        FindObjectOfType<UIColor>().ChangeColor();
        FindObjectOfType<CollectableUIColor>().ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            CheckProgress();
            TrackDistante();
            ColorChanger();
        }
    }

    private void ColorChanger()
    {
        if (colorTimer > 0)
        {
            colorTimer -= Time.deltaTime;
        }
        else
        {
            colorType = Random.Range(1, 7);
            colorTimer = 15f; ;            
        }
    }

    public void GenerateTrack()
    {
        //Defines the direction of the next piece of the track or whether it will be a empty space
        int chance = Random.Range(0, 10);
        float collectableOffset = 1f;

        if (chance < 5)
        {
            currentDirection = "Side";
            canCreateEmpty = true;
            CreateCollectable(collectableOffset);
        }
        else if (chance > 5)
        {
            currentDirection = "Foward";
            canCreateEmpty = true;
            CreateCollectable(collectableOffset);
        }
        else
        {
            if(activateEmpty)
            {
                collectableOffset = 3.5f;
                CreateCollectable(collectableOffset);
                CreateEmpty();
                canCreateEmpty = false;
            }
        }

        //if the current direction has not changed creates the next piece in the same direction,
        //if the current direction has changed it creates a transition to the next direction of the track
        if (previousDirection.Equals(currentDirection))
        {
            trackPiece = currentDirection.Equals("Foward") ? trackPieceFoward : trackPieceSide;
        }
        else
        {
            trackPiece = currentDirection.Equals("Foward") ? trackPieceTurnLeft : trackPieceTurnRight;
        }

        CreateLevel(trackPiece);
        previousDirection = currentDirection;
    }

    IEnumerator GenerateTrackHelper()
    {
        while (alive)
        {
            yield return new WaitForSeconds(timeToGenerate);
            GenerateTrack();
        }
    }

    public void CreateLevel(GameObject trackPiece)
    {
        if (currentDirection.Equals("Foward"))
        {
            Instantiate(trackPiece, createPos.transform.position, trackPiece.transform.rotation);
            createPos.transform.position = new Vector3(createPos.transform.position.x,
                createPos.transform.position.y, createPos.transform.position.z + createPos.transform.localScale.z);
        }
        else if (currentDirection.Equals("Side"))
        {
            Instantiate(trackPiece, createPos.transform.position, trackPiece.transform.rotation);
            createPos.transform.position = new Vector3(createPos.transform.position.x + createPos.transform.localScale.x,
                createPos.transform.position.y, createPos.transform.position.z);
        }
    }

    public void CreateEmpty()
    {
       if(canCreateEmpty)
        {
            if (currentDirection.Equals("Foward"))
            {
                createPos.transform.position = new Vector3(createPos.transform.position.x,
                    createPos.transform.position.y, createPos.transform.position.z + createPos.transform.localScale.z);
            }
            else if (currentDirection.Equals("Side"))
            {
                createPos.transform.position = new Vector3(createPos.transform.position.x + createPos.transform.localScale.x,
                    createPos.transform.position.y, createPos.transform.position.z);
            }
        }
    }

    public void CreateCollectable(float posOffset)
    {
        int chance = Random.Range(0, 10);
        Vector3 collect = createPos.transform.position;
        collect = new Vector3(collect.x, collect.y + posOffset, collect.z);
        if (chance < 3) Instantiate(collectable, collect, Quaternion.identity);
    }

    private void LevelUp()
    {
        level++;
        ChangeDifficulty();        
    }

    public void GainScore()
    {
        this.score++;
        scoreValue.text = score.ToString("0");
    }

    public void TrackDistante()
    {        
        distance += 1 * player.GetMoveSpeed() * Time.deltaTime;
        distanceValue.text = distance.ToString("0.0m");     
    }

    public void CheckProgress()
    {
        if(distance >= nextLevelDistance * 2 + 50 && level < 6)
        {
            LevelUp();
        }
    }

    public void ChangeDifficulty()
    {
        switch(level)
        {
            case 1:
                {
                    nextLevelDistance = 0;
                    player.SetMoveSpeed(4);
                    timeToGenerate = 0.40f;
                    break;
                }
            case 2:
                {
                    nextLevelDistance = 50;
                    player.SetMoveSpeed(5);
                    timeToGenerate = 0.38f;
                    break;
                }
            case 3:
                {
                    nextLevelDistance = 150;
                    player.SetMoveSpeed(6);
                    player.SetGravity(11);
                    timeToGenerate = 0.36f;
                    activateEmpty = true;
                    break;
                }
            case 4:
                {
                    nextLevelDistance = 275;
                    player.SetMoveSpeed(7);
                    player.SetGravity(12);
                    timeToGenerate = 0.30f;
                    break;
                }
            case 5:
                {
                    nextLevelDistance = 475;
                    player.SetMoveSpeed(8);
                    player.SetGravity(12);
                    timeToGenerate = 0.28f;
                    break;
                }
            case 6:
                {
                    player.SetMoveSpeed(9);
                    player.SetGravity(12.5f);
                    timeToGenerate = 0.26f;
                    break;
                }
        }
    }

    public int GetLevel()
    {
        return this.level;
    }
}
