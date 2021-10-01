using System;
using System.Collections.Generic;

//Purpose of class: Randomizing images on the board & comparing the times to see which player won & also changes the list according to the theme selected on the form

namespace MatchingGame_PartnerProject
{
    public class BoardModel
    {
        //Constant for number of matches each player can find (board is 4x4 so 8 pairs total)
        public const int matchCountMax = 8;

        private string theme = "";

        //Creating a list of strings called imageTags which will hold the names of the images on the  "other side" of our cards
        private List<String> imageTags = new List<String>();

        //Constructor takes in a string which will later be used in form to change list depending on theme selected
        public BoardModel(string selected)
        {
            if (selected == "rbnHarryPotter")
            {
                harrypotterImages();
                theme = "harrypotter";
            }
            else if (selected == "rbnSpongebob")
            {
                spongebobImages();
                theme = "spongebob";
            }

            else if (selected == "rbnFriends")
            {
                friendsImages();
                theme = "friends";
            }
        }

        //Methods below populate list with images for selected theme
        public void spongebobImages()
        {
            imageTags.Clear();
            imageTags.Add("spongebob1");
            imageTags.Add("spongebob1");
            imageTags.Add("patrick");
            imageTags.Add("patrick");
            imageTags.Add("sandy");
            imageTags.Add("sandy");
            imageTags.Add("gary");
            imageTags.Add("gary");
            imageTags.Add("mrkrabs");
            imageTags.Add("mrkrabs");
            imageTags.Add("plankton");
            imageTags.Add("plankton");
            imageTags.Add("squidward");
            imageTags.Add("squidward");
            imageTags.Add("flowers");
            imageTags.Add("flowers");
        }
        public void harrypotterImages()
        {
            imageTags.Clear();
            imageTags.Add("harry");
            imageTags.Add("harry");
            imageTags.Add("ron");
            imageTags.Add("ron");
            imageTags.Add("hermione");
            imageTags.Add("hermione");
            imageTags.Add("dobby");
            imageTags.Add("dobby");
            imageTags.Add("gryffindor");
            imageTags.Add("gryffindor");
            imageTags.Add("hufflepuff");
            imageTags.Add("hufflepuff");
            imageTags.Add("ravenclaw");
            imageTags.Add("ravenclaw");
            imageTags.Add("slytherin");
            imageTags.Add("slytherin");
        }

        public void friendsImages()
        {
            imageTags.Clear();
            imageTags.Add("lisa");
            imageTags.Add("lisa");
            imageTags.Add("jennifer");
            imageTags.Add("jennifer");
            imageTags.Add("matt");
            imageTags.Add("matt");
            imageTags.Add("matthew");
            imageTags.Add("matthew");
            imageTags.Add("courtney");
            imageTags.Add("courtney");
            imageTags.Add("david");
            imageTags.Add("david");
            imageTags.Add("janice");
            imageTags.Add("janice");
            imageTags.Add("gunther");
            imageTags.Add("gunther");
        }

        //Randomize images on board
        public String[] randomizeBoard()
        {
            String[] randomTags = new String[16];
            List<String> temp = imageTags;

            //Creating Random object
            Random random = new Random();

            for (int i = 0; i < randomTags.Length; i++)
            {
                //Get value between 0-15
                int value = random.Next(0, temp.Count - 1);
                randomTags[i] = temp[value];
                //Prevents each pair from being randomized for the 3rd time
                temp.RemoveAt(value);
            }

            //Repopulate images based on theme
            if (theme == "harrypotter")
            {
                harrypotterImages();
            }
            else if (theme == "spongebob")
            {
                spongebobImages();
            }
            else { // friends
            
            friendsImages();
            }

            return randomTags;
        }

        //Finding the winner
        public PlayerModel isWinner(PlayerModel A, PlayerModel B)
        {
            //Comparing the minutes see if it's a tie, if it's not, then compare to see which player took less time
            if (A.getMinutes() != B.getMinutes())
            {
                if (A.getMinutes() > B.getMinutes())
                {
                    return B;
                }
                else
                {
                    return A;
                }
            }

            //Comparing the seconds see if it's a tie, if it's not, then compare to see which player took less time
            else if (A.getSeconds() != B.getSeconds())
            {
                if (A.getSeconds() > B.getSeconds())
                {
                    return B;
                }
                else
                {
                    return A;
                }
            }

            //Comparing the milliseconds see if it's a tie, if it's not, then compare to see which player took less time
            else if (A.getMilliseconds() != B.getMilliseconds())
            {
                if (A.getMilliseconds() > B.getMilliseconds())
                {
                    return B;
                }
                else
                {
                    return A;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
