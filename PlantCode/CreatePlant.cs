using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCode
{
    public class CreatePlant
    {
        public string createPlant(ref List<string> states, string selectedTitel, string selectedTheme)
        {

            string plantUML = "";

            plantUML = "@startuml" + System.Environment.NewLine;
            plantUML = plantUML + "!theme " + selectedTheme + System.Environment.NewLine;
            plantUML = plantUML + "Title " + selectedTitel + System.Environment.NewLine;
            //plantUML = plantUML + "start" + System.Environment.NewLine;
            //states.ForEach(p => plantUML = plantUML + "State " + p + "" + System.Environment.NewLine);
            for (int i = 0; i < states.Count; i++)
            {
                if (!states[i].Contains("-down->"))
                {
                    plantUML = plantUML + "State " + states[i] + "" + System.Environment.NewLine;
                }
                else
                {

                    plantUML = plantUML + states[i] + "" + System.Environment.NewLine;
                }
            }
            //plantUML = plantUML +"stop" + System.Environment.NewLine;
            plantUML = plantUML + "@enduml" + System.Environment.NewLine;
            return plantUML;
        }


    }
}
