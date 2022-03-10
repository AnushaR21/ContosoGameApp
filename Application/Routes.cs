using System.Collections.Generic;

namespace Contoso_Game_Application.Application
{
    public class Routes
    {
              
        private IList<KeyValuePair<string, string>> routesList;
        public string Key { get; set; }
            public string Value { get; set; }


    public Routes()
        {
            routesList = new List<KeyValuePair<string, string>>();
            routesList.Add(new KeyValuePair<string, string>("A", "B"));
            routesList.Add(new KeyValuePair<string, string>("B", "C"));
            routesList.Add(new KeyValuePair<string, string>("C", "D"));
            routesList.Add(new KeyValuePair<string, string>("D", "E"));
            routesList.Add(new KeyValuePair<string, string>("A", "D"));
            routesList.Add(new KeyValuePair<string, string>("D", "A"));
            routesList.Add(new KeyValuePair<string, string>("C", "E"));
            routesList.Add(new KeyValuePair<string, string>("A", "E"));
            routesList.Add(new KeyValuePair<string, string>("E", "B"));
        }
       

        public int GetNumberOfPaths(string source, string destination, int maxStops)
        {
            
            return Dfs(source, destination, maxStops + 1);
        }


        private int Dfs(string currentNode, string destination, int stopsRemaining)
        {

            if (currentNode == destination)
            {
                if (stopsRemaining >= 0) return 1;
            }

            if (stopsRemaining < 0) return 0;


            int answer = 0;


           

            List<string> startPoint2 = new List<string>();
            List<string> startPoint1 = new List<string>();
            List<string> startPoint = new List<string>();

            foreach (KeyValuePair<string, string> route in routesList)
            {
                if(route.Value == destination)
                {
                     //get all sources for destination //B

                    if(route.Key== currentNode)
                    {
                        startPoint1.Add(route.Key);
                        answer++;
                    }
                    else
                    {
                        startPoint2.Add(route.Key);
                    }
                }
            }

        foreach(string startpoint1 in startPoint2)
            {
                foreach (KeyValuePair<string, string> route in routesList)
                {
                    if (route.Value == startpoint1)
                    {
                        if (route.Key == currentNode)
                        {
                            startPoint1.Add(route.Key);
                            answer++;
                                }
                        else
                        {
                            startPoint.Add(route.Key);
                        }//get all sources for destination  //B
                    }
                    else
                    {
                        

                    }
                }
            }

            foreach (string startpoint0 in startPoint)
            {
                foreach (KeyValuePair<string, string> route in routesList)
                {
                    if (route.Value == startpoint0)
                    {
                        if (route.Key == destination)
                        {
                            answer++;
                        }
                    }
                }
            }

            //answer = startPoint.Count;

         
            return answer;






        }

      
    }




}
