using MapPlanClass;

namespace NavigationClass
{
    public class Trek
    {
        public char direction = '^';
        public int yCord;
        public int xCord;
        public int step = 1;
        public char obstacle = ' ';
        public bool motion = false;
    }

    public class Navigation
    {
        public List<int[]> pathWay;
        public int[] startPoint;

        public Navigation(MapPlan myPlan)
        {
            Console.WriteLine("Navigation Class initialized!");
            char[][] navPlan = myPlan.Plan;

            Trek startPosition = new Trek();
            startPosition = FindStartingPoint(navPlan);
        }

        public Trek FindStartingPoint(char[][] navPlan, char startChar = '^')
        {
            // outer for loop
            Trek startPoint = new Trek();
            startPoint.direction = startChar;
            // int[] startPoint = [0, 0];
            for (int i = 0; i < navPlan.Length; i++)
            {
                // inner for loop
                for (int j = 0; j < navPlan[i].Length; j++)
                {
                    if (navPlan[i][j] == startChar)
                    {
                        startPoint.xCord = j;
                        startPoint.yCord = i;
                        Console.WriteLine(
                            "Starting Point dir:{0}, Postion y,x:{1},{2}",
                            startPoint.direction,
                            startPoint.yCord,
                            startPoint.xCord
                        );
                        return startPoint;
                    }
                }
            }

            return startPoint;
        }

        public void Patrolling(char[][] navPlan, Trek position) { }

        public int[] nextLocation(char[][] navPlan, char direction)
        {
            switch (direction)
            {
                case '>':
                    //
                    return [1, 1];
                case 'v':
                    //
                    return [1, 1];
                case '<':
                    //
                    return [1, 1];
                case '^':
                    //
                    return [1, 1];
                default:
                    return [0, 0];
            }
        }
    }
}

/* terms
location
track
waypoint
goal
obstacle
initialize
*/
