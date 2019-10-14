using System;
using System.Windows.Forms;

namespace LambdaTest
{
    partial class LambdaTest2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LambdaTest2";

            ////创建一个button实例
            //Button button1 = new Button();
            //button1.Text = "click me";

            ////使用匿名方法订约事件
            //button1.Click += delegate (object sender, EventArgs e)
            //{
            //    ReportEvent("Click!", sender, e);
            //};

            //button1.KeyPress += delegate (object sender, KeyPressEventArgs e)
            //{
            //    ReportEvent("KeyDown", sender, e);
            //};

            //Form form = new Form();
            //form.Name = "test";
            //form.AutoSize = true;
            //form.Controls.Add(button1);

            //使用Lambda表达
            //新建一个button实例
            Button button1 = new Button() { Text = "click me" };

            //Lambda表达式订阅事件
            button1.Click += (sender, e) => ReportEvent("Click!", sender, e);
            button1.KeyPress += (sender, e) => ReportEvent("KeyDown", sender, e);

            //初始化对象
            Form form = new Form { Name = "test", AutoSize = true, Controls = { button1 } };

            //运行窗体
            Application.Run(form);
        }

        private void ReportEvent(string title, object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("event: {0}", title);
            Console.WriteLine("event object: {0}", sender);
            Console.WriteLine("event param: {0}", e.GetType());

            Console.WriteLine();
        }

        #endregion
    }
}