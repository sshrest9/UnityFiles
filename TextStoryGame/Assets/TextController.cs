using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    public Text text;
    enum States{MainRoom,Bathroom,Mirror,GuestRoom,Closet1,Hall,Bedroom2,Stairs,Kitchen,Bathroom2,LivingRoom,DiningRoom,Stairs2,Door,Closet2,Window,
                Suitcase,Pickup,Checkbody, Checkbody1,Note,Medkit, Flashlight};
    private States currentState;
    private bool pickUpKey = false;
    private bool pickUplight = false,pickUpMedkit=false,help=false;
	// Use this for initialization
	void Start () {
        text.text = "Press Enter to play";
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            currentState = States.MainRoom;
        }
    }

    // Update is called once per frame
    void Update () {
        if (currentState == States.MainRoom) { MainRoom(); }
        else if (currentState == States.Bathroom) { Bathroom(); }
        else if (currentState == States.GuestRoom) { GuestRoom(); }
        else if (currentState == States.Hall) { Hall(); }
        else if (currentState == States.Closet1) { Closet1(); }
        else if (currentState == States.Bedroom2) { Bedroom2(); }
        else if (currentState == States.Stairs) { Stairs(); }
        else if (currentState == States.Kitchen) { Kitchen(); }
        else if (currentState == States.Bathroom2) { Bathroom2(); }
        else if (currentState == States.LivingRoom) { LivingRoom(); }
        else if (currentState == States.DiningRoom) { DiningRoom(); }
        else if (currentState == States.Stairs2) { Stairs2(); }
        else if (currentState == States.Door) { Door(); }
        else if (currentState == States.Closet2) { Closet2(); }
        else if (currentState == States.Window) { Window(); }
        else if (currentState == States.Mirror) { Mirror(); }
        else if (currentState == States.Pickup) { PickUp(); }
        else if (currentState == States.Checkbody) { CheckBody(); }
        else if (currentState == States.Medkit) { Medkit(); }
        else if (currentState == States.Note) { Note(); }
        else if(currentState==States.Flashlight) { Light(); }
        else if(currentState==States.Checkbody1) { CheckBody2(); }
        else if (currentState==States.Suitcase) { SuitCase(); }
	}
    void MainRoom()
    {
        text.text = "Welcome to the house. Your goal is to escape, but the front door is locked and must find another way out. You are able to freely move around the house"+
                    "\n\n Press B to enter the Bathroom, H to enter the Hall";
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.Bathroom; }
        else if(Input.GetKeyDown(KeyCode.H)) { currentState = States.Hall; }
    }
    void Bathroom()
    {
        text.text = "There's something written on the bathroom mirror\n\n Press M to check the Mirror, R to Return to the Main Room";
        if (Input.GetKeyDown(KeyCode.M)) { currentState = States.Mirror; }
        else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.MainRoom; }
    }
    void Mirror()
    {
        text.text = "DON'T TRUST H...\n\n Press R to return to the Bathroom";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Bathroom; }
    }
    void GuestRoom()
    {
        text.text = "There is a suitcase in the room\n\n C to Check the suitcase, R to Return to the hall";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.Suitcase;}
        else if(Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }
    }
    void Hall()
    {
        text.text = "The lights are slowly flickering. You see trail of blood going into the other bedroom and the closet door is slightly opened."+
                    "\n\nPress C to open Closet, G to enter the Guest bedroom, B to enter the second Bedroom,S to go down the Stairs, R to Return to Main Bedroom";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.Closet1; }
        else if (Input.GetKeyDown(KeyCode.G)){ currentState = States.GuestRoom; }
        else if (Input.GetKeyDown(KeyCode.B)){ currentState = States.Bedroom2; }
        else if (Input.GetKeyDown(KeyCode.R)){ currentState = States.MainRoom ; }
        else if (Input.GetKeyDown(KeyCode.S)) { currentState = States.Stairs; }
    }
    void Closet1()
    {
        if (pickUpKey)
        {
            text.text = "There is knife covered with blood.\n\nR to Return to the Hall";
            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }

        }
        else
        {
            text.text = "There is knife covered with blood and a key.\n Who's blood is it?\n\nP to pick up the Key, R to Return to the Hall.";
            if (Input.GetKeyDown(KeyCode.P)) { currentState = States.Pickup; }
            else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }
        }
    }
    void PickUp()
    {
        text.text = "You picked up a Key\n\nPress R to return to the Hall";
        pickUpKey = true;
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }
    }
    void Bedroom2()
    {
        text.text = "As you enter the room you notice it's a child's room. You look around the room and see a body in the corner of the room." +
                    "The person is unconscious and has lost a lot of blood." +
                    "There is a loud sound coming from downstaris\n\nC to Check the body, R to Return to the Hall";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.Checkbody; }
        else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }
    }
    void CheckBody()
    {
        text.text = "As you inspect the body, you notice that the person was stabbed multiple times."+
                    "\n\nPress R to return to the Bedroom";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Bedroom2; }
    }
    void Stairs()
    {
        text.text = "You are on the main floor of the house." +
            "\n\nPress K to enter the Kitchen,L to enter Living room,D to enter Dining Room,S to go Downstairs,R to go Return upstairs.";
        if (Input.GetKeyDown(KeyCode.K)) { currentState = States.Kitchen; }
        else if (Input.GetKeyDown(KeyCode.D)) { currentState = States.DiningRoom; }
        else if (Input.GetKeyDown(KeyCode.L)) { currentState = States.LivingRoom; }
        else if (Input.GetKeyDown(KeyCode.B)) { currentState = States.Bathroom2; }
        else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Hall; }
        else if(Input.GetKeyDown(KeyCode.S)) { currentState = States.Stairs2; }
    }
    void Kitchen() {
        text.text = "The kitchen floor is covered with shatterd glass and the windows have been boarded up.On the counter there is a flashlight" +
           "\n\nPress P to Pickup flashlight,R to Return to the main floor";
        if (pickUplight)
        {
            text.text = "The kitchen floor is covered with shatterd glass and the windows have been boarded up" +
                   "\n\nPress R to Return to the main floor";
        }      
        if(Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
        else if(Input.GetKeyDown(KeyCode.P)) { currentState = States.Flashlight; }
    }
    void Bathroom2() { }
    void LivingRoom()
    {
        text.text = "There someone is sitting on the chair.They seem to be moving."
            +"\n\nPress C to Check body,R to Return to the main floor";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.Checkbody1; }
        else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
    }
    void CheckBody2()
    {
        text.text = "\"Please help I don't want to die.I was stabbed and i'm losing a lot of blood.\" he pleaded\n\n"+
            "Press H to Help him, R to return to the main floor.";
        if (pickUpMedkit)
        {
            HelpMan();
        }
        else
        {
            text.text = "You do not have supplies to help the man.\n\nR to return to the room";
            if(Input.GetKeyDown(KeyCode.R)) { currentState = States.LivingRoom;}

        }
    }
    void DiningRoom() {
        text.text = "There is a piece of paper on the table. Half of the paper is covered in blood and is unreadable." +
            "\n\nPress N to read Note,R to Return to the main floor";
        if (Input.GetKeyDown(KeyCode.N)) { currentState = States.Note; }
        else if(Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
    }
    void Stairs2() {
        if (pickUplight)
        {
            text.text = "The basement is packed with boxes and furniture, there is barely enough room to move around." +
                       "You notice there is a door at the back of the room and a closet right beside you." +
                       "\n\nC to open the closet, D to open the door,R to Return upstairs";
            if (Input.GetKeyDown(KeyCode.C)) { currentState = States.Closet2; }
            else if (Input.GetKeyDown(KeyCode.D)) { currentState = States.Door; }
            else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
        }       
        else {
            text.text = "It is very dark and you are unable to see." +
                      "\nTry to find a source of light" +
                      "\n\nPress R to Return upstairs";
            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
        }
    }
    void Door() {
        if (pickUpKey)
        {
            text.text = "You unlock the door with the key and proceed downstairs.In the room there was a single mattress in the middle, and there was a single lamp to light up the room." +
                        "Across the room there was an unboarded window." +
                        "\n\nPress W to open the Window,R to Return to the Basement";
            if (Input.GetKeyDown(KeyCode.W)) { currentState = States.Window;}
            else if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs2; }
        }
        else
        {
            text.text = "The door is locked there must be a key somewhere.\n\nPress R to Return to the Basement";
            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs2; }
        }
    }
    void Closet2() {
        if (!pickUpMedkit)
        {
            text.text = "The closet is filled with blankets and medical supplies.\n\nPress P to pick up Medkit,R to Return to the basement";
            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs2; }
            else if (Input.GetKeyDown(KeyCode.P)) { currentState = States.Medkit; }
        }
        else {
            text.text = "The closet is filled with blankets;\n\nPress R to Return to the basement";
            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs2; }
        }
    }
    void Medkit()
    {
        text.text = "You picked up the Medkit. It has bandages and a vial of Posion\n\nPress R to Return to the closet";
        pickUpMedkit = true;
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Closet2; }
    }
    void Note()
    {
        text.text = "I have lost count of how long we have been locked up in this house for.I don't know what he wants from us but, he keeps on talking on about someone he lost." +
            "Trying to fix his mistake and wanting to start over. I don't understand him at all. He treats us likes we're his family but keeps us hostage and doesn't let us leave." +
            "We have tired to figure out a way to escape but, so far we found nothing. There is something behind the door in the basement. He keeps the key\n" +
            "The rest of the note is covered in blood.\n\n" +
            "Press R to Return to the Kitchen";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Kitchen; }
    }
    void Light()
    {
        text.text= "You picked up the Flashlight\n\nPress R to Return to the kitchen";
        pickUplight = true;
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.Kitchen; }
    }
    void HelpMan() {
        text.text = "Press B to use Bandages, Press P to give him Poison";
        if (Input.GetKeyDown(KeyCode.B))
        {
            text.text = "You helped the man\n\nPress R to return to the main room";
            help = true;
            if(Input.GetKeyDown(KeyCode.R)) { currentState = States.Stairs; }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            text.text = "You gave him poison\n\"I should have figured that you would have killed me. You monster! Locking us up in this house for so long, forcing us to be your family just because they left you!\"He yelled\"You deserve to be alone\""+
                        "Moments later he died due to the poison\n\nPress R to return to the main room";
        }
    }
    void Window()
    {
        if (help)
        {
            text.text = "The man came running at you with a knife. He stabs you right right in the center of your chest. You're losing oxygen and losing a lot of blood\n" +
                        "\"This is what you get for keeping us prisoners in the house for so long\"He says \nYou slowly starting losing consciousness\n\n";
        }
        else
        {
            text.text = "As you open the window you start to recall what happened. You had held the two people hostage in your house as a substitute for you're children that they had killed."
                + "They took everything from you and in return you did the same thing to them.You made them pay for what they did to you. Then one day they decided to escape and you had no choice but to fight back"
                + "You injured the guy in the living room and left him there. After that you went upstairs to take care of the girl. You managed to stab her multiple times but, she was able to land a fatal blow on you"
                + "She started to crawl to the other room, where she died.The END!";
        }
    }
    void SuitCase()
    {
        text.text = "There is a pile of children clothing covered in blood\n\nR to return to the Room";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.GuestRoom; }
    }

}
