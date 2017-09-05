using System;
using System.Text;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        private StringBuilder _outputBuffer = new StringBuilder();

        private void WriteOutput(string row)
        {
            _outputBuffer.Append(row);
            _outputBuffer.Append(Environment.NewLine);
        }
    }
}