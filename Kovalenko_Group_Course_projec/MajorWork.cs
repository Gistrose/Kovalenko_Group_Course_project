﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovalenko_Group_Course_projec
{
    class MajorWork
    {
        private string SaveFileName;
        private string OpenFileName;
        public void WriteSaveFileName(string S)
        {
            this.SaveFileName = S;
        }
        public void WriteOpenFileName(string S)
        {
            this.OpenFileName = S;
        }
        private System.DateTime TimeBegin;
        private string Data;
        private string Result;
        public void SetTime()
        {
            this.TimeBegin = System.DateTime.Now;
        }
        public System.DateTime GetTime()
        { return this.TimeBegin; }
      
        public void Write(string D)
        {
            this.Data = D;
        }
        public string Read()
        {
            return this.Result;
        }
        public void Task()
        {
            if (this.Data.Length > 5)
            {
                this.Result = Convert.ToString(true);
            }
            else
            {
                this.Result = Convert.ToString(false);
            }
        }
        
    }
}
