using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Scripts
{
    internal class Controller
    {
        const string controllerFileName = "ControllerFile.dat";

        public string strNewJob;
        public string strCurrentJob;
        //set pay amount for each job
        //when job selected save amount with job
        //go to main. get amount and add to timer for amount paid

        public void CreateControllerFile()
        {
            if (!File.Exists(controllerFileName))
            {
                using (var stream = File.Open(controllerFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        writer.Write("No Job");
                    }
                }
            }
            else
            {
                ReadControllerFile();
            }
        }
        public void UpDateControllerFile()
        {
            if (File.Exists(controllerFileName))
            {
                using (var stream = File.Open(controllerFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        writer.Write(strNewJob);
                    }
                }
            }
        }

        public void ReadControllerFile()
        {
            if (File.Exists(controllerFileName))
            {
                using (var stream = File.Open(controllerFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        strCurrentJob = reader.ReadString();
                    }
                }

            }
        }
    }
}
