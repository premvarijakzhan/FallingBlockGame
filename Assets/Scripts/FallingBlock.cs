using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    //speed of the block
    float speed;

    float visibleHeightThreshold;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //movement of the block down
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
