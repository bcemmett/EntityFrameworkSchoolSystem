using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EntityFrameworkSchoolSystem
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private Stopwatch _timer;

        private void button1_Click(object sender, EventArgs e)
        {
            StartTest("1");
            string result = DataLayer.DoProblem1();
            EndTest(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartTest("2");
            string result = DataLayer.DoProblem2();
            EndTest(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartTest("3");
            string result = DataLayer.DoProblem3();
            EndTest(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartTest("4");
            string result = DataLayer.DoProblem4();
            EndTest(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StartTest("5");
            string result = DataLayer.DoProblem5();
            EndTest(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartTest("6");
            string result = DataLayer.DoProblem6();
            EndTest(result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StartTest("7");
            string result = DataLayer.DoProblem7();
            EndTest(result);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StartTest("8");
            string result = DataLayer.DoProblem8();
            EndTest(result);
        }

        private void StartTest(string testName)
        {
            _timer = Stopwatch.StartNew();
            textBoxResults.Text = String.Empty;
            labelTime.Text = String.Empty;
            labelStatus.Text = $"Doing work for test {testName}";
            Refresh();
        }

        private void EndTest(string result)
        {
            textBoxResults.Text = result;
            labelTime.Text = (_timer.ElapsedMilliseconds / 1000.0) + " s";
            labelStatus.Text = "Done";
            _timer.Stop();
        }

        private void PrintThatFetchingData()
        {
            textBoxResults.Text = "Fetching data...";
            Refresh();
        }
    }
}