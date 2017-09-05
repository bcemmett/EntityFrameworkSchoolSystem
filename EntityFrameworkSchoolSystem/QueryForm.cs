using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace EntityFrameworkSchoolSystem
{
    public partial class QueryForm : Form
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly StringBuilder _outputBuffer = new StringBuilder();
        private DataLayer _data;

        public QueryForm()
        {
            InitializeComponent();
            _data = new DataLayer();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            StartTest("1");
            string result = _data.DoProblem1();
            EndTest(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartTest("2");
            string result = _data.DoProblem2();
            EndTest(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartTest("3");
            string result = _data.DoProblem3();
            EndTest(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartTest("4");
            string result = _data.DoProblem4();
            EndTest(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StartTest("5");
            string result = _data.DoProblem5();
            EndTest(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartTest("6");
            string result = _data.DoProblem6();
            EndTest(result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StartTest("7");
            string result = _data.DoProblem7();
            EndTest(result);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StartTest("8");
            string result = _data.DoProblem8();
            EndTest(result);
        }

        private void StartTest(string testName)
        {
            _timer.Restart();
            textBoxResults.Text = String.Empty;
            labelTime.Text = String.Empty;
            labelStatus.Text = $"Doing work for test {testName}";
            _outputBuffer.Clear();
            Refresh();
        }

        private void EndTest(string result)
        {
            textBoxResults.Text = result;
            labelTime.Text = (_timer.ElapsedMilliseconds / 1000.0) + " s";
            labelStatus.Text = "Done";
            _timer.Stop();
        }
    }
}