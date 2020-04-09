using System.Windows.Forms;

namespace Chinese_Vocabulary_Lists
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
			this.label2 = new System.Windows.Forms.Label();
			this.OutputFileName = new System.Windows.Forms.TextBox();
			this.ChooseOutput = new System.Windows.Forms.Button();
			this.Ciao = new System.Windows.Forms.Button();
			this.Status = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.WorkBoPoMoFo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.WorkChinese = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.WorkPinyin = new System.Windows.Forms.TextBox();
			this.WriteEnglish = new System.Windows.Forms.TextBox();
			this.WriteIt = new System.Windows.Forms.Button();
			this.listBoPoMoFo = new System.Windows.Forms.ListBox();
			this.listPinyin = new System.Windows.Forms.ListBox();
			this.WritePinyin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.WriteChinese = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.WriteBoPoMoFo = new System.Windows.Forms.TextBox();
			this.Clear = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.ShowLanguages = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textCangjie = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textDefinition = new System.Windows.Forms.TextBox();
			this.textBopo = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnSetUserCred = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 352);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Output File";
			// 
			// OutputFileName
			// 
			this.OutputFileName.BackColor = System.Drawing.Color.Yellow;
			this.OutputFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OutputFileName.ImeMode = System.Windows.Forms.ImeMode.On;
			this.OutputFileName.Location = new System.Drawing.Point(20, 382);
			this.OutputFileName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.OutputFileName.Name = "OutputFileName";
			this.OutputFileName.Size = new System.Drawing.Size(993, 35);
			this.OutputFileName.TabIndex = 3;
			this.OutputFileName.TabStop = false;
			this.OutputFileName.Text = "C:\\Users\\JKay\\Chinese Characters\\NewList.csv";
			this.OutputFileName.Click += new System.EventHandler(this.English_Enter);
			this.OutputFileName.Enter += new System.EventHandler(this.English_Enter);
			// 
			// ChooseOutput
			// 
			this.ChooseOutput.BackColor = System.Drawing.Color.Black;
			this.ChooseOutput.ForeColor = System.Drawing.Color.LawnGreen;
			this.ChooseOutput.Location = new System.Drawing.Point(20, 1);
			this.ChooseOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.ChooseOutput.Name = "ChooseOutput";
			this.ChooseOutput.Size = new System.Drawing.Size(188, 36);
			this.ChooseOutput.TabIndex = 1;
			this.ChooseOutput.TabStop = false;
			this.ChooseOutput.Text = "Select Output";
			this.ChooseOutput.UseVisualStyleBackColor = false;
			this.ChooseOutput.Click += new System.EventHandler(this.ChooseOutput_Click);
			// 
			// Ciao
			// 
			this.Ciao.BackColor = System.Drawing.Color.Black;
			this.Ciao.ForeColor = System.Drawing.Color.LawnGreen;
			this.Ciao.Location = new System.Drawing.Point(233, 1);
			this.Ciao.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Ciao.Name = "Ciao";
			this.Ciao.Size = new System.Drawing.Size(188, 36);
			this.Ciao.TabIndex = 6;
			this.Ciao.TabStop = false;
			this.Ciao.Text = "Close File";
			this.Ciao.UseVisualStyleBackColor = false;
			this.Ciao.Click += new System.EventHandler(this.Ciao_Click_1);
			// 
			// Status
			// 
			this.Status.BackColor = System.Drawing.Color.Yellow;
			this.Status.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Status.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Status.Location = new System.Drawing.Point(20, 469);
			this.Status.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(993, 36);
			this.Status.TabIndex = 9;
			this.Status.TabStop = false;
			this.Status.Enter += new System.EventHandler(this.Status_Enter);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 439);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "Status Msg";
			// 
			// WorkBoPoMoFo
			// 
			this.WorkBoPoMoFo.BackColor = System.Drawing.Color.Yellow;
			this.WorkBoPoMoFo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.WorkBoPoMoFo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WorkBoPoMoFo.Location = new System.Drawing.Point(20, 266);
			this.WorkBoPoMoFo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WorkBoPoMoFo.Name = "WorkBoPoMoFo";
			this.WorkBoPoMoFo.Size = new System.Drawing.Size(343, 35);
			this.WorkBoPoMoFo.TabIndex = 24;
			this.WorkBoPoMoFo.TabStop = false;
			this.WorkBoPoMoFo.Click += new System.EventHandler(this.WorkBoPoMoFo_Enter);
			this.WorkBoPoMoFo.Enter += new System.EventHandler(this.WorkBoPoMoFo_Enter);
			this.WorkBoPoMoFo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorkBoPoMoFo_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(388, 242);
			this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(155, 24);
			this.label8.TabIndex = 19;
			this.label8.Text = "Working Chinese";
			// 
			// WorkChinese
			// 
			this.WorkChinese.BackColor = System.Drawing.Color.Yellow;
			this.WorkChinese.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WorkChinese.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WorkChinese.Location = new System.Drawing.Point(392, 265);
			this.WorkChinese.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WorkChinese.MaxLength = 1;
			this.WorkChinese.Name = "WorkChinese";
			this.WorkChinese.Size = new System.Drawing.Size(185, 36);
			this.WorkChinese.TabIndex = 1;
			this.WorkChinese.Click += new System.EventHandler(this.WorkChinese_Enter);
			this.WorkChinese.TextChanged += new System.EventHandler(this.WorkChinese_TextChanged);
			this.WorkChinese.Enter += new System.EventHandler(this.WorkChinese_Enter);
			this.WorkChinese.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkChinese_KeyUp);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 99);
			this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(119, 24);
			this.label9.TabIndex = 22;
			this.label9.Text = "Final English";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(605, 242);
			this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 24);
			this.label11.TabIndex = 25;
			this.label11.Text = "Working Pinyin";
			// 
			// WorkPinyin
			// 
			this.WorkPinyin.BackColor = System.Drawing.Color.Yellow;
			this.WorkPinyin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WorkPinyin.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WorkPinyin.Location = new System.Drawing.Point(609, 266);
			this.WorkPinyin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WorkPinyin.Name = "WorkPinyin";
			this.WorkPinyin.Size = new System.Drawing.Size(405, 35);
			this.WorkPinyin.TabIndex = 25;
			this.WorkPinyin.TabStop = false;
			this.WorkPinyin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pinyin_MouseClick);
			this.WorkPinyin.Enter += new System.EventHandler(this.English_Enter);
			this.WorkPinyin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorkPinyin_KeyPress);
			// 
			// WriteEnglish
			// 
			this.WriteEnglish.BackColor = System.Drawing.Color.Yellow;
			this.WriteEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WriteEnglish.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WriteEnglish.Location = new System.Drawing.Point(20, 129);
			this.WriteEnglish.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WriteEnglish.Name = "WriteEnglish";
			this.WriteEnglish.Size = new System.Drawing.Size(993, 35);
			this.WriteEnglish.TabIndex = 2;
			this.WriteEnglish.Enter += new System.EventHandler(this.English_Enter);
			this.WriteEnglish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WriteEnglish_KeyPress);
			// 
			// WriteIt
			// 
			this.WriteIt.BackColor = System.Drawing.Color.Black;
			this.WriteIt.ForeColor = System.Drawing.Color.LawnGreen;
			this.WriteIt.Location = new System.Drawing.Point(233, 38);
			this.WriteIt.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WriteIt.Name = "WriteIt";
			this.WriteIt.Size = new System.Drawing.Size(188, 37);
			this.WriteIt.TabIndex = 3;
			this.WriteIt.Text = "Write It";
			this.WriteIt.UseVisualStyleBackColor = false;
			this.WriteIt.Click += new System.EventHandler(this.WriteIt_Click);
			this.WriteIt.Enter += new System.EventHandler(this.WriteIt_Click);
			// 
			// listBoPoMoFo
			// 
			this.listBoPoMoFo.BackColor = System.Drawing.Color.Yellow;
			this.listBoPoMoFo.CausesValidation = false;
			this.listBoPoMoFo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.listBoPoMoFo.FormattingEnabled = true;
			this.listBoPoMoFo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.listBoPoMoFo.ItemHeight = 29;
			this.listBoPoMoFo.Location = new System.Drawing.Point(20, 308);
			this.listBoPoMoFo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.listBoPoMoFo.Name = "listBoPoMoFo";
			this.listBoPoMoFo.Size = new System.Drawing.Size(187, 207);
			this.listBoPoMoFo.TabIndex = 28;
			this.listBoPoMoFo.TabStop = false;
			this.listBoPoMoFo.Visible = false;
			this.listBoPoMoFo.SelectedIndexChanged += new System.EventHandler(this.listBoPoMoFo_SelectedIndexChanged);
			// 
			// listPinyin
			// 
			this.listPinyin.BackColor = System.Drawing.Color.Yellow;
			this.listPinyin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listPinyin.FormattingEnabled = true;
			this.listPinyin.ImeMode = System.Windows.Forms.ImeMode.On;
			this.listPinyin.ItemHeight = 29;
			this.listPinyin.Location = new System.Drawing.Point(444, 308);
			this.listPinyin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.listPinyin.Name = "listPinyin";
			this.listPinyin.Size = new System.Drawing.Size(569, 207);
			this.listPinyin.TabIndex = 30;
			this.listPinyin.TabStop = false;
			this.listPinyin.Visible = false;
			this.listPinyin.SelectedIndexChanged += new System.EventHandler(this.listPinyin_SelectedIndexChanged);
			// 
			// WritePinyin
			// 
			this.WritePinyin.BackColor = System.Drawing.Color.Yellow;
			this.WritePinyin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WritePinyin.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WritePinyin.Location = new System.Drawing.Point(609, 200);
			this.WritePinyin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WritePinyin.Name = "WritePinyin";
			this.WritePinyin.Size = new System.Drawing.Size(404, 35);
			this.WritePinyin.TabIndex = 23;
			this.WritePinyin.TabStop = false;
			this.WritePinyin.Enter += new System.EventHandler(this.English_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(605, 170);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 24);
			this.label1.TabIndex = 35;
			this.label1.Text = "Final Pinyin";
			// 
			// WriteChinese
			// 
			this.WriteChinese.BackColor = System.Drawing.Color.Yellow;
			this.WriteChinese.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WriteChinese.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WriteChinese.Location = new System.Drawing.Point(392, 199);
			this.WriteChinese.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WriteChinese.Name = "WriteChinese";
			this.WriteChinese.Size = new System.Drawing.Size(185, 36);
			this.WriteChinese.TabIndex = 22;
			this.WriteChinese.TabStop = false;
			this.WriteChinese.Click += new System.EventHandler(this.WriteChinese_Enter);
			this.WriteChinese.Enter += new System.EventHandler(this.WriteChinese_Enter);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(388, 169);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 24);
			this.label4.TabIndex = 34;
			this.label4.Text = "Final Chinese";
			// 
			// WriteBoPoMoFo
			// 
			this.WriteBoPoMoFo.BackColor = System.Drawing.Color.Yellow;
			this.WriteBoPoMoFo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.WriteBoPoMoFo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.WriteBoPoMoFo.Location = new System.Drawing.Point(20, 200);
			this.WriteBoPoMoFo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WriteBoPoMoFo.Name = "WriteBoPoMoFo";
			this.WriteBoPoMoFo.Size = new System.Drawing.Size(343, 35);
			this.WriteBoPoMoFo.TabIndex = 21;
			this.WriteBoPoMoFo.TabStop = false;
			this.WriteBoPoMoFo.Click += new System.EventHandler(this.WriteBoPoMoFo_Enter);
			this.WriteBoPoMoFo.Enter += new System.EventHandler(this.WriteBoPoMoFo_Enter);
			// 
			// Clear
			// 
			this.Clear.BackColor = System.Drawing.Color.Black;
			this.Clear.ForeColor = System.Drawing.Color.Gold;
			this.Clear.Location = new System.Drawing.Point(233, 308);
			this.Clear.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Clear.Name = "Clear";
			this.Clear.Size = new System.Drawing.Size(188, 37);
			this.Clear.TabIndex = 37;
			this.Clear.TabStop = false;
			this.Clear.Text = "Clear Current";
			this.Clear.UseVisualStyleBackColor = false;
			this.Clear.Click += new System.EventHandler(this.Clear_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Black;
			this.button1.ForeColor = System.Drawing.Color.Red;
			this.button1.Location = new System.Drawing.Point(475, 1);
			this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(188, 36);
			this.button1.TabIndex = 38;
			this.button1.TabStop = false;
			this.button1.Text = "Exit";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 242);
			this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(181, 24);
			this.label6.TabIndex = 16;
			this.label6.Text = "Working BoPoMoFo";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 169);
			this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(152, 24);
			this.label10.TabIndex = 33;
			this.label10.Text = "Final BoPoMoFo";
			// 
			// ShowLanguages
			// 
			this.ShowLanguages.BackColor = System.Drawing.Color.Black;
			this.ShowLanguages.ForeColor = System.Drawing.Color.Red;
			this.ShowLanguages.Location = new System.Drawing.Point(825, 1);
			this.ShowLanguages.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.ShowLanguages.Name = "ShowLanguages";
			this.ShowLanguages.Size = new System.Drawing.Size(188, 36);
			this.ShowLanguages.TabIndex = 39;
			this.ShowLanguages.TabStop = false;
			this.ShowLanguages.Text = "Show Languages";
			this.ShowLanguages.UseVisualStyleBackColor = false;
			this.ShowLanguages.Click += new System.EventHandler(this.ShowLanguages_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(482, 56);
			this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 24);
			this.label5.TabIndex = 40;
			this.label5.Text = "CangJie";
			// 
			// textCangjie
			// 
			this.textCangjie.BackColor = System.Drawing.Color.Yellow;
			this.textCangjie.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textCangjie.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textCangjie.Location = new System.Drawing.Point(570, 49);
			this.textCangjie.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textCangjie.Name = "textCangjie";
			this.textCangjie.Size = new System.Drawing.Size(130, 35);
			this.textCangjie.TabIndex = 41;
			this.textCangjie.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(182, 95);
			this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 24);
			this.label7.TabIndex = 42;
			this.label7.Text = "Definition";
			// 
			// textDefinition
			// 
			this.textDefinition.BackColor = System.Drawing.Color.Yellow;
			this.textDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textDefinition.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textDefinition.Location = new System.Drawing.Point(279, 88);
			this.textDefinition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textDefinition.Name = "textDefinition";
			this.textDefinition.Size = new System.Drawing.Size(734, 35);
			this.textDefinition.TabIndex = 43;
			this.textDefinition.TabStop = false;
			// 
			// textBopo
			// 
			this.textBopo.BackColor = System.Drawing.Color.Yellow;
			this.textBopo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBopo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textBopo.Location = new System.Drawing.Point(883, 49);
			this.textBopo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBopo.Name = "textBopo";
			this.textBopo.Size = new System.Drawing.Size(130, 35);
			this.textBopo.TabIndex = 45;
			this.textBopo.TabStop = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(767, 56);
			this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(106, 24);
			this.label12.TabIndex = 44;
			this.label12.Text = "BoPoMoFo";
			// 
			// btnSetUserCred
			// 
			this.btnSetUserCred.BackColor = System.Drawing.Color.Black;
			this.btnSetUserCred.ForeColor = System.Drawing.Color.LawnGreen;
			this.btnSetUserCred.Location = new System.Drawing.Point(19, 39);
			this.btnSetUserCred.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnSetUserCred.Name = "btnSetUserCred";
			this.btnSetUserCred.Size = new System.Drawing.Size(188, 36);
			this.btnSetUserCred.TabIndex = 46;
			this.btnSetUserCred.TabStop = false;
			this.btnSetUserCred.Text = "Set User Credentials";
			this.btnSetUserCred.UseVisualStyleBackColor = false;
			this.btnSetUserCred.Click += new System.EventHandler(this.SetUserCredentials_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Cyan;
			this.ClientSize = new System.Drawing.Size(1037, 522);
			this.Controls.Add(this.btnSetUserCred);
			this.Controls.Add(this.textBopo);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textDefinition);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textCangjie);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.listPinyin);
			this.Controls.Add(this.listBoPoMoFo);
			this.Controls.Add(this.ShowLanguages);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Clear);
			this.Controls.Add(this.WritePinyin);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.WriteChinese);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.WriteBoPoMoFo);
			this.Controls.Add(this.WriteIt);
			this.Controls.Add(this.WriteEnglish);
			this.Controls.Add(this.WorkPinyin);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.WorkChinese);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.WorkBoPoMoFo);
			this.Controls.Add(this.Status);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Ciao);
			this.Controls.Add(this.ChooseOutput);
			this.Controls.Add(this.OutputFileName);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Name = "Form1";
			this.Text = "            Chinese Language Lists for Flashcard Learning    (By: James S. Kay, C" +
    "onsulting - Version: 2.0.02)";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputFileName;
        private System.Windows.Forms.Button ChooseOutput;
        private System.Windows.Forms.Button Ciao;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WorkBoPoMoFo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WorkChinese;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox WorkPinyin;
        private System.Windows.Forms.TextBox WriteEnglish;
        private System.Windows.Forms.Button WriteIt;
        private System.Windows.Forms.ListBox listBoPoMoFo;
        private System.Windows.Forms.ListBox listPinyin;
        private System.Windows.Forms.TextBox WritePinyin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WriteChinese;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WriteBoPoMoFo;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ShowLanguages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCangjie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textDefinition;
        private System.Windows.Forms.TextBox textBopo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSetUserCred;
        private char[] _delim2 = new char[1];
        private InputLanguage[] _myLanguages = new InputLanguage[10];
        private char[] _delim1 = new char[1];
    }
}

