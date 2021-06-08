# Seismity
3D Visualizer of recent Earthquakes

Technologies used:

| Technology | Link |
| --- | --- |
| Unity Engine | https://unity.com/ |
| Web Request | https://docs.microsoft.com/pl-pl/dotnet/api/system.net.webrequest?view=net-5.0 |
| USGS Earthquake CSV feed | https://earthquake.usgs.gov/earthquakes/feed/v1.0/csv.php |

Functions:

| Id | Category | Name | Description | Priority(1-3) |
| --- | --- |
| W0 | Function | Camera Controller | Camera Controller is used to handle all camera movement, translations and rotations | 3 |
| W1 | Function | Earthquake Controller | Responsible for getting data from CSV feed and mapping it onto sphere | 3 |
| W3 | Testing | Unit Tests | Executed to check if our code is performing well with different cases | 2 |
| W2 | Graphics | UI | Responsible for displaying additional informations, buttons and lists  | 2 |
| W4 | Graphics | Post-Processsing | Handles graphical enhacements to visualizator like: Bloom, Sharpen, Motion Blur, Vignette etc. | 1 |

Bugs:

| Bug | Description | Fixed? | Possible fix |
| --- | --- |
| Incorrect positions | Earthquakes positions are offset from their local locations with no evident pattern | X | Try new math methods or replace current Earth 3D Model with better one |

Screenshots:
!["0"](/Assets/Screenshots/0.png?raw=true)
!["1"](/Assets/Screenshots/1.png?raw=true)
!["2"](/Assets/Screenshots/2.png?raw=true)
