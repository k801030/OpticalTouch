using System.Windows.Forms;
using System;
namespace OpticalTouch
{
    partial class FullScreenPaint
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closed);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // event handler
            this.KeyPress += new KeyPressEventHandler(MyOnKeyPress);

            //timer
            Timer t = new Timer();
            t.Interval = 20;
            t.Tick += new EventHandler(Timer_Tick);
            t.Enabled = true;

            

        }


        #endregion
        // when close, exit the program
        private void Form_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}

