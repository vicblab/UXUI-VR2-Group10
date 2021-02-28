using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StackPosition : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject blockPrefab;
    private BoxCollider collider;
    public ABlock[] blockTypes = new ABlock[0];
    public TMP_Text scoreText;

    [System.Serializable]
    public class ABlock
    {
        public Color color;
        public Vector3 size = Vector3.one;
    }
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
    public ABlock RandomBlock()
    {
        return blockTypes[Random.Range(0, blockTypes.Length)];
    }
    public void SpawnBlock()
    {
        ABlock blockType = RandomBlock();

        GameObject newBlock = Instantiate(blockPrefab);

        newBlock.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        newBlock.transform.localScale = blockType.size / 10f;
        newBlock.GetComponent<MeshRenderer>().material.color = blockType.color;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBlock();
        }
    }
    private float GetScore()
    {
        float score = 0;
        foreach (Collider coll in Physics.OverlapBox(transform.position + collider.center, collider.size / 2))
        {
            if (coll.gameObject.TryGetComponent(out StackBlock block))
                if (block.used)
                    score += Mathf.Ceil((block.transform.position.y - 0.55f) * 100);
        }
        return score;
    }
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("trigger");
        if (other.gameObject.TryGetComponent(out StackBlock block))
        {
            if (!block.used)
            {
                block.used = true;
                SpawnBlock();
            }
        }
    }
    public void FinalScore()
    {
        scoreText.text = $"Score:\n{GetScore():F0}";
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
