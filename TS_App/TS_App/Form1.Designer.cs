namespace TS_App
{
     partial class Form1
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
               this.txtbIP = new System.Windows.Forms.TextBox();
               this.txtbPort = new System.Windows.Forms.TextBox();
               this.txtbClientPort = new System.Windows.Forms.TextBox();
               this.label1 = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.label3 = new System.Windows.Forms.Label();
               this.label4 = new System.Windows.Forms.Label();
               this.txtbReceive = new System.Windows.Forms.TextBox();
               this.label5 = new System.Windows.Forms.Label();
               this.txtbSend = new System.Windows.Forms.TextBox();
               this.cmbbSend = new System.Windows.Forms.ComboBox();
               this.SuspendLayout();
               // 
               // txtbIP
               // 
               this.txtbIP.Location = new System.Drawing.Point(59, 41);
               this.txtbIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.txtbIP.Name = "txtbIP";
               this.txtbIP.Size = new System.Drawing.Size(88, 22);
               this.txtbIP.TabIndex = 0;
               this.txtbIP.Leave += new System.EventHandler(this.ServerIP_LostFocus);
               // 
               // txtbPort
               // 
               this.txtbPort.Location = new System.Drawing.Point(214, 41);
               this.txtbPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.txtbPort.Name = "txtbPort";
               this.txtbPort.Size = new System.Drawing.Size(88, 22);
               this.txtbPort.TabIndex = 1;
               this.txtbPort.Leave += new System.EventHandler(this.ServerPort_LostFocus);
               // 
               // txtbClientPort
               // 
               this.txtbClientPort.Location = new System.Drawing.Point(122, 79);
               this.txtbClientPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.txtbClientPort.Name = "txtbClientPort";
               this.txtbClientPort.Size = new System.Drawing.Size(88, 22);
               this.txtbClientPort.TabIndex = 3;
               this.txtbClientPort.Leave += new System.EventHandler(this.TxtbClientPort_LostFocus);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(48, 84);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(68, 16);
               this.label1.TabIndex = 1;
               this.label1.Text = "Client Port";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(169, 44);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(32, 16);
               this.label2.TabIndex = 1;
               this.label2.Text = "Port";
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Location = new System.Drawing.Point(10, 45);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(21, 16);
               this.label3.TabIndex = 1;
               this.label3.Text = "IP";
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(10, 166);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(52, 16);
               this.label4.TabIndex = 1;
               this.label4.Text = "Receive";
               // 
               // txtbReceive
               // 
               this.txtbReceive.Location = new System.Drawing.Point(67, 162);
               this.txtbReceive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.txtbReceive.Name = "txtbReceive";
               this.txtbReceive.Size = new System.Drawing.Size(88, 22);
               this.txtbReceive.TabIndex = 99;
               // 
               // label5
               // 
               this.label5.AutoSize = true;
               this.label5.Location = new System.Drawing.Point(14, 123);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(36, 16);
               this.label5.TabIndex = 1;
               this.label5.Text = "Send";
               // 
               // txtbSend
               // 
               this.txtbSend.Location = new System.Drawing.Point(60, 120);
               this.txtbSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.txtbSend.Name = "txtbSend";
               this.txtbSend.Size = new System.Drawing.Size(88, 22);
               this.txtbSend.TabIndex = 4;
               this.txtbSend.Leave += new System.EventHandler(this.txtbSend_LostFocus);
               // 
               // cmbbSend
               // 
               this.cmbbSend.FormattingEnabled = true;
               this.cmbbSend.Location = new System.Drawing.Point(173, 119);
               this.cmbbSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.cmbbSend.Name = "cmbbSend";
               this.cmbbSend.Size = new System.Drawing.Size(106, 23);
               this.cmbbSend.TabIndex = 5;
               this.cmbbSend.Leave += new System.EventHandler(this.cmbbSend_LostFocus);
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(331, 290);
               this.Controls.Add(this.cmbbSend);
               this.Controls.Add(this.label5);
               this.Controls.Add(this.label4);
               this.Controls.Add(this.label3);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.txtbClientPort);
               this.Controls.Add(this.txtbSend);
               this.Controls.Add(this.txtbPort);
               this.Controls.Add(this.txtbReceive);
               this.Controls.Add(this.txtbIP);
               this.Font = new System.Drawing.Font("Times New Roman", 7.8F);
               this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
               this.Name = "Form1";
               this.Text = "Trinh sát";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TextBox txtbIP;
          private System.Windows.Forms.TextBox txtbPort;
          private System.Windows.Forms.TextBox txtbClientPort;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.TextBox txtbReceive;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.TextBox txtbSend;
          private System.Windows.Forms.ComboBox cmbbSend;
     }
}

