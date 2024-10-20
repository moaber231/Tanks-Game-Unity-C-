using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{   
    public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
    public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
    public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.
    public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.
    public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
    public GameObject m_TankPrefab;             // Reference to the prefab the players will control.
    public TankManager[] m_Tanks;               // A collection of managers for enabling and disabling different aspects of the tanks.
    public GameObject m_HealthTankPrefab;
    public GameObject m_TrapPrefab;
    public GameObject m_MovingHealthTankPrefab;
    public GameObject m_MovingTrapPrefab;
    public int m_RoundNumber;
    public int m_OldRoundNumber;
     public GameObject m_Move3Prefab;
     public bool flag=false;
    public string[] cheatCode6;
    public int index6;
     public float amount;
     public float TiMe;
     public bool flag1=false;
     public bool fflag2=false;
     public bool fflag=false;
     public  TankManager m_RoundWinner1; 
     public int fire1;
     public int fire2;
     public int winneR;

    private string[] cheatCode;
    private int index;           
    private string[] cheatCode1;
    private int index1;  
    private string[] cheatCode2;
    private int index2;           
    private string[] cheatCode3;
    private int index3;       // Which round the game is currently on.
    private string[] cheatCode4;
    private int index4;
     private string[] cheatCode5;
    private int index5;
     private string[] cheatCode7;
    private int index7;
    private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.
    private TankManager m_RoundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
    private TankManager m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.
    private void Start()
    {
        // Create the delays so they only have to be made once.
        m_StartWait = new WaitForSeconds (m_StartDelay);
        m_EndWait = new WaitForSeconds (m_EndDelay);
        SpawnAllTanks();
        SetCameraTargets();
        // Once the tanks have been created and the camera is using them as targets, start the game.
        StartCoroutine (GameLoop ());  
        cheatCode = new string[] { "i", "k"  };// player 0 loses movment
         index = 0;
          cheatCode1 = new string[] { "o", "l"  };//player 1 loses movement
         index1 = 0;
         cheatCode2 = new string[] { "n", "m"  };// player 0 cant shoot
         index2 = 0;
          cheatCode3 = new string[] { "v", "b"  };//player 1 cant shoot
         index3 = 0;
           cheatCode4 = new string[] { "h", "u"  };// player 0 cant lose health
         index4 = 0;
          cheatCode5 = new string[] { "j", "u"  };// player 1 cant lose health
         index5 = 0;
          cheatCode6 = new string[] { "i", "o"  };// player 0 loses 2x health
         index6 = 0;
          cheatCode6 = new string[] { "p", "q"  };// player 0 loses 2x health
         index7 = 0;
         fire1=0;
         fire2=0;
    }
    private void Update()
    {
      if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode[index])) {
         
             index++;
         }
     
         else {
             index = 0;  
         }
       }

        if (index == cheatCode.Length) {
            m_Tanks[0].m_Movement.enabled=false;
           flag=true;
        }
        if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode1[index1])) {
         
             index1++;
         }
     
         else {
             index1 = 0;  
         }
       }

        if (index1 == cheatCode1.Length) {
            m_Tanks[1].m_Movement.enabled=false;
        }
         if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode2[index2])) {
         
             index2++;
         }
     
         else {
             index2 = 0;  
         }
       }

        if (index2 == cheatCode2.Length) {
            m_Tanks[0].m_Shooting.enabled = false;
           flag=true;
        }
        if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode3[index3])) {
         
             index3++;
         }
     
         else {
             index3 = 0;  
         }
       }

        if (index3 == cheatCode3.Length) {
            m_Tanks[1].m_Shooting.enabled = false;
        }
         if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode4[index4])) {
         
             index4++;
         }
     
         else {
             index4 = 0;  
         }
       }

        if (index4 == cheatCode4.Length) {
           m_Tanks[0].m_Health.m_Slider.value= 100f;
           m_Tanks[0].m_Health.m_FillImage.color=Color.green;
            m_Tanks[0].m_Health.m_CurrentHealth=100f;

           flag=true;
        }
          if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode5[index5])) {
         
             index5++;
         }
     
         else {
             index5 = 0;  
         }
       }

        if (index5 == cheatCode5.Length) {
           m_Tanks[1].m_Health.m_Slider.value=100f;
           m_Tanks[1].m_Health.m_FillImage.color=Color.green;
            m_Tanks[1].m_Health.m_CurrentHealth=100f;

           flag=true;
        }
        if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode6[index6])) {
         
             index6++;
         }
     
         else {
             index6 = 0;  
         }
       }

        if (index6 == cheatCode6.Length) {
           m_Tanks[0].m_Health.TakeDamage(2*amount);
        }
        if (Input.anyKeyDown) {
 
         if (Input.GetKeyDown(cheatCode7[index7])) {
         
             index7++;
         }
     
         else {
             index7 = 0;  
         }
       }

        if (index7 == cheatCode7.Length) {
           m_Tanks[0].m_Health.TakeDamage(2*amount);
        }
        if(Input.GetKeyDown("space")){
            fire1++;
        }
       
    }

    private void SpawnAllTanks()
    {
        // For all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... create them, set their player number and references needed for control.
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of tanks.
        Transform[] targets = new Transform[m_Tanks.Length];

        // For each of these transforms...
        for (int i = 0; i < targets.Length; i++)
        {
            // ... set it to the appropriate tank transform.
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        // These are the targets the camera should follow.
        m_CameraControl.m_Targets = targets;
    }
     

    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop ()
    {    
        
        // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine (RoundStarting ());
        TiMe=TiMe+Time.deltaTime;
        // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine (RoundPlaying());
        // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine (RoundEnding());

        // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
        if (m_GameWinner != null)
        {
            // If there is a game winner, restart the level.
            SceneManager.LoadScene (0);
           
        }
        else
        {
            // If there isn't a winner yet, restart this coroutine so the loop continues.
            // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            StartCoroutine (GameLoop ());
        }
    }


    private IEnumerator RoundStarting ()
    {
        // As soon as the round starts reset the tanks and make sure they can't move.
        //fire1=0;
       // fire2=0;
        ResetAllTanks ();
        DisableTankControl ();
         TiMe=0;
        for(int i=0; i<9; i++)
        {
            Instantiate(m_HealthTankPrefab,new Vector3(Random.Range(-100,50),1,Random.Range(0,50)),Quaternion.identity);  
         }
         for(int i=0; i<6; i++)
        {
            Instantiate(m_TrapPrefab,new Vector3(Random.Range(-100,50),1,Random.Range(0,50)),Quaternion.identity);  
         }
        Instantiate(m_MovingHealthTankPrefab,new Vector3(Random.Range(-100,50),2,Random.Range(0,50)),Quaternion.identity);
        Instantiate(m_MovingTrapPrefab,new Vector3(Random.Range(-100,50),2,Random.Range(0,50)),Quaternion.identity);
        Instantiate(m_Move3Prefab,new Vector3(Random.Range(-100,50),2,Random.Range(0,50)),Quaternion.identity);

        // Snap the camera's zoom and position to something appropriate for the reset tanks.
        m_CameraControl.SetStartPositionAndSize ();
        m_OldRoundNumber=m_RoundNumber;
        m_RoundNumber++;
        index=0;
        index1=0;
        index2=0;
        index3=0;
        index4 = 0;  
        index5 = 0;
        index6=0;
        index7=0;
        m_MessageText.text = "ROUND " + m_RoundNumber;
         
        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying ()
    {
        // As soon as the round begins playing let the players control the tanks.
        EnableTankControl ();
         m_Tanks[0].m_Movement.enabled=true;
          m_Tanks[0].m_Shooting.enabled = true;
          m_Tanks[1].m_Movement.enabled=true;
          m_Tanks[1].m_Shooting.enabled = true;
          m_Tanks[0].m_Health.m_Slider.value=m_Tanks[0].m_Health.m_CurrentHealth;
           m_Tanks[1].m_Health.m_Slider.value=m_Tanks[1].m_Health.m_CurrentHealth;
           m_Tanks[0].m_Health.TakeDamage(amount);
           m_Tanks[1].m_Health.TakeDamage(amount);
        // Clear the text from the screen.
        m_MessageText.text = string.Empty;
        // While there is not one tank left...
        while (!OneTankLeft())
        {
            // ... return on the next frame.
            yield return null;
        }
    }


    private IEnumerator RoundEnding ()
    {
        // Stop tanks from moving.
        DisableTankControl ();
        
        // Clear the winner from the previous round.
        m_RoundWinner = null;
        if(TankShooting.fire>=30){
            fflag=true;
        }
        else{
            TankShooting.fire=0;
        }
        // See if there is a winner now the round is over.
        m_RoundWinner = GetRoundWinner ();
        
        if(TiMe<=60f){
           flag1=true;
        }
        // If there is a winner, increment their score.
        if (m_RoundWinner != null)
            m_RoundWinner.m_Wins++;

        // Now the winner's score has been incremented, see if someone has one the game.
        m_GameWinner = GetGameWinner ();

        // Get a message based on the scores and whether or not there is a game winner and display it.
        string message = EndMessage ();
        m_MessageText.text = message;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_EndWait;
    }


    // This is used to check if there is one or fewer tanks remaining and thus the round should end.
    private bool OneTankLeft()
    {
        // Start the count of tanks left at zero.
        int numTanksLeft = 0;

        // Go through all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... and if they are active, increment the counter.
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        // If there are one or fewer tanks remaining return true, otherwise return false.
        return numTanksLeft <= 1;
    }
        
        
    // This function is to find out if there is a winner of the round.
    // This function is called with the assumption that 1 or fewer tanks are currently active.
    private TankManager GetRoundWinner()
    {
        // Go through all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... and if one of them is active, it is the winner so return it.
            if (m_Tanks[i].m_Instance.activeSelf)
              //  winneR=i;
                return m_Tanks[i];
        }

        // If none of the tanks are active it is a draw so return null.
        return null;
    }


    // This function is to find out if there is a winner of the game.
    private TankManager GetGameWinner()
    {
        // Go through all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... and if one of them has enough rounds to win the game, return it.
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        // If no tanks have enough rounds to win, return null.
        return null;
    }


    // Returns a string message to display at the end of each round.
    private string EndMessage()
    {
        // By default when a round ends there are no winners so the default end message is a draw.
        string message = "DRAW!";

        // If there is a winner then change the message to reflect that.
        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";
         if(flag1==true){
             message += "\n";
            message += m_RoundWinner.m_ColoredPlayerText + " WON UNDER 60 SECONDS";
            }
        if(m_Tanks[0].m_Health.m_CurrentHealth==100f ||m_Tanks[01].m_Health.m_CurrentHealth==100f ){
             message += "\n";
             message += m_RoundWinner.m_ColoredPlayerText + " WON WITHOUT LOSING LIFE";
        }
        // Add some line breaks after the initial message.
        if(fflag==true){
              message += "\n";
            message += " MORE THAN 30 SHOTS";
            fflag=false;
            TankShooting.fire=0;
        }
        message += "\n\n\n\n";
        // Go through all the tanks and add each of their scores to the message.
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        // If there is a game winner, change the entire message to reflect that.
        if (m_GameWinner != null){
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";
        }
        return message;
    }


    // This function is used to turn all the tanks back on and reset their positions and properties.
    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }
    

    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
       // collision.gameObject.name == "Tank";
        if(collision.gameObject.name=="Move3"){
           m_Tanks[0].m_Movement.enabled=false;
        }
    }
}