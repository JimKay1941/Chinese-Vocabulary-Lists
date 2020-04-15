using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TraditionalChinese;

namespace Chinese_Vocabulary_Lists
{
	public partial class ＭainForm : Form
	{
		// file browse processes
		private readonly OpenFileDialog _chooseOutputFileDialog = new OpenFileDialog();
		// end file browse


		Point _current;

	    //readonly Traditional _diction = new Traditional();

	    FileStream _writing;
		StreamWriter _outputLine;

	    public ＭainForm()
		{
			InitializeComponent();
			// my file dialogs
			_chooseOutputFileDialog.FileOk += OnOutputFileDialogOk;

			_delim1[0] = '\t';
			_delim2[0] = '/';

			WriteTraditional.ImeMode = ImeMode.On;
			WriteZhuyin.ImeMode = ImeMode.On;
			WorkTraditional.ImeMode = ImeMode.On;
			WorkZhuyin.ImeMode = ImeMode.On;
            OutputFileName.Text = Properties.Settings.Default.OutputFile;
		}

		private void OnOutputFileDialogOk(object sender, CancelEventArgs e)
		{
			OutputFileName.Text = _chooseOutputFileDialog.FileName;
		    Properties.Settings.Default.OutputFile = _chooseOutputFileDialog.FileName;
		    Properties.Settings.Default.Save();
		}

		private void ChooseOutput_Click(object sender, EventArgs e)
		{
			_chooseOutputFileDialog.ShowDialog();
			SendKeys.Send("\t");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var index = 0;

			foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
			{
				_myLanguages[index] = lang;
				index++;
			}
			index--;

			if ((Properties.Settings.Default.Know < 0) || (Properties.Settings.Default.Know > index))
			{
				Properties.Settings.Default.Know = 0;
			}

			if ((Properties.Settings.Default.Studying < 0) || (Properties.Settings.Default.Know > index))
			{
				Properties.Settings.Default.Studying = 1;
			}
		}

		private void Ciao_Click_1(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
		    if (_outputLine == null) return;
		    _outputLine.Close();
		    _outputLine = null;
		    ChooseOutput.Enabled = true;
		    OutputFileName.Enabled = true;
		}

		private void Pinyin_MouseClick(object sender, MouseEventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
		}

        //private void Chinese_Enter()
        //{
        //    InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];

        //    //SendKeys.Send("+");
        //}

		private void English_Enter(object sender, EventArgs e)
		{
			//Status.Text = "";
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
		}

		private void Clear_Click(object sender, EventArgs e)
		{
            WorkNumPinyin.Text = "";
            WorkTraditional.Text = "";
            WorkZhuyin.Text = "";
            WriteCritPinyin.Text = "";
            WriteEnglish.Text = "";
            WriteNumPinyin.Text = "";
            WriteSimplified.Text = "";
            WriteTraditional.Text = "";
            WriteZhuyin.Text = "";
		    WriteCji.Text = "";
            listNumPinyin.Items.Clear();
            listNumPinyin.Visible = false;
            listZhuyin.Items.Clear();
            listZhuyin.Visible = false;
            textCangjie.Text = "";
            textDefinition.Text = "";
		    textBopo.Text = "";

			SendKeys.Send("\t");

            WorkTraditional.ImeMode = ImeMode.On;
            WorkZhuyin.ImeMode = ImeMode.On;
            WriteSimplified.ImeMode = ImeMode.On;
            WriteTraditional.ImeMode = ImeMode.On;
            WriteZhuyin.ImeMode = ImeMode.On;
		}

		private void WriteIt_Click(object sender, EventArgs e)
		{
		    try
			{
				Status.Text = "";

				if (OutputFileName.Text == "")
				{
					Status.Text = @"No output file name specified!";
					return;
				}

				if (WriteTraditional.Text == "")
				{
					Status.Text = @"No Traditional ready to be written";
					return;
				}

                if (WriteSimplified.Text == "")
                {
                    Status.Text = @"No Simplified ready to be written";
                    return;
                }

				if (WriteEnglish.Text == "")
				{
					Status.Text = @"No English ready to be written";
					return;
				}

				if (WriteZhuyin.Text == "")
				{
					Status.Text = @"No Zhuyin ready to be written";
					return;
				}

				if (WriteNumPinyin.Text == "")
				{
					Status.Text = @"No NumPinyin ready to be written";
					return;
				}

                if (WriteCritPinyin.Text == "")
                {
                    Status.Text = @"No CritPinyin ready to be written";
                    return;
                }

				if (_outputLine == null)
				{
					_writing = new FileStream(OutputFileName.Text, FileMode.Append, FileAccess.Write, FileShare.None);
					_outputLine = new StreamWriter(_writing, Encoding.UTF8);

					ChooseOutput.Enabled = false;
					OutputFileName.Enabled = false;
				}

                var fileLine = "0" + "\t" + WriteZhuyin.Text + "\t" + WriteTraditional.Text + "\t" + WriteEnglish.Text + "\t" + WriteNumPinyin.Text + "\t" + 
                    WriteCritPinyin.Text + "\t" + WriteSimplified.Text + "\t" + WriteCji.Text;
				_outputLine.WriteLine(fileLine);
				

				var verify = new StringBuilder(fileLine);
				verify.Replace("\t", ":");
				Status.Text = @"OK: " + verify;

                WorkNumPinyin.Text = "";
                WorkTraditional.Text = "";
                WorkZhuyin.Text = "";
                WriteCritPinyin.Text = "";
                WriteEnglish.Text = "";
                WriteNumPinyin.Text = "";
                WriteSimplified.Text = "";
                WriteTraditional.Text = "";
                WriteZhuyin.Text = "";
			    WriteCji.Text = "";
                listNumPinyin.Items.Clear();
                listNumPinyin.Visible = false;
                listZhuyin.Items.Clear();
                listZhuyin.Visible = false;
                textCangjie.Text = "";
                textDefinition.Text = "";

				listZhuyin.Items.Clear();
				listZhuyin.Visible = false;
				listNumPinyin.Items.Clear();
				listNumPinyin.Visible = false;

				SendKeys.Send("\t");
			}
			catch (Exception ex)
			{
				Status.Text = ex.Message;
			}
		}

		private void WorkChinese_TextChanged(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];
			WorkTraditional.ImeMode = ImeMode.On;

			IList<string> foundPin;
			IList<string> foundBo;
		    IList<string> foundCrit;
		    IList<string> foundSimp;

		    if ((WorkTraditional.Text == "") || (WorkTraditional.Text == @"　"))
			{
				Variables.InputsBopo = null;
                WorkTraditional.Text = "";
				return;
			}

			if ((Variables.InputsBopo != null) && (Variables.InputsBopo == "xxxx"))
			{
				Variables.InputsBopo = null;
				textBopo.Text = "";
			}

			var　pinUsit = Traditional.TryGetCharPin(WorkTraditional.Text, out foundPin);

            if (!pinUsit)
            {
                Status.Text = @"CharPin failed on: " + WorkTraditional.Text;
                WorkTraditional.Text = "";
                textBopo.Text = "";
                return;
            }

            var boUsit = Traditional.TryGetCharBo(WorkTraditional.Text, out foundBo);

            if (!boUsit)
            {
                Status.Text = @"CharBo failed on: " + WorkTraditional.Text;
                WorkTraditional.Text = "";
                textBopo.Text = "";
                return;
            }

			var boCount = foundBo.Count;
			var pinCount = foundPin.Count;

			if ((Variables.InputsBopo != null) && (foundPin.Count > 1) && (foundBo.Count > 1))
			{
                var working = Variables.InputsBopo;
                textBopo.Text = "";

                for (var j = 0; j <= 3; j++)
                {
                    if (working.Substring(j, 1) != "x")
                    {
                        textBopo.Text += working.Substring(j, 1);
                    }
                }


				for (var i = 0; i < foundBo.Count; i++)
				{
				    if (textBopo.Text != foundBo[i]) continue;
				    foundBo[0] = foundBo[i];
				    boCount = 1;

                    var pin1 = Traditional.TryGetBoPin(textBopo.Text, out foundPin);
                    
                    if (!pin1)
                    {
                        Status.Text = @"BoPin failed on: " + textBopo.Text;
                        WorkTraditional.Text = "";
                        textBopo.Text = "";
                        return;
                    }

				    pinCount = 1;
				    textBopo.Text = "";
				    break;
				}
			}

