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

        public string strCurrentJob;
        public string strPlayerIncome;
        public string strCurrentPlayerMoney;

        public void CreateControllerFile()
        {
            if (!File.Exists(controllerFileName))
            {
                using (var stream = File.Open(controllerFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        writer.Write("00.00");
                        writer.Write("00.00");
                        writer.Write("No Job");
                    }
                }
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
                        writer.Write(strCurrentPlayerMoney);
                        writer.Write(strPlayerIncome);
                        writer.Write(strCurrentJob);
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
                        strCurrentPlayerMoney = reader.ReadString();
                        strPlayerIncome = reader.ReadString();
                        strCurrentJob = reader.ReadString();
                    }
                }

            }
        }
    }
}
