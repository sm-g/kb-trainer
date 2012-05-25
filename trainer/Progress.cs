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
            ReadExercises(LoadFromCsv());
        }

        private void ReadExercises(Exercise[] exercises)
        {
            dgv.DataSource = exercises;

            graph.Bind(exercises, "speeds", "Id", "Speed");
        }

        public static void SaveToXml(SourceText source, Statistic statistic)
        {
            statistic.CalcPressures();

            XDocument doc;

            using (var file = File.OpenText(FILE + ".xml"))
            {
                doc = XDocument.Load(file);
            }

            XElement durations;
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(List<Pressure>));
                serializer.Serialize(stream, statistic.pressures);
                stream.Position = 0;
                using (var reader = XmlReader.Create(stream))
                {
                    durations = XElement.Load(reader);
                }
            }
            durations.Name = "pressures";
            durations.RemoveAttributes();

            var newExercise = 
                    new XElement("exercise",
                        new XAttribute("id", doc.Root.Elements().Count() + 1),
                        new XAttribute("date", DateTime.Now.ToShortDateString()),
                        new XAttribute("text", source.Title),
                        new XAttribute("passed", statistic.PassedChars),
                        new XAttribute("errors", statistic.Errors),
                        new XAttribute("time", statistic.TotalPrintingTime),
                        new XAttribute("rhythm", statistic.Rhythmicity),
                        durations);

            doc.Root.Add(newExercise);
            doc.Save(FILE + ".xml");
        }
        public static void SaveToDsv(SourceText source, Statistic statistic)
        {
            statistic.CalcPressures();

            var sb = new StringBuilder();

            sb.Append(DateTime.Now.ToShortDateString());    sb.Append(Delimeters.Attribute);
            sb.Append(source.Title);                        sb.Append(Delimeters.Attribute);
            sb.Append(statistic.PassedChars);               sb.Append(Delimeters.Attribute);
            sb.Append(statistic.Errors);                    sb.Append(Delimeters.Attribute);
            sb.Append(statistic.TotalPrintingTime);         sb.Append(Delimeters.Attribute);
            sb.Append(statistic.Rhythmicity);               sb.Append(Delimeters.Attribute);
            foreach (var p in statistic.pressures)
            {
                sb.Append(p.Char);                          sb.Append(Delimeters.PressureAttr);
                sb.Append(p.Amount);                        sb.Append(Delimeters.PressureAttr); 
                sb.Append(p.Duration);                      sb.Append(Delimeters.Pressure);
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(Delimeters.Exercise);

            using (var file = File.AppendText(FILE + ".dsv"))
            {
                file.Write(sb);
            }
        }
        public static Exercise[] LoadFromCsv()
        {
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
