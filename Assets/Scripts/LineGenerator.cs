﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public class Person
    {
        public int birthYear = 0;
        public int deathYear = 0;
        public int liveYears = 0;
        public float liveLineHeight = 0f; // pixels which are corresponding to liveYears

        public Person()
        {
        }
    }

    public Color graphColor = Color.yellow;
    [SerializeField]
    private Texture2D _texture;

    private const int MIN_SIZE = 100; // min size of the Image in Editor
    private const int PERIOD_START_YEAR = 1900;
    private const int PERIOD_END_YEAR = 2000;

    private int _peopleAmount = 100; // equals the width of LineGenerator image in Editor
    private int _maxLineHeight = 0; // the max height of line visible on the graph in pixels
    private int _maxLiveYears = 0;  // the max live period in years
    private Queue<Person> _peopleQueue;
    private Vector2 _bottomLeftPos = new Vector2(0f, 0f); // the bottom left position of Image

    private int _maxYear = PERIOD_END_YEAR;
    private int _minYear = PERIOD_START_YEAR;

    // Use this for initialization
    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        /*
        Debug.Log("Rectangle width= " + rect.rect.width);
        Debug.Log("Rectangle height= " + rect.rect.height);
        Debug.Log("Offset of the Lower left corner of the rectangle relative to the lower left anchor= " + rect.offsetMin);
        Debug.Log("Offset of the Upper right corner of the rectangle relative to the upper right anchor= " + rect.offsetMax);
        */

        if (rect.rect.width < MIN_SIZE || rect.rect.width < MIN_SIZE)
        {
            throw new System.Exception("You need to specify Width and Height in Editor for the LineRenderer");
        }

        if (PERIOD_END_YEAR <= PERIOD_START_YEAR)
        {
            throw new System.Exception("PERIOD_END_YEAR must be grater than PERIOD_START_YEAR");
        }

        _bottomLeftPos = rect.offsetMin;
        _peopleAmount = (int)rect.rect.width;
        _maxLineHeight = (int)rect.rect.height;     // Image's height in px which corresponds to _maxLiveYears in years
        _maxLiveYears = PERIOD_END_YEAR - PERIOD_START_YEAR;

        Debug.Log("_maxLineHeight= "+ _maxLineHeight+ "px, coressponds to _maxLiveYears=" + _maxLiveYears+" years");

        InitPeopleQueue();
        CalculateMaxAliveYear();
    }

    /**
     * Creates a queue of zeroes with a size of LineRenderer image width
     */
    private void InitPeopleQueue()
    {
        _peopleQueue = new Queue<Person>();

        for (int i = 0; i < _peopleAmount; i++)
        {
            Person person = new Person();
            person.birthYear = (int)Random.Range((float)PERIOD_START_YEAR, (float)(PERIOD_END_YEAR));   // 1900 and 2000 - possible birth year
            person.deathYear = (int)Random.Range((float)person.birthYear, (float)PERIOD_END_YEAR); // birthYear and 2000 - possible death year, so person can be born and die at the same year
            person.liveYears = person.deathYear - person.birthYear;
            person.liveLineHeight = person.liveYears * _maxLineHeight / _maxLiveYears;    //using proportion between pixels in the Image rectangular area and live period in years
            Debug.Log("Person" + i + " birthYear= " + person.birthYear + ", deathYear= " + person.deathYear + ", liveYears= " + person.liveYears + " years, corresponds to liveLineHeight= "+ person.liveLineHeight + "px");

            _peopleQueue.Enqueue(person);
        }
    }

    private void CalculateMaxAliveYear()
    {
    
    }

    /**
     * Draws texture with a size 2x2 px in a Rectangle with a size 1xliveLineHeight px 
     */
    public void OnGUI()
    {
        float counter = 0;
        foreach (Person person in _peopleQueue)
        {
            //NOTE: Position of GUI layer is top left corner of the screen so the direction of line drawing will go from top to bottom

            // upper X position of the line (which is a rectangle with width=1px)
            float upperPosX = counter + _bottomLeftPos.x;

            // convert Years from PERIOD_START_YEAR to Death year in to pixels
            float yearsFromStartPointToDeath = person.deathYear - PERIOD_START_YEAR; 
            float heightFromStartPointToDeath = yearsFromStartPointToDeath * _maxLineHeight / _maxLiveYears; // pixels which are corresponded to yearsFromStartPointToDeath

            // upper Y position of the line (which is a rectangle with width=1px)
            float upperPosY = Screen.height - _bottomLeftPos.y - heightFromStartPointToDeath;  
            GUI.color = graphColor;

            //Draw a rectangle from Death year position to Birth year position
            GUI.DrawTexture(new Rect(new Vector2(upperPosX, upperPosY), new Vector2(1, person.liveLineHeight)), _texture);
            counter++;
        }

        //DrawLinesIndicator();
    }   
}
