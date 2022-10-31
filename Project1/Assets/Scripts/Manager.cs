using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Food;
    public GameObject swarm;
    public int initialFood = 10;
    private int numFood = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numFood < initialFood)
            StartCoroutine(spawnFood());
    }
    public void decrementNumFood()
    {
        numFood--;
    }

    IEnumerator spawnFood()
    {
        numFood++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        Vector2 distance;
        do
            {
                float x = Random.Range(-Constants.C.boundX * 0.5f, Constants.C.boundX * 0.5f);
                float y = Random.Range(-Constants.C.boundY * 0.5f, Constants.C.boundY * 0.5f);
                distance = new Vector2(x - swarm.transform.position.x, y - swarm.transform.position.y);
            } while (distance.magnitude < 3);
        GameObject instance = Instantiate(Food);
        instance.transform.position = new Vector3(distance.x, distance.y, 0);
        Food food = instance.GetComponent<Food>();
        food.manager = this;
    }
}