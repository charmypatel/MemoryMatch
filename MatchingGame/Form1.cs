using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace MatchingGame_PartnerProject
{
    //Charmy Patel
    //Partner Project - Matching Game
    //11/5/2020

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        //Image for front of card (stays in form not BoardModel class, because we don't need to randomize it)
        Image harrypotterlogo = Properties.Resources.harrypotterlogo; 
        Image spongeboblogo = Properties.Resources.spongeboblogo;
        Image friendslogo = Properties.Resources.friendslogo;


        //Creating instance of SoundPlayer class & saving path to each sound file
        SoundPlayer spongebob = new SoundPlayer(Properties.Resources.SpongeBobSong);
        SoundPlayer harrypotter = new SoundPlayer(Properties.Resources.HarryPotterSong);
        SoundPlayer friends = new SoundPlayer(Properties.Resources.FriendsSong);

        //Creating buttons to be used to compare match
        Button a;
        Button b;

        //Integer variables that will hold labels for minutes/seconds/milliseconds that are used for timer & bool used to see if timer is on
        int timeMin;
        int timeSec;
        int timeMilli;
        bool isActive;

        //Counter for number of games played, number of flipped cards (limiting user to only pick 2 cards at a time), & number of matches (pairs)
        int gameCount = 0;
        int flippedCards = 0;
        int matchCounter;

        //Creating reference of BoardModel &PlayerModel class
        BoardModel boardmodel;
        PlayerModel currentPlayer;

        //Creating list of players (2) 
        List<PlayerModel> playersList = new List<PlayerModel>(2);

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPlayerDone.Visible = true;

            //Harry Potter is our default "front" side of the card when form loads, it will be changed if user decides to select a different theme
            //Changes button background to "front" side of card -> harrypotterlogo
            btn0.BackgroundImage = harrypotterlogo;
            btn1.BackgroundImage = harrypotterlogo;
            btn2.BackgroundImage = harrypotterlogo;
            btn3.BackgroundImage = harrypotterlogo;
            btn4.BackgroundImage = harrypotterlogo;
            btn5.BackgroundImage = harrypotterlogo;
            btn6.BackgroundImage = harrypotterlogo;
            btn7.BackgroundImage = harrypotterlogo;
            btn8.BackgroundImage = harrypotterlogo;
            btn9.BackgroundImage = harrypotterlogo;
            btn10.BackgroundImage = harrypotterlogo;
            btn11.BackgroundImage = harrypotterlogo;
            btn12.BackgroundImage = harrypotterlogo;
            btn13.BackgroundImage = harrypotterlogo;
            btn14.BackgroundImage = harrypotterlogo;
            btn15.BackgroundImage = harrypotterlogo;

            //Set the timer text for all labels to 0 & make timer inactive
            lblMinutes.Text = "00";
            lblSeconds.Text = "00";
            lblMilliseconds.Text = "00";
            isActive = false;

            //Hide board until names of players are entered
            layoutPanel.Visible = false;

            //Disable completed turn button so user cannot start timer before names of players are entered
            btnDone.Enabled = false;

            //.NET does not have hex color options so we can pass it in .FromHtml so the hex code is detected
            string formbackground = "#212222";
            Color formbackground_color = ColorTranslator.FromHtml(formbackground);
            this.BackColor = formbackground_color;

            string title = "#4B87B3";
            Color title_color = ColorTranslator.FromHtml(title);
            lblGameTitle.ForeColor = title_color;

            string panel = "#5C5C5C";
            Color panel_color = ColorTranslator.FromHtml(panel);
            layoutPanel.BackColor = panel_color;

            string exit = "#5C5C5C";
            Color exit_color = ColorTranslator.FromHtml(exit);
            layoutPanel.BackColor = exit_color;
        }
 
        //This event handler will be called when all of the other buttons on the board are clicked
        //Ignore cherryclick, we had fruit images before (now removed), we are still using same event handler for other themes so we have not changed the same (code still does same thing)
        private void cherry_1_Click(object sender, EventArgs e)
        {
            //Sender tells the program which button has been clicked
            Button currentButton = (Button)sender;
            String pickedID = currentButton.Tag.ToString();

            if (rbnHarryPotter.Checked)
            {              
                //Change the background image of button to whatever Harry Potter character user clicked on
                if (pickedID == "harry")
                {
                    currentButton.Tag = "harry";
                    currentButton.BackgroundImage = Properties.Resources.harry;
                }
                else if (pickedID == "ron")
                {
                    currentButton.Tag = "ron";
                    currentButton.BackgroundImage = Properties.Resources.ron;
                }
                else if (pickedID == "hermione")
                {
                    currentButton.Tag = "hermione";
                    currentButton.BackgroundImage = Properties.Resources.hermione;
                }
                else if (pickedID == "hufflepuff")
                {
                    currentButton.Tag = "hufflepuff";
                    currentButton.BackgroundImage = Properties.Resources.hufflepuff;
                }
                else if (pickedID == "ravenclaw")
                {
                    currentButton.Tag = "ravenclaw";
                    currentButton.BackgroundImage = Properties.Resources.ravenclaw;
                }
                else if (pickedID == "slytherin")
                {
                    currentButton.Tag = "slytherin";
                    currentButton.BackgroundImage = Properties.Resources.slytherin;
                }
                else if (pickedID == "gryffindor")
                {
                    currentButton.Tag = "gryffindor";
                    currentButton.BackgroundImage = Properties.Resources.gryffindor;
                }
                else if (pickedID == "dobby")
                {
                    currentButton.Tag = "dobby";
                    currentButton.BackgroundImage = Properties.Resources.dobby;
                }
            }
            else if (rbnSpongebob.Checked)
            {
                //Change the background image of button to whatever Spongebob character user clicked on
                if (pickedID == "spongebob1")
                {
                    currentButton.Tag = "spongebob1";
                    currentButton.BackgroundImage = Properties.Resources.spongebob;
                }
                else if (pickedID == "patrick")
                {
                    currentButton.Tag = "patrick";
                    currentButton.BackgroundImage = Properties.Resources.patrick;
                }
                else if (pickedID == "sandy")
                {
                    currentButton.Tag = "sandy";
                    currentButton.BackgroundImage = Properties.Resources.sandy;
                }
                else if (pickedID == "gary")
                {
                    currentButton.Tag = "gary";
                    currentButton.BackgroundImage = Properties.Resources.gary;
                }
                else if (pickedID == "mrkrabs")
                {
                    currentButton.Tag = "mrkrabs";
                    currentButton.BackgroundImage = Properties.Resources.mrkrabs;
                }
                else if (pickedID == "plankton")
                {
                    currentButton.Tag = "plankton";
                    currentButton.BackgroundImage = Properties.Resources.plankton;
                }
                else if (pickedID == "squidward")
                {
                    currentButton.Tag = "squidward";
                    currentButton.BackgroundImage = Properties.Resources.squidward;
                }
                else if (pickedID == "flowers")
                {
                    currentButton.Tag = "flowers";
                    currentButton.BackgroundImage = Properties.Resources.flowers;
                }            
            }
            else if (rbnFriends.Checked)
            {
                //Change the background image of button to whatever Friends character user clicked on
                if (pickedID == "gunther")
                {
                    currentButton.Tag = "gunther";
                    currentButton.BackgroundImage = Properties.Resources.gunther;
                }
                else if (pickedID == "lisa")
                {
                    currentButton.Tag = "lisa";
                    currentButton.BackgroundImage = Properties.Resources.lisa;
                }
                else if (pickedID == "jennifer")
                {
                    currentButton.Tag = "jennifer";
                    currentButton.BackgroundImage = Properties.Resources.jennifer;
                }
                else if (pickedID == "matt")
                {
                    currentButton.Tag = "matt";
                    currentButton.BackgroundImage = Properties.Resources.matt;
                }
                else if (pickedID == "matthew")
                {
                    currentButton.Tag = "matthew";
                    currentButton.BackgroundImage = Properties.Resources.matthew;
                }
                else if (pickedID == "courtney")
                {
                    currentButton.Tag = "courtney";
                    currentButton.BackgroundImage = Properties.Resources.courtney;
                }
                else if (pickedID == "david")
                {
                    currentButton.Tag = "david";
                    currentButton.BackgroundImage = Properties.Resources.david;
                }
                else if (pickedID == "janice")
                {
                    currentButton.Tag = "janice";
                    currentButton.BackgroundImage = Properties.Resources.janice;
                }
            }

            //Increment flip counter
            flippedCards++;

            //Enable button once first card is flipped
            if (flippedCards == 1)
            {
                a = currentButton;
                a.Name = pickedID;
                a.Enabled = false;
            }
            //Enable button once second card is flipped
            else if (flippedCards == 2)
            {
                b = currentButton;
                b.Name = pickedID;
                b.Enabled = false;

                //Check to see if cards match
                if (a.Name == b.Name)
                {
                    //Increment match counter
                    matchCounter++;
                    //Keep the pair on the board once match has been found & reset flip counter to 0 so user can try to find another pair
                    a.Visible = true;
                    b.Visible = true;
                    a.Enabled = false;
                    b.Enabled = false;
                    flippedCards = 0;

                    //Check to see if user found all pairs
                    if (matchCounter == 8)
                    {
                        //Make the current player the first player
                        PlayerModel playermodel = new PlayerModel(txtCurrentPlayer.Text, 1);

                        //Turn off timer
                        isActive = false;

                        //Reset timer
                        playermodel.resetTime();

                        //Save the time                                                        
                        timeSet();

                        //Changed logo based on theme
                        if (rbnHarryPotter.Checked)
                        {
                            //Resetting background to harrypotterlogo on board
                            btn0.BackgroundImage = harrypotterlogo;
                            btn1.BackgroundImage = harrypotterlogo;
                            btn2.BackgroundImage = harrypotterlogo;
                            btn3.BackgroundImage = harrypotterlogo;
                            btn4.BackgroundImage = harrypotterlogo;
                            btn5.BackgroundImage = harrypotterlogo;
                            btn6.BackgroundImage = harrypotterlogo;
                            btn7.BackgroundImage = harrypotterlogo;
                            btn8.BackgroundImage = harrypotterlogo;
                            btn9.BackgroundImage = harrypotterlogo;
                            btn10.BackgroundImage = harrypotterlogo;
                            btn11.BackgroundImage = harrypotterlogo;
                            btn12.BackgroundImage = harrypotterlogo;
                            btn13.BackgroundImage = harrypotterlogo;
                            btn14.BackgroundImage = harrypotterlogo;
                            btn15.BackgroundImage = harrypotterlogo;
                        }
                        else if (rbnSpongebob.Checked)
                        {
                            //Resetting background to spongeboblogo on board
                            btn0.BackgroundImage = spongeboblogo;
                            btn1.BackgroundImage = spongeboblogo;
                            btn2.BackgroundImage = spongeboblogo;
                            btn3.BackgroundImage = spongeboblogo;
                            btn4.BackgroundImage = spongeboblogo;
                            btn5.BackgroundImage = spongeboblogo;
                            btn6.BackgroundImage = spongeboblogo;
                            btn7.BackgroundImage = spongeboblogo;
                            btn8.BackgroundImage = spongeboblogo;
                            btn9.BackgroundImage = spongeboblogo;
                            btn10.BackgroundImage = spongeboblogo;
                            btn11.BackgroundImage = spongeboblogo;
                            btn12.BackgroundImage = spongeboblogo;
                            btn13.BackgroundImage = spongeboblogo;
                            btn14.BackgroundImage = spongeboblogo;
                            btn15.BackgroundImage = spongeboblogo;
                        }
                        else if (rbnFriends.Checked)
                        {
                            //Resetting background to friendslogo on board
                            btn0.BackgroundImage = friendslogo;
                            btn1.BackgroundImage = friendslogo;
                            btn2.BackgroundImage = friendslogo;
                            btn3.BackgroundImage = friendslogo;
                            btn4.BackgroundImage = friendslogo;
                            btn5.BackgroundImage = friendslogo;
                            btn6.BackgroundImage = friendslogo;
                            btn7.BackgroundImage = friendslogo;
                            btn8.BackgroundImage = friendslogo;
                            btn9.BackgroundImage = friendslogo;
                            btn10.BackgroundImage = friendslogo;
                            btn11.BackgroundImage = friendslogo;
                            btn12.BackgroundImage = friendslogo;
                            btn13.BackgroundImage = friendslogo;
                            btn14.BackgroundImage = friendslogo;
                            btn15.BackgroundImage = friendslogo;
                        }           

                        //Alternating/switching between players
                        if (txtCurrentPlayer.Text.Equals(txtPlayerAName.Text))
                        {                         
                            //Make current player the second player & reset board
                            txtCurrentPlayer.Text = txtPlayerBName.Text;
                            currentPlayer = playersList[1];
                            setBoard();

                            //Reset timer to start from 0 for next player & turn on it off
                            playermodel.resetTime();
                            isActive = false;                       
                            lblMinutes.Text = "00";
                            lblSeconds.Text = "00";
                            lblMilliseconds.Text = "00";
                            timeMilli = 0;
                            timeMin = 0;
                            timeSec = 0;
                            matchCounter = 0;
                        }
                        else
                        {
                            //Turn off timer
                            isActive = false;

                            //Calling method to find winner
                            PlayerModel winner = boardmodel.isWinner(playersList[0], playersList[1]);
                            if (winner != null)
                            {
                                MessageBox.Show(winner.GetName().ToString() + " won with a time of " + winner.getMinutes() + " minutes, " + winner.getSeconds() + " seconds, " + winner.getMilliseconds() + " milliseconds. \n" + "Game Over!!");
                            }
                            else
                            {
                                MessageBox.Show("No one won!");
                            }
                        }
                    }
                }

                //If cards do not match, change button background back to "front" of card -> harrypotterlogo/spongeboblogo/friendslogo image (depending on theme selected using radio button)
                else
                {
                    MessageBox.Show("Not a match, try again!");

                    if (rbnHarryPotter.Checked)
                    {
                        a.BackgroundImage = harrypotterlogo;
                        b.BackgroundImage = harrypotterlogo;
                    }
                    else if (rbnSpongebob.Checked)
                    {
                        a.BackgroundImage = spongeboblogo;
                        b.BackgroundImage = spongeboblogo;
                    }
                    else if (rbnFriends.Checked)
                    {
                        a.BackgroundImage = friendslogo;
                        b.BackgroundImage = friendslogo;
                    }
              
                    //Re enable both cards
                    a.Enabled = true;
                    b.Enabled = true;

                    //Reset flipped cards to 0 if they do not match & make card 1 & 2 selected null
                    flippedCards = 0;
                    a = null;
                    b = null;
                }
            }
        }

        private void setBoard()
        {
            //Calling randomize method from BoardModel  & randomly assigning each tag to a button on the board
            String[] randomTags = boardmodel.randomizeBoard();
            btn0.Tag = randomTags[0];
            btn1.Tag = randomTags[1];
            btn2.Tag = randomTags[2];
            btn3.Tag = randomTags[3];
            btn4.Tag = randomTags[4];
            btn5.Tag = randomTags[5];
            btn6.Tag = randomTags[6];
            btn7.Tag = randomTags[7];
            btn8.Tag = randomTags[8];
            btn9.Tag = randomTags[9];
            btn10.Tag = randomTags[10];
            btn11.Tag = randomTags[11];
            btn12.Tag = randomTags[12];
            btn13.Tag = randomTags[13];
            btn14.Tag = randomTags[14];
            btn15.Tag = randomTags[15];
        }
    
        private void btnLetsPlay_Click(object sender, EventArgs e)
        {
            //Disabling the different theme button (we don't want user to change theme once game starts)
            btnDifferentTheme.Enabled = false;

            //Saving names entered into player objects
            string playerAName = txtPlayerAName.Text;
            string playerBName = txtPlayerBName.Text;

            //Checking to see if user selected a theme
            if (!rbnHarryPotter.Checked && !rbnSpongebob.Checked && !rbnFriends.Checked)
            {
                MessageBox.Show("Please select a theme you would like to play!");

                //Disable done button so user cannot complete their turn without finding all matches
                btnDone.Enabled = false;
            }
            else if (gameCount > 0)
            {
                //Disable done button so user cannot complete their turn without finding all matches
                btnDone.Enabled = false;

                //1st player in index
                currentPlayer = playersList[0];
                return;
            }         

            //Checks to see if the names match
            else if  ((playerAName.Length > 0 && playerBName.Length > 0) && (playerAName != playerBName))
            {
                //Enable done button so user cannot complete their turn without finding all matches & enable lets play
                btnDone.Enabled = true;
                btnLetsPlay.Enabled = true;

                //Instantiating 2 players & adding them to the list
                PlayerModel p;
                p = new PlayerModel(playerAName, 1);
                playersList.Add(p);
                p = new PlayerModel(playerBName, 2);
                playersList.Add(p);

                currentPlayer = playersList[0]; // ref to player 1
                txtCurrentPlayer.Text = playerAName.ToString();

                //Make board visible
                layoutPanel.Visible = true;

                //Make current player enabled so user can't change whose turn it is
                txtCurrentPlayer.Enabled = false;

                MessageBox.Show("Get ready, the timer will start once you close this!");

                //Start timer
                isActive = true;

                //Checking which theme is selected & changing "front side" of card to match selected theme
                if (rbnHarryPotter.Checked)
                {
                    //Hide other 2 buttons to prevent user from changing the theme while playing the game
                    rbnSpongebob.Visible = false;
                    rbnFriends.Visible = false;

                    boardmodel = new BoardModel("rbnHarryPotter");
                    btn0.BackgroundImage = harrypotterlogo;
                    btn1.BackgroundImage = harrypotterlogo;
                    btn2.BackgroundImage = harrypotterlogo;
                    btn3.BackgroundImage = harrypotterlogo;
                    btn4.BackgroundImage = harrypotterlogo;
                    btn5.BackgroundImage = harrypotterlogo;
                    btn6.BackgroundImage = harrypotterlogo;
                    btn7.BackgroundImage = harrypotterlogo;
                    btn8.BackgroundImage = harrypotterlogo;
                    btn9.BackgroundImage = harrypotterlogo;
                    btn10.BackgroundImage = harrypotterlogo;
                    btn11.BackgroundImage = harrypotterlogo;
                    btn12.BackgroundImage = harrypotterlogo;
                    btn13.BackgroundImage = harrypotterlogo;
                    btn14.BackgroundImage = harrypotterlogo;
                    btn15.BackgroundImage = harrypotterlogo;
                }
                else if (rbnSpongebob.Checked)
                {
                    //Hide other 2 buttons to prevent user from changing the theme while playing the game
                    rbnHarryPotter.Visible = false;
                    rbnFriends.Visible = false;

                    boardmodel = new BoardModel("rbnSpongebob");
                    btn0.BackgroundImage = spongeboblogo;
                    btn1.BackgroundImage = spongeboblogo;
                    btn2.BackgroundImage = spongeboblogo;
                    btn3.BackgroundImage = spongeboblogo;
                    btn4.BackgroundImage = spongeboblogo;
                    btn5.BackgroundImage = spongeboblogo;
                    btn6.BackgroundImage = spongeboblogo;
                    btn7.BackgroundImage = spongeboblogo;
                    btn8.BackgroundImage = spongeboblogo;
                    btn9.BackgroundImage = spongeboblogo;
                    btn10.BackgroundImage = spongeboblogo;
                    btn11.BackgroundImage = spongeboblogo;
                    btn12.BackgroundImage = spongeboblogo;
                    btn13.BackgroundImage = spongeboblogo;
                    btn14.BackgroundImage = spongeboblogo;
                    btn15.BackgroundImage = spongeboblogo;
                }
                else if (rbnFriends.Checked)
                {
                    //Hide other 2 buttons to prevent user from changing the theme while playing the game
                    rbnHarryPotter.Visible = false;
                    rbnSpongebob.Visible = false;

                    boardmodel = new BoardModel("rbnFriends");
                    btn0.BackgroundImage = friendslogo;
                    btn1.BackgroundImage = friendslogo;
                    btn2.BackgroundImage = friendslogo;
                    btn3.BackgroundImage = friendslogo;
                    btn4.BackgroundImage = friendslogo;
                    btn5.BackgroundImage = friendslogo;
                    btn6.BackgroundImage = friendslogo;
                    btn7.BackgroundImage = friendslogo;
                    btn8.BackgroundImage = friendslogo;
                    btn9.BackgroundImage = friendslogo;
                    btn10.BackgroundImage = friendslogo;
                    btn11.BackgroundImage = friendslogo;
                    btn12.BackgroundImage = friendslogo;
                    btn13.BackgroundImage = friendslogo;
                    btn14.BackgroundImage = friendslogo;
                    btn15.BackgroundImage = friendslogo;
                }

                //Randoming button images
                setBoard();
            }
            else
            {
                //Display message telling user to enter their names & set focus to textbox
                MessageBox.Show("One or both names are blank or names are the same.  Reenter name(s).", "Entry Error!");
                txtPlayerAName.Focus();
                txtPlayerAName.Enabled = true;
                txtPlayerBName.Enabled = true;
            }              
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //Start timer
            isActive = true;

            //Enable all buttons again
            btn0.Enabled = true;
            btn5.Enabled = true;
            btn13.Enabled = true;
            btn6.Enabled = true;
            btn1.Enabled = true;
            btn12.Enabled = true;
            btn8.Enabled = true;
            btn11.Enabled = true;
            btn3.Enabled = true;
            btn7.Enabled = true;
            btn14.Enabled = true;
            btn4.Enabled = true;
            btn9.Enabled = true;
            btn2.Enabled = true;
            btn10.Enabled = true;
            btn15.Enabled = true;
        }

        //Method takes times from labels, parses them & saves it to current player
        public void timeSet()
        {
            //Parsing labels for time
            timeMin = int.Parse(lblMinutes.Text);
            timeSec = int.Parse(lblSeconds.Text);
            timeMilli = int.Parse(lblMilliseconds.Text);

            //Setting the times the for each player
            currentPlayer.setTime(timeMin, timeSec, timeMilli);
        }

        //Formats labels to have correct time format
        public void drawTime()
        {
            lblMinutes.Text = String.Format("{0:00}", timeMin);
            lblSeconds.Text = String.Format("{0:00}", timeSec);
            lblMilliseconds.Text = String.Format("{0:00}", timeMilli);
        }
            

        //Increment timer by seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                timeMilli++;

                if (timeMilli >= 60)
                {
                    timeSec++;
                    timeMilli = 0;
                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }

            //Calling method to format labels
            drawTime();
        }

        //Code below is for background music & does not relate to viewable board so we did not put it in the BoardModel class
        //Music Check is actually a checkbox, the appearance has been changed through properties so it looks like a button
        private void btnMusicCheck_CheckedChanged(object sender, EventArgs e)
        {
            //If no radio button is selected for theme/song, notify the user & disable select different theme
            if (!rbnHarryPotter.Checked && !rbnSpongebob.Checked && !rbnFriends.Checked)
            {
                MessageBox.Show("You cannot play the music if you have not selected a theme. Please select one now.");
                btnDifferentTheme.Enabled = false;
                btnLetsPlay.Enabled = false;
            }
            else
            {
                btnLetsPlay.Enabled = true;

                //Enable select different theme
                btnDifferentTheme.Enabled = true;

                //If Harry Potter is selected, hide all other radio buttons & change button text to play/stop & play/stop song each time user clicks button
                if (rbnHarryPotter.Checked)
                {
                    rbnHarryPotter.Visible = true;
                    rbnSpongebob.Visible = false;
                    rbnFriends.Visible = false;

                    if (btnMusicCheck.Checked)
                    {
                        btnMusicCheck.Text = "Stop Music";
                        harrypotter.PlayLooping();
                    }
                    else
                    {
                        btnMusicCheck.Text = "Play Music";
                        harrypotter.Stop();
                    }
                }
                //If SpongeBob is selected, hide all other radio buttons & change button text to play/stop & play/stop song each time user clicks button
                else if (rbnSpongebob.Checked)
                {
                   // boardmodel.selectTheme("spongebob");
                    rbnHarryPotter.Visible = false;
                    rbnSpongebob.Visible = true;
                    rbnFriends.Visible = false;

                    if (btnMusicCheck.Checked)
                    {
                        btnMusicCheck.Text = "Stop Music";
                        spongebob.PlayLooping();
                    }
                    else
                    {
                        btnMusicCheck.Text = "Play Music";
                        spongebob.Stop();
                    }
                }
                //If Friends is selected, hide all other radio buttons & change button text to play/stop & play/stop song each time user clicks button
                else if (rbnFriends.Checked)
                {
                    rbnHarryPotter.Visible = false;
                    rbnSpongebob.Visible = false;
                    rbnFriends.Visible = true;

                    if (btnMusicCheck.Checked)
                    {
                        btnMusicCheck.Text = "Stop Music";
                        friends.PlayLooping();
                    }
                    else
                    {
                        btnMusicCheck.Text = "Play Music";
                        friends.Stop();
                    }
                }
            }
        }

        private void btnDifferentTheme_Click(object sender, EventArgs e)
        {

            //If no radio button is selected for theme/song, notify the user & disable select different theme
            if (!rbnHarryPotter.Checked && !rbnSpongebob.Checked && !rbnFriends.Checked)
            {
                MessageBox.Show("You cannot select a different theme if you did not previously select one. Please select one now.");
                btnDifferentTheme.Enabled = false;
                btnLetsPlay.Enabled = false;
            }
            else
            {
                //Enable different theme button
                btnDifferentTheme.Enabled = true;

                //Change Play Music text back to Play Music for new selected theme
                btnMusicCheck.Text = "Play Music";
                btnMusicCheck.Checked = false;

                //Stop current song, make all radio buttons visible & unchecked
                harrypotter.Stop();
                spongebob.Stop();
                friends.Stop();
                rbnHarryPotter.Visible = true;
                rbnSpongebob.Visible = true;
                rbnFriends.Visible = true;
                rbnHarryPotter.Checked = false;
                rbnSpongebob.Checked = false;
                rbnFriends.Checked = false;                         
            }
        }

        //Closes form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}