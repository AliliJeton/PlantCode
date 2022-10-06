using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCode.Tests
{
    [TestClass()]
    public class CreatePlantTests
    {
        CreatePlant plant = new CreatePlant();

        [TestMethod()]
        public void createPlantTest()
        {
            List<string> emptyList = new List<string>();
            string title = "test";
            string theme = "dark___";

            string output = plant.createPlant(ref emptyList, title, theme);

            Assert.AreEqual("@startuml" + System.Environment.NewLine +
                "!theme dark" + System.Environment.NewLine +
                "Title test" + System.Environment.NewLine +
                "@enduml" + System.Environment.NewLine, output);   
        }

        [TestMethod()]
        public void cPlantWithInput()
        {
            List<string> emptyList = new List<string>();
            emptyList.Add("Hallo -down-> Jeton");
            emptyList.Add("Wie gehts?");
            string title = "test";
            string theme = "dark";

            string output = plant.createPlant(ref emptyList, title, theme);

            Assert.AreEqual("@startuml" + System.Environment.NewLine +
                "!theme dark" + System.Environment.NewLine +
                "Title test" + System.Environment.NewLine +
                "@enduml" + System.Environment.NewLine, output);
        }

    }
}
