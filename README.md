# TestStories
Developer Coding Test - Fernando Chessani

Stepts to run and test the project

1.- Clone the repository 
2.- If you see the project in Visual Studio, run the program with the "Run" button at the top center 
2.1.- If you prefer to run it with the terminal, navigate to the "Stories" directory in the cmd, then build the program with 'dotnet build' and run it with 'dotnet run'
3.- Open a web browser or a tool (Postman -> Method GET) or other tool) and paste the localhost URL provided by the program: 'http://localhost:5000'
4.- Add the path to consult the stories: 'principal/5', replacing '5' with the number of stories you want to see. 
  * 'principal' Is the name of the controller to consult the stories. 
5.- Final url will look like this: 'http://localhost:5000/principal/5'

Comments

This test represent a challenge for me, I seen some points thah i consider are importants
1.- Documentation about the endpoints and the use are clear, but some usage examples and a references explaining what the fiels in the JSON of the stories details mean.
2.- Expose only neccesary fields to consume the API in a real situation.
3.- I can optimizar the querys and the way to serialize and deserialize the JSON.
4.- Optimize a cache more efficiently, check if the information in the API have changes and in a cetain time restore the cache qith new information.


Thank's for the evaluation!
