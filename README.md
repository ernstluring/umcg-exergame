# umcg-exergame
This project was an assignment from the game development studio [8D Games][8dgames]. They were creating an exercise game focused on balance exercise and fall prevention for elderly people in collaboration with UMCG Groningen. A Kinect registers the movement of the balance exercises and converts these in-game to ice skating motions. The data of the players movement collected by the Kinect can be forwarded to a physician or physiotherapist who can inspect this data and see for example if the patient leans to much to the left or right and/or in what kind of physical shape the patient is in.

[8dgames]: www.8d-games.nl

For this project I created a bunch of Maya and Unity tools:
* BackUpper is a Maya tool written in python. I saw that a lot of artists used "save as" often and I thought: "that can go quicker and easier". So I started writing a backup plugin that saves a new scene with a incrementing number with a press of a button.
* AlignX, AlignY, AlignZ are a Maya tools I created that straightens an edge between vertices. Currently it only works with two vertices, but I'm planning to extended it so it can work with more vertices. I created this tool when I saw there was uv mapping tool that does the same thing and I thought it also can be useful during modeling.
* GetObjectsByName, GiveParent and ReplaceGameObjects are a bunch of Unity tools I created to make the creation of levels in Unity easier.
