using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public class Person
    {
        public int birthYear = 0;
        public int deathYear = 0;
        public int livePeriod = 0;

        public Person()
        {
        }

        public Person(int birthY, int deathY)
        {
            birthYear = birthY;
            deathYear = deathY;
            livePeriod = deathYear - birthYear;
        }
    }

    [SerializeField]
    Texture2D _texture;

    private const int MIN_SIZE = 100; // min size of the Image in Editor
    private const int PERIOD_START = 1900;
    private const int PERIOD_END = 2000;

    private int _peopleAmount = 100; // equals the width of LineGenerator image in Editor
    private int _maxLineHeight = 0; // the max height of line visible on the graph
    private int _maxLivePeriod = 0;
    private Queue<Person> _peopleQueue;
    private Vector2 _bottomLeftPos = new Vector2(0f, 0f);

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

        if (PERIOD_END <= PERIOD_START)
        {
            throw new System.Exception("PERIOD_END must be grater than PERIOD_START");
        }

        _bottomLeftPos = rect.offsetMin;
        _peopleAmount = (int)rect.rect.width;
        _maxLineHeight = (int)rect.rect.height;
        _maxLivePeriod = PERIOD_END - PERIOD_START;

        InitPeopleQueue();
    }

    // Update is called once per frame
    void Update()
    {


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
            person.birthYear = (int)Random.Range((float)PERIOD_START, (float)(PERIOD_END));   // 1900 and 2000 - possible birth year
            person.deathYear = (int)Random.Range((float)person.birthYear, (float)PERIOD_END); // birthYear and 2000 - possible death year, so person can be born and die at the same year
            person.livePeriod = person.deathYear - person.birthYear;
            Debug.Log("Person" + i + " birthYear= " + person.birthYear + ", deathYear= " + person.deathYear + ", livePeriod= " + person.livePeriod);

            _peopleQueue.Enqueue(person);
        }
    }
}
