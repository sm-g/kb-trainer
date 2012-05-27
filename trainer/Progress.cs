using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace trainer
{
    public partial class Progress : Form
    {
        const string FILE = "stat";

        public Progress()
        {
            InitializeComponent();
            ReadExercises(LoadFromDsv());
        }

        private void ReadExercises(Exercise[] exercises)
        {
            dgv.DataSource = exercises;

            graph.Bind(exercises, "speeds", "Id", "Speed");
        }

        public static void SaveToXml(SourceText source, Exercise result)
        {
            XDocument doc;
            if (File.Exists(FILE + ".xml"))
            {
                using (var file = File.OpenText(FILE + ".xml"))
                {
                    doc = XDocument.Load(file);
                }
            }
            else
            {
                doc = new XDocument();
                doc.Add(new XElement("statistic"));
            }

            XElement pressures;
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(List<Pressure>));
                serializer.Serialize(stream, result.Pressures);
                stream.Position = 0;
                using (var reader = XmlReader.Create(stream))
                {
                    pressures = XElement.Load(reader);
                }
            }
            pressures.Name = "pressures";
            pressures.RemoveAttributes();

            XElement newExercise = 
                    new XElement("exercise",
                        new XAttribute("id", doc.Root.Elements().Count() + 1),
                        new XAttribute("date", DateTime.Now.ToShortDateString()),
                        new XAttribute("text", source.Title),
                        new XAttribute("passed", result.PassedChars),
                        new XAttribute("errors", result.Errors),
                        new XAttribute("time", result.Time),
                        new XAttribute("rhythm", result.Rhythmicity),
                        pressures);

            doc.Root.Add(newExercise);
            doc.Save(FILE + ".xml");
        }
        public static void SaveToDsv(SourceText source, Exercise result)
        {
            var sb = new StringBuilder();

            sb.Append(DateTime.Now.ToShortDateString()); sb.Append(Delimeters.Attribute);
            sb.Append(source.Title);                     sb.Append(Delimeters.Attribute);
            sb.Append(result.PassedChars);               sb.Append(Delimeters.Attribute);
            sb.Append(result.Errors);                    sb.Append(Delimeters.Attribute);
            sb.Append(result.Time);                      sb.Append(Delimeters.Attribute);
            sb.Append(result.Rhythmicity);               sb.Append(Delimeters.Attribute);
            foreach (var p in result.Pressures)
            {
                sb.Append(p.Char);                       sb.Append(Delimeters.PressureAttr);
                sb.Append(p.Amount);                     sb.Append(Delimeters.PressureAttr); 
                sb.Append(p.Duration);                   sb.Append(Delimeters.Pressure);
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(Delimeters.Exercise);

            using (var file = File.AppendText(FILE + ".dsv"))
            {
                file.Write(sb);
            }
        }
        public static Exercise[] LoadFromDsv()
        {            
            if (!File.Exists(FILE + ".dsv"))
                return new Exercise[] {};

            string s;
            using (var file = File.OpenText(FILE + ".dsv"))
            {
                s = file.ReadToEnd();
            }
            string[] exercises = s.Split(Delimeters.Exercise);

            Exercise[] result = new Exercise[exercises.Length - 1];

            for (int i = 0; i < exercises.Length - 1; i++)
            {
                result[i] = new Exercise(exercises[i], i);
            }

            return result;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            int[] ids = new int[dgv.SelectedRows.Count];
            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {
                ids[i] = (int)dgv.SelectedRows[i].Cells["Id"].Value;
            }
            graph.HighlightSeriePoints("speeds", ids);
        }
    }

    public static class Delimeters
    {
        public const char Exercise = '\n';
        public const char Attribute = ';';
        public const char Pressure = '*';
        public const char PressureAttr = '%';
        public const char SafeChar = ',';
    }
}