			if ((pinCount == 1) && (boCount == 1))
			{
				textBopo.Text = foundBo[0];
				WriteZhuyin.Text += foundBo[0];
				WriteZhuyin.Text += @" ";
				WorkZhuyin.Text = "";
				WriteTraditional.Text += WorkTraditional.Text;

                WriteNumPinyin.Text = WriteNumPinyin.Text + foundPin[0] + @" "; 
				WorkNumPinyin.Text = "";

			    var critUsit = Traditional.TryGetPinCrit(foundPin[0], out foundCrit);

                if (!critUsit)
                {
                    Status.Text = @"PinCrit failed on: " + foundPin[0];
                    WorkTraditional.Text = "";
                    textBopo.Text = "";
                    return;
                }

                var simpUsit = Traditional.TryGetCharSimp(WorkTraditional.Text, out foundSimp);

                if (!simpUsit)
                {
                    Status.Text = @"CharSimp failed on: " + WorkTraditional.Text;
                    WorkTraditional.Text = "";
                    textBopo.Text = "";
                    return;
                }
                

			    WriteCritPinyin.Text = WriteCritPinyin.Text + foundCrit[0] + @" ";
                WriteSimplified.Text = WriteSimplified.Text + foundSimp[0];

				listZhuyin.Items.Clear();
				listZhuyin.Visible = false;
				listNumPinyin.Items.Clear();
				listNumPinyin.Visible = false;

				
				var chinChars = WorkTraditional.Text.ToCharArray();
				var uniHex = ExpandUnihex(chinChars);

				//using (var ceDictionary = new DataSet1(Properties.Settings.Default.ChineseStudyConnection))
                using (var ceDictionary = new DataSet1())
				{
					var definitions = from ed in ceDictionary.CeDict
										where ed.Char == WorkTraditional.Text
										where ed.Bopo == foundBo[0]
										select ed;

                    try
                    {
                        foreach (var definition in definitions)
                        {
                            textDefinition.Text = definition.English;
                            break;
                        }
                    }
                    catch (System.Data.StrongTypingException eng)
                    {
                        Status.Text = eng.Message;
                        textDefinition.Text = @"DBNull";
                    }
				}

				WorkTraditional.Text = "";

				using (var uniHan = new DataSet1())
				{
					var characters = from q in uniHan.UniHan
									 where q.cp == uniHex
									 select q;

					try
					{
						foreach (var character in characters)
						{
							textCangjie.Text = character.kCangjie;
							WriteCji.Text = WriteCji.Text + textCangjie.Text + @" ";
							break;
						}
					}
					catch (System.Data.StrongTypingException ex)
					{
						textCangjie.Text = @"DBNull";
						Status.Text = ex.Message;
					}
				}

				return;
			}

		    listNumPinyin.BeginUpdate();
		    listNumPinyin.Items.Clear();

		    foreach (var t in foundPin)
		    {
		        listNumPinyin.Items.Add(t);
		    }

		    listNumPinyin.EndUpdate();
		    listNumPinyin.Visible = true;

		    
			
				listZhuyin.BeginUpdate();
				listZhuyin.Items.Clear();

				foreach (var t in foundBo)
				{
				    listZhuyin.Items.Add(t);
				}

			    listZhuyin.EndUpdate();
				listZhuyin.Visible = true;
		}

	    private void listBoPoMoFo_SelectedIndexChanged(object sender, EventArgs e)
	    {
	        if (WorkTraditional.Text.Length == 0)
	        {
	            listNumPinyin.Items.Clear();
	            listNumPinyin.Visible = false;

	            listZhuyin.Items.Clear();
	            listZhuyin.Visible = false;

	            return;
	        }

	        _current = Cursor.Position;
	        IList<string> checkPin;
	        var stringBoPoMoFo = listZhuyin.SelectedItem.ToString();

	        var boUsit = Traditional.TryGetBoPin(stringBoPoMoFo, out checkPin);

	        if (!boUsit)
	        {
	            Status.Text = @"BoPin failed on: " + stringBoPoMoFo;
	            return;
	        }
	        string outCrit;
	        var critUsit = Traditional.TryGetBopoCrit(stringBoPoMoFo, out outCrit);

	        if (!critUsit)
	        {
	            Status.Text = @"BopoCrit failed on: " + stringBoPoMoFo;
	            return;
	        }

	        if (checkPin.Count >= 1)
	        {
	            string foundCrit;
	            WriteZhuyin.Text = WriteZhuyin.Text + listZhuyin.SelectedItem.ToString() + @" ";
	            textBopo.Text = "";
	            textBopo.Text += listZhuyin.SelectedItem.ToString();
	            WorkZhuyin.Text = "";

	            WriteTraditional.Text += WorkTraditional.Text;

	            var bopocrit = Traditional.TryGetBopoCrit(listZhuyin.SelectedItem.ToString(), out foundCrit);

                if (!bopocrit)
                {
                    Status.Text = @"BopoCrit failed on: " + listZhuyin.SelectedItem.ToString();
                    return;
                }

	            WriteCritPinyin.Text = WriteCritPinyin.Text + foundCrit + @" ";

	            WriteNumPinyin.Text = WriteNumPinyin.Text + checkPin[0] + @" ";
	            WorkNumPinyin.Text = "";

	            IList<string> foundSimp;
	            var charsimp = Traditional.TryGetCharSimp(WorkTraditional.Text, out foundSimp);

                if (!charsimp)
                {
                    Status.Text = @"CharSimp failed on: " + WorkTraditional.Text;
                    return;
                }


	            WriteSimplified.Text = WriteSimplified.Text + foundSimp[0];

	            listZhuyin.Items.Clear();
	            listZhuyin.Visible = false;
	            listNumPinyin.Items.Clear();
	            listNumPinyin.Visible = false;
	            //Status.Text = "";
	            Cursor.Position = _current;

	            try
	            {
	                var chinChars = WorkTraditional.Text.ToCharArray();
	                var uniHex = ExpandUnihex(chinChars);

	                using (var ceDictionary = new DataSet1())
	                {
	                    var definitions = from ed in ceDictionary.CeDict
	                                      where ed.Char == WorkTraditional.Text
	                                      where ed.Bopo == textBopo.Text
	                                      select ed;

	                    foreach (var definition in definitions)
	                    {
	                        textDefinition.Text = definition.English;
	                        break;
	                    }
	                }

	                WorkTraditional.Text = "";

	                using (var uniHan = new DataSet1())
	                {
	                    var characters = from q in uniHan.UniHan
	                                     where q.cp == uniHex
	                                     select q;

	                    try
	                    {
	                        foreach (var character in characters)
	                        {
	                            textCangjie.Text = character.kCangjie;
	                            WriteCji.Text = WriteCji.Text + textCangjie.Text + @" ";
	                            break;
	                        }
	                    }
	                    catch (System.Data.StrongTypingException ex)
	                    {
	                        textCangjie.Text = @"DBNull";
	                        Status.Text = ex.Message;
	                    }
	                }
	            }
	            catch (System.Data.StrongTypingException ex)
	            {
	                textDefinition.Text = @"OUTERex";
	                textCangjie.Text = @"OUTERex";
	                Status.Text = ex.Message;
	            }
	        }
	        else
	        {
                Status.Text = @"Please select desired Pinyin";
                WorkNumPinyin.Text = "";
                listNumPinyin.BeginUpdate();

                listNumPinyin.Items.Clear();

                foreach (var t in checkPin)
                {
                    listNumPinyin.Items.Add(t);
                }
                listNumPinyin.EndUpdate();
                listNumPinyin.Visible = true;
                listZhuyin.Visible = false;
	        }
	        //SendKeys.Send("\t");
		}

		private void listPinyin_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (WorkTraditional.Text.Length == 0)
			{
				listNumPinyin.Items.Clear();
				listNumPinyin.Visible = false;

				listZhuyin.Items.Clear();
				listZhuyin.Visible = false;

				return;
			}

			_current = Cursor.Position;
			IList<string> checkBoPo;
			var workPin = listNumPinyin.SelectedItem.ToString();

            var pinUsit = Traditional.TryGetPinBo(workPin, out checkBoPo);

			if (!pinUsit)
			{
				Status.Text = @"PinBo failed on: " + workPin;
				return;
			}

            string outCrit;
            var critUsit = Traditional.TryGetBopoCrit(checkBoPo[0], out outCrit);

            if (!critUsit)
            {
                Status.Text = @"BopoCrit failed on: " + checkBoPo[0];
                return;
            }

			if (checkBoPo.Count >= 1)
			{
                WriteNumPinyin.Text = WriteNumPinyin.Text + listNumPinyin.SelectedItem.ToString() + @" ";
				textBopo.Text = checkBoPo[0];

				WorkNumPinyin.Text = "";

				WriteTraditional.Text += WorkTraditional.Text;

			    IList<string> foundCrit;
                var pincrit = Traditional.TryGetPinCrit(listNumPinyin.SelectedItem.ToString(), out foundCrit);

                if (!pincrit)
                {
                    Status.Text = @"PinCrit failed on: " + listNumPinyin.SelectedItem.ToString();
                    return;
                }

                WriteCritPinyin.Text = WriteCritPinyin.Text + foundCrit[0] + @" ";

                WriteZhuyin.Text = WriteZhuyin.Text + checkBoPo[0] + @" ";
				WorkNumPinyin.Text = "";

                IList<string> foundSimp;
                var charsimp = Traditional.TryGetCharSimp(WorkTraditional.Text, out foundSimp);

                if (!charsimp)
                {
                    Status.Text = @"CharSimp failed on: " + WorkTraditional.Text;
                    return;
                }

                WriteSimplified.Text = WriteSimplified.Text + foundSimp[0];

				listZhuyin.Items.Clear();
				listZhuyin.Visible = false;
				listNumPinyin.Items.Clear();
				listNumPinyin.Visible = false;
				//Status.Text = "";
				Cursor.Position = _current;

				try
				{
					var chinChars = WorkTraditional.Text.ToCharArray();
					var uniHex = ExpandUnihex(chinChars);

					using (var ceDictionary = new DataSet1())
					{
						var definitions = from ed in ceDictionary.CeDict 
										  where ed.Char == WorkTraditional.Text
										  where ed.Bopo == checkBoPo[0]
										  select ed;

						foreach (var definition in definitions)
						{
							textDefinition.Text = definition.English;
							break;
						}
					}

					WorkTraditional.Text = "";
					using (var uniHan = new DataSet1())
					{
						var characters = from q in uniHan.UniHan
										 where q.cp == uniHex
										 select q;
						try
						{
							foreach (var character in characters)
							{
								textCangjie.Text = character.kCangjie;
                                WriteCji.Text = WriteCji.Text + textCangjie.Text + @" ";
								break;
							}
						}
						catch (System.Data.StrongTypingException ex)
						{
							textCangjie.Text = @"DBNull";
							Status.Text = ex.Message;
						}
					}
				}
				catch (System.Data.StrongTypingException ex)
				{
					textDefinition.Text = @"OUTERex";
					textCangjie.Text = @"OUTERex";
					Status.Text = ex.Message;
				}
			}
			else
			{
				Status.Text = @"Please select desired BoPoMoFo";
				WorkZhuyin.Text = "";
				listZhuyin.BeginUpdate();

				listZhuyin.Items.Clear();

				foreach (var t in checkBoPo)
				{
				    listZhuyin.Items.Add(t);
				}
			    listZhuyin.EndUpdate();
				listZhuyin.Visible = true;
				listNumPinyin.Visible = false;
			}
			//SendKeys.Send("\t");
		}

		private void WriteEnglish_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyCode == Keys.F1)
			//char looker = e.KeyChar;
			if (e.KeyChar == '\r')
			{
				SendKeys.Send("\t");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (_outputLine != null)
			{
				_outputLine.Close();
			}
            InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
			Close();
		}

		private void Status_Enter(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
		}

		private void WorkPinyin_KeyPress(object sender, KeyPressEventArgs e)
		{
		    if (e.KeyChar != '\r') return;
		    IList<string> foundBo;
		    WorkZhuyin.Text = "";
            var pinUsit = Traditional.TryGetPinBo(WorkNumPinyin.Text, out foundBo);
		    if (!pinUsit) return;
		    //if (FoundBo.Count == 1)
		    {
		        WorkZhuyin.Text = foundBo[0];
		        SendKeys.Send("\t");
		    }
		}

		private void WriteChinese_Enter(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];
			//WriteChinese.ImeMode = System.Windows.Forms.ImeMode.On;
		}

		private void WriteBoPoMoFo_Enter(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];
			//WriteBoPoMoFo.ImeMode = System.Windows.Forms.ImeMode.On;
		}

		private void WorkChinese_Enter(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];
			//WorkChinese.ImeMode = System.Windows.Forms.ImeMode.On;
		}

		private void WorkBoPoMoFo_Enter(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Studying];
            //Status.Text = "";
			//WorkBoPoMoFo.ImeMode = System.Windows.Forms.ImeMode.On;
		}

		private void ShowLanguages_Click(object sender, EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
			var showLanguagesForm = new InstalledLangs();
			showLanguagesForm.ShowDialog();
		}

		private static string ExpandUnihex(IList<char> chinchars)
		{
			var nibble = new char[4];

		    uint charNo = chinchars[0];
		    for (var x = 0; x <= 3; x++)
			{
				var uintNibble = charNo % 16;
				if (uintNibble == 0) nibble[x] = '0';
				if (uintNibble == 1) nibble[x] = '1';
				if (uintNibble == 2) nibble[x] = '2';
				if (uintNibble == 3) nibble[x] = '3';
				if (uintNibble == 4) nibble[x] = '4';
				if (uintNibble == 5) nibble[x] = '5';
				if (uintNibble == 6) nibble[x] = '6';
				if (uintNibble == 7) nibble[x] = '7';
				if (uintNibble == 8) nibble[x] = '8';
				if (uintNibble == 9) nibble[x] = '9';
				if (uintNibble == 10) nibble[x] = 'A';
				if (uintNibble == 11) nibble[x] = 'B';
				if (uintNibble == 12) nibble[x] = 'C';
				if (uintNibble == 13) nibble[x] = 'D';
				if (uintNibble == 14) nibble[x] = 'E';
				if (uintNibble == 15) nibble[x] = 'F';
				charNo = charNo / 16;
			}

			var uniHex = nibble[3].ToString(CultureInfo.InvariantCulture) + nibble[2].ToString(CultureInfo.InvariantCulture) + nibble[1].ToString(CultureInfo.InvariantCulture) + nibble[0].ToString(CultureInfo.InvariantCulture);

			return uniHex;
		}

		private void WorkChinese_KeyUp(object sender, KeyEventArgs e)
		{
            //Status.Text = "";

			if (e.KeyValue == 17) return; // shift
			if (e.KeyValue == 8) Popper(e.KeyValue); // backspace
            if (e.KeyValue == 27) Popper(e.KeyValue); // escape
			if (e.KeyValue == 49) Pusher("ㄅ", 0);
            if (e.KeyValue == 81) Pusher("ㄆ", 0);
            if (e.KeyValue == 65) Pusher("ㄇ", 0);
            if (e.KeyValue == 90) Pusher("ㄈ", 0);
            if (e.KeyValue == 50) Pusher("ㄉ", 0);
            if (e.KeyValue == 87) Pusher("ㄊ", 0);
            if (e.KeyValue == 83) Pusher("ㄋ", 0);
            if (e.KeyValue == 88) Pusher("ㄌ", 0);
            if (e.KeyValue == 69) Pusher("ㄍ", 0);
            if (e.KeyValue == 68) Pusher("ㄎ", 0);
            if (e.KeyValue == 67) Pusher("ㄏ", 0);
            if (e.KeyValue == 82) Pusher("ㄐ", 0);
            if (e.KeyValue == 70) Pusher("ㄑ", 0);
            if (e.KeyValue == 86) Pusher("ㄒ", 0);
            if (e.KeyValue == 53) Pusher("ㄓ", 0);
            if (e.KeyValue == 84) Pusher("ㄔ", 0);
            if (e.KeyValue == 71) Pusher("ㄕ", 0);
            if (e.KeyValue == 66) Pusher("ㄖ", 0);
            if (e.KeyValue == 89) Pusher("ㄗ", 0);
            if (e.KeyValue == 72) Pusher("ㄘ", 0);
			if (e.KeyValue == 78) Pusher("ㄙ", 0);
			if (e.KeyValue == 56) Pusher("ㄚ", 2);
            if (e.KeyValue == 73) Pusher("ㄛ", 2);
            if (e.KeyValue == 75) Pusher("ㄜ", 2);
            if (e.KeyValue == 188) Pusher("ㄝ", 2);
            if (e.KeyValue == 57) Pusher("ㄞ", 2);
            if (e.KeyValue == 79) Pusher("ㄟ", 2);
            if (e.KeyValue == 76) Pusher("ㄠ", 2);
            if (e.KeyValue == 190) Pusher("ㄡ", 2);
            if (e.KeyValue == 48) Pusher("ㄢ", 2);
            if (e.KeyValue == 80) Pusher("ㄣ", 2);
            if (e.KeyValue == 186) Pusher("ㄤ", 2);
            if (e.KeyValue == 191) Pusher("ㄥ", 2);
            if (e.KeyValue == 189) Pusher("ㄦ", 2);
			if (e.KeyValue == 85) Pusher("ㄧ", 1);
			if (e.KeyValue == 74) Pusher("ㄨ", 1);
			if (e.KeyValue == 77) Pusher("ㄩ", 1);
			if (e.KeyValue == 54) Pusher("ˊ", 3);
            if (e.KeyValue == 51) Pusher("ˇ", 3);
            if (e.KeyValue == 52) Pusher("ˋ", 3);
            if (e.KeyValue == 55) Pusher("˙", 3);
		}

		private static void Pusher(string wasInput, int position)
		{
			if (Variables.InputsBopo == null) Variables.InputsBopo = "xxxx";

            var holder = "";

            for (var nowWhat = 0; nowWhat <= 3; nowWhat++)
            {
                if (nowWhat == position)
                {
                    holder += wasInput;
                }
                else
                {
                    holder += Variables.InputsBopo.Substring(nowWhat, 1);
                }
            }

            Variables.InputsBopo = holder;
		}

		private static void Popper(int keycode)
		{
            if (Variables.InputsBopo == null) return;
            if (keycode == 27) { Variables.InputsBopo = null; return; } // escape key pressed
		    if (keycode != 8) return;
		    var creation = "";
		    var found = false;

		    for (var nowWhat = 3; nowWhat >= 0; nowWhat--)
		    {
		        if (Variables.InputsBopo.Substring(nowWhat,1) == "x")
		        {
		            creation = Variables.InputsBopo.Substring(nowWhat,1) + creation;
		        }
		        else
		        {
		            if (!found)
		            {
		                creation = "x" + creation;
		                found = true;
		            }
		            else
		            {
		                creation = Variables.InputsBopo.Substring(nowWhat, 1) + creation;
		            }
		        }
		    }
		}

		private void WorkBoPoMoFo_KeyPress(object sender, KeyPressEventArgs e)
		{
		    switch (e.KeyChar)
		    {
		        case '\r':
		            {
		                IList<string> foundPin;
		                WorkNumPinyin.Text = "";
                        var bopoUsit = Traditional.TryGetBoPin(WorkZhuyin.Text, out foundPin);
		                if (bopoUsit)
		                {
		                    //if (FoundPin.Count == 1)
		                    {
		                        WorkNumPinyin.Text = foundPin[0];
		                    }
		                }
		            }
		            break;
		    }
		}

	    private void SetUserCredentials_Click(object sender, EventArgs e)
				{
					var setUserCredentialsForm = new SetUserCredentials();
					setUserCredentialsForm.ShowDialog();
				}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = _myLanguages[Properties.Settings.Default.Know];
            if (_outputLine == null) return;
            _outputLine.Close();
            _outputLine = null;
            ChooseOutput.Enabled = true;
            OutputFileName.Enabled = true;
        }

		private void WorkTraditional_KeyDown(object sender, KeyEventArgs e)
        {
        }
	}

	public static class Variables
	{
	    public static string InputsBopo;
	}
}