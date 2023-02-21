﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace every_danik_
{
    internal class jsonchik
    {
        public static void Ser<T>(T listik, string filename)
        {


            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(listik);
            File.WriteAllText(desktop + "\\" + filename, json);
        }
        public static T Deser<T>(string filename)
        {
           
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(filename);
            T humans = JsonConvert.DeserializeObject<T>(json); 
            return humans;


        }
    }
}
