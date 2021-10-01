using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;


namespace MatchingGame_PartnerProject
{
    //Purpose of class: Track the status of a Player throughout the game
    //Class needs the name of one player & an int value of 1 or 2 indicating whether the player was the first to play or the second
    //The constructor is supposed to initialize the first two attributes using the values of the arguments passed to the constructor
    //Also contains methods get minutes/seconds/milliseconds, setTime & resetTime
    public class PlayerModel
    {
        //Fields
        private string name;
        private int playerNumber;      
        private int timeMin;
        private int timeSec;
        private int timeMilli;

        //Constructor
        public PlayerModel(string n, int pn)
        {
            this.name = n;
            this.playerNumber = pn;

            //Setting fields for timer to 0      
            timeMin = 0;
            timeSec = 0;
            timeMilli = 0;
        }

        //Get name
        public string GetName()
        {
            return name;
        }

        //Set name
        public void SetName(string value)
        {
            name = value;
        }

        //Get play number
        public int GetPlayerNumber()
        {
            return playerNumber;
        }

        //Set play number
        public void SetPlayerNumber(int value)
        {
            playerNumber = value;
        }

        //Get minutes
        public int getMinutes()
        {
            return timeMin;
        }

        //Get seconds
        public int getSeconds()
        {
            return timeSec;
        }

        //Get milliseconds
        public int getMilliseconds()
        {
            return timeMilli;
        }

        //Set time with fields
        public void setTime(int min, int sec, int milli)
        {
            timeMin = min;
            timeSec = sec;
            timeMilli = milli;
        }

        //Reset timer on form
        public void resetTime()
        {
            timeMilli = 0;
            timeSec = 0;
            timeMin = 0;
        }
    }
}
