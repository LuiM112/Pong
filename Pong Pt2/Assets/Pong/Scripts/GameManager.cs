using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public Transform LeftPaddle;
    public Transform rightPaddle;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public GameObject LeftPlayerScoreText;
    public GameObject RightPlayerScoreText;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;
    private Vector3 ballStartPos;
    private Vector3 LpaddleStartSize;
    private Vector3 RpaddleStartSize;
    private const int scoreToWin = 11;

    // Start is called before the first frame update
    void Start()
    {
        ballStartPos = ball.position;
        LpaddleStartSize = LeftPaddle.localScale;
        RpaddleStartSize = rightPaddle.localScale;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    // If the ball entered the goal area, increment the score, check for win, and reset the ball
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            ResetPaddles();
            RightPlayerScoreText.GetComponent<TextMeshProUGUI>().text = rightPlayerScore.ToString();
            if (rightPlayerScore > leftPlayerScore)
            {
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.green;
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else if (leftPlayerScore > rightPlayerScore)
            {
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.green;
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.white;
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            Debug.Log($"Right player scored: {rightPlayerScore}");
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().text = "0";
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().text = "0";
            }
            else
            {
                ResetBall(-1f);
                ResetPaddles();
            }
        }
        else if (trigger == rightGoalTrigger)
        {

            leftPlayerScore++;
            ResetPaddles();
            if (rightPlayerScore > leftPlayerScore)
            {
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.green;
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else if (leftPlayerScore > rightPlayerScore)
            {
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.green;
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.white;
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().text = leftPlayerScore.ToString();
            Debug.Log($"Left player scored: {leftPlayerScore}");
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
                LeftPlayerScoreText.GetComponent<TextMeshProUGUI>().text = "0";
                RightPlayerScoreText.GetComponent<TextMeshProUGUI>().text = "0";
            }
            else
            {
                ResetBall(1f);
            }
        }
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    void ResetPaddles()
    {
        LeftPaddle.localScale = LpaddleStartSize;
        rightPaddle.localScale = RpaddleStartSize;
    }
}
