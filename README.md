# OVERVIEW #

**Title**: People Alive Graph
 
**Platform**: PC Standalone + iOS & Android 

**Target**: Unity developers 
 
**Release date**: March, 2017 

**Owner**: Kateryna Levshova

People Alive Graph is an accurate graph which visualizes a solution of the particular task: Given a list of people with their birth and end years (all between 1900 and 2000), find the year with the most number of people alive.  

# FEATURES #

* Multiplatform
* Configuration possibilities: changing position, size and color of the graph’s elements
* Easy to use

# DEMO #

Demo video on YouTube - [PeopleAliveGraph  - Unity3D, C# realization](https://youtu.be/mWc8a6zNogE)

# HOW TO USE #
1. Import GraphDisplayCanvas prefab, LineTexture and LineGenerator script.
1. Drag GraphDisplayCanvas  from the Projec window on to the Hierarchy window.
1. Unfold GraphDisplayCanvas object to see its structure.
1. Hit Play.
1. Evaluate results.
1. Click Restart button to create a new list of people with new data.

SCALING AND POSITIONING IN EDITOR MODE 

You can change size of the Graph on the Scene using Width and Height properties of Rect Transform component of LineGeneratorImage object in Editor mode. 

To change positions you can use Pos X and Pos Y properties of Rect Transform component.

The same you can simply do with your mouse on the Scene in Editor. 
Do not change any other properties of Rect Transform.

BACKGROUND COLOR AND TRANSPARENCY

To change the background color and transparency of the Graph use Color property of Image component of the LineGeneratorImage object in the Inspector window. You can do this in both Editor and Game modes.

GRAPH COLOR

To change Graph main color go to Line Generator component of LineGeneratorImage object in Inspector window. Change Graph Color property. You can do this in both Edit and Game modes. Remember if you want to save this color permanently you need to do this in Edit mode and click Apply button in the top of Inspector window to save the setting in prefab.