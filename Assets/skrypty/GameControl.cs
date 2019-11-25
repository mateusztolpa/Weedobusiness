using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static bool hasStoppedMoving = true;
    public static bool hasDisplayedPopup = true;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
            hasStoppedMoving = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
            hasStoppedMoving = true;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }


        // WARUNKI DO WYSWIETLANIA KART NA POLACH SPECJALNYCH 
        if (hasStoppedMoving && !hasDisplayedPopup)
        {
            hasDisplayedPopup = true;
            Debug.Log("Finished moving!");

            if (player1.GetComponent<FollowThePath>().waypointIndex == 5 || player2.GetComponent<FollowThePath>().waypointIndex == 5)               //  HOMIES
            {
                Debug.Log("DZIALA HOMIES");
                hasDisplayedPopup = true;

            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 22 || player2.GetComponent<FollowThePath>().waypointIndex == 22)             //  HOMIES
            {
                Debug.Log("DZIALA HOMIES");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 28 || player2.GetComponent<FollowThePath>().waypointIndex == 28)             //  HOMIES
            {
                Debug.Log("DZIALA HOMIES");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 13 || player2.GetComponent<FollowThePath>().waypointIndex == 13)     // SHOP
            {
                Debug.Log("DZIALA SHOP");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 27 || player2.GetComponent<FollowThePath>().waypointIndex == 27)     // SHOP
            {
                Debug.Log("DZIALA SHOP");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 11 || player2.GetComponent<FollowThePath>().waypointIndex == 11)                     //SZANSA
            {
                Debug.Log("DZIALA SZANSA");
            }
            if (player1.GetComponent<FollowThePath>().waypointIndex == 19 || player2.GetComponent<FollowThePath>().waypointIndex == 19)                     // SZANSA
            {
                Debug.Log("DZIALA SZANSA");
            }
            if (player1.GetComponent<FollowThePath>().waypointIndex == 29 || player2.GetComponent<FollowThePath>().waypointIndex == 29)                     // SZANSA
            {
                Debug.Log("DZIALA SZANSA");
            }

            // KONIEC DO KART SPECJALNYCH


            // POLA BADTRIP RATUSZ ITD
            if (player1.GetComponent<FollowThePath>().waypointIndex == 9 || player2.GetComponent<FollowThePath>().waypointIndex == 9)
            {
                Debug.Log("DZIALA BADTRIP");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 17 || player2.GetComponent<FollowThePath>().waypointIndex == 17)
            {
                Debug.Log("DZIALA RATUSZ");
            }

            if (player1.GetComponent<FollowThePath>().waypointIndex == 24 || player2.GetComponent<FollowThePath>().waypointIndex == 24)
            {
                Debug.Log("DZIALA LABORATORIUM");
            }

            // KONIEC BADTRIP ITD*/
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}
