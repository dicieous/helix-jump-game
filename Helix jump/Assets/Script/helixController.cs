using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixController : MonoBehaviour
{
    private Vector2 lastTapPos;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform goalTransform;

    public List<Stages> allStages = new List<Stages>();
    private float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();

    public GameObject helixLevelPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 2f);
        Loadstage(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 curTapPos = Input.mousePosition;
            if (lastTapPos == Vector2.zero)
            {
                lastTapPos=curTapPos;
            }
            float delta = lastTapPos.x - curTapPos.x;
            lastTapPos = curTapPos;
            transform.Rotate(Vector3.up * delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }

    }

    public void Loadstage(int stagenumber)
    {
        Stages stages = allStages[Mathf.Clamp(stagenumber, 0, (allStages.Count - 1))];

        //reset rotation
        transform.localEulerAngles = startRotation;

        //destroy gameobject
        foreach(GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        //create new levels
        float levelDistance = helixDistance / stages.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for(int i = 0; i < stages.levels.Count; i++)
        {
            spawnPosY -= levelDistance;

            //create new level within scene
            GameObject level = Instantiate(helixLevelPrefab, transform);
            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnedLevels.Add(level);

            int partsToDisable = 12 - stages.levels[i].partCount;
            List<GameObject> disableParts = new List<GameObject>();

            while (disableParts.Count < partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disableParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disableParts.Add(randomPart);
                }
            }

            
            List<GameObject> leftParts = new List<GameObject>();

            foreach(Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stagenumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            //creating deathparts
            List<GameObject> deathParts = new List<GameObject>();

            while (deathParts.Count < stages.levels[i].deathPartCount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];
                if (!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<deathScript>();
                    deathParts.Add(randomPart);
                }
            }
        }
    }
}
