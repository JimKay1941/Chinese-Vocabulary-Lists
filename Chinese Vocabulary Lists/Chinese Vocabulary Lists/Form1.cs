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
	public partial class Form1 : Form
	{
		// file browse processes
		private readonly OpenFileDialog _chooseOutputFileDialog = new OpenFileDialog();
		// end file browse


		Point _current;

	    readonly Traditional _diction = new Traditional();

	    FileStream _writing;
		StreamWriter _outputLine;

	    public Form1()
		{
			InitializeComponent();
			// my file dialogs
			_chooseOutputFileDialog.FileOk += OnOutputFileDialogOk;

			_delim1[0] = '\t';
			_delim2[0] = '/';

			WriteChinese.ImeMode = ImeMode.On;
			WriteBoPoMoFo.ImeMode = ImeMode.On;
			WorkChinese.ImeMode = ImeMode.On;
			WorkBoPoMoFo.ImeMode = ImeMode.On;
		}

		private void OnOutputFileDialogOk(object sender, CancelEventArgs e)
		{
			OutputFileName.Text = _chooseOutputFileDialog.FileName;
		}

		private void ChooseOutput_Click(object sender, EventArgs e)
		{
			_chooseOutputFileDialog.ShowDialog();
			SendKeys.Send("\t");
		}

        //private void Ciao_Click()
        //{
        //    this.Close();
        //}

		private void Form1_Load(object sender, EventArgs e)
		{
			int index = 0;

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
			if (_outputLine != null)
			{
				_outputLine.Close();
				_outputLine = null;
				ChooseOutput.Enabled = true;
				OutputFileName.Enabled = true;
			}
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
			textCangjie.Text = "";
			textDefinition.Text = "";
			textBopo.Text = "";
			WorkBoPoMoFo.Text = "";
			WorkChinese.Text = "";
			WorkPinyin.Text = "";
			WriteBoPoMoFo.Text = "";
			WriteChinese.Text = "";
			WritePinyin.Text = "";
			WriteEnglish.Text = "";
			listBoPoMoFo.Items.Clear();
			listBoPoMoFo.Visible = false;
			listPinyin.Items.Clear();
			listPinyin.Visible = false;
			//Status.Text = "";
			SendKeys.Send("\t");

			WriteChinese.ImeMode = ImeMode.On;
			WriteBoPoMoFo.ImeMode = ImeMode.On;
			WorkChinese.ImeMode = ImeMode.On;
			WorkBoPoMoFo.ImeMode = ImeMode.On;
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

				if (WriteChinese.Text == "")
				{
					Status.Text = @"No data ready to be written";
					return;
				}

				if (WriteEnglish.Text == "")
				{
					Status.Text = @"No English ready to be written";
					return;
				}

				if (WriteBoPoMoFo.Text == "")
				{
					Status.Text = @"No BoPoMoFo ready to be written";
					return;
				}

				if (WritePinyin.Text == "")
				{
					Status.Text = @"No Pinyin ready to be written";
					return;
				}

				if (_outputLine == null)
				{
					_writing = new FileStream(OutputFileName.Text, FileMode.Append, FileAccess.Write, FileShare.None);
					_outputLine = new StreamWriter(_writing, Encoding.UTF8);

					ChooseOutput.Enabled = false;
					OutputFileName.Enabled = false;
				}

				string fileLine = "1" + "\t" + WriteBoPoMoFo.Text + "\t" + WriteChinese.Text + "\t" + WriteEnglish.Text + "\t" + WritePinyin.Text;
				_outputLine.WriteLine(fileLine);
				

				var verify = new StringBuilder(fileLine);
				verify.Replace("\t", ":");
				Status.Text = @"OK: " + verify;

				WorkBoPoMoFo.Text = "";
				WorkChinese.Text = "";
				WorkPinyin.Text = "";
				WriteBoPoMoFo.Text = "";
				WriteChinese.Text = "";
				WritePinyin.Text = "";
				WriteEnglish.Text = "";
				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;
				listPinyin.Items.Clear();
				listPinyin.Visible = false;
				textCangjie.Text = "";
				textDefinition.Text = "";
				textBopo.Text = "";
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
			WorkChinese.ImeMode = ImeMode.On;

			IList<string> foundPin;
			IList<string> foundBo;

		    if ((WorkChinese.Text == "") || (WorkChinese.Text == @"　"))
			{
				Variables.InputsBopo = null;
                WorkChinese.Text = "";
				return;
			}

			if ((Variables.InputsBopo != null) && (Variables.InputsBopo == "xxxx"))
			{
				Variables.InputsBopo = null;
				textBopo.Text = "";
			}

			//Status.Text = "";

			bool boUsit = _diction.TryGetCharPin(WorkChinese.Text, out foundPin);
			bool pinUsit = _diction.TryGetCharBo(WorkChinese.Text, out foundBo);

			if ((!boUsit) || (!pinUsit))
			{
				Status.Text = @"Character not in dictionary";
				WorkChinese.Text = "";
				textBopo.Text = "";
				return;
			}

			int boCount = foundBo.Count;
			int pinCount = foundPin.Count;

			if ((Variables.InputsBopo != null) && (foundPin.Count > 1) && (foundBo.Count > 1))
			{
                string working = Variables.InputsBopo;
                textBopo.Text = "";

                for (int j = 0; j <= 3; j++)
                {
                    if (working.Substring(j, 1) != "x")
                    {
                        textBopo.Text += working.Substring(j, 1);
                    }
                }


				for (int i = 0; i < foundBo.Count; i++)
				{
					if (textBopo.Text == foundBo[i])
					{
						foundBo[0] = foundBo[i];
						boCount = 1;

						_diction.TryGetBoPin(textBopo.Text, out foundPin);
						pinCount = 1;
						textBopo.Text = "";
						break;
					}
				}
			}

			if ((pinCount == 1) && (boCount == 1))
			{
				textBopo.Text = foundBo[0];
				WriteBoPoMoFo.Text += foundBo[0];
				WriteBoPoMoFo.Text += @" ";
				WorkBoPoMoFo.Text = "";
				WriteChinese.Text += WorkChinese.Text;

			    IList<string> foundMyPin;
			    bool myPin = _diction.TryGetMyPin(foundPin[0], out foundMyPin);

                if (myPin)
                {
                    WritePinyin.Text = WritePinyin.Text + foundMyPin[0] + @" "; 
                }
				WorkPinyin.Text = "";

				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;
				listPinyin.Items.Clear();
				listPinyin.Visible = false;

				
				char[] chinChars = WorkChinese.Text.ToCharArray();
				string uniHex = ExpandUnihex(chinChars);

				using (var ceDictionary = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
				{
					var definitions = from ed in ceDictionary.CeDicts
										where ed.Char == WorkChinese.Text
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

				WorkChinese.Text = "";

				using (var uniHan = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
				{
					var characters = from q in uniHan.UniHans
										where q.cp == uniHex
										select q;

					try
					{
						foreach (var character in characters)
						{
							textCangjie.Text = character.kCangjie;
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

		    listPinyin.BeginUpdate();
		    listPinyin.Items.Clear();

		    foreach (string t in foundPin)
		    {
		        listPinyin.Items.Add(t);
		    }

		    listPinyin.EndUpdate();
		    listPinyin.Visible = true;

		    
			
				listBoPoMoFo.BeginUpdate();
				listBoPoMoFo.Items.Clear();

				foreach (string t in foundBo)
				{
				    listBoPoMoFo.Items.Add(t);
				}

			    listBoPoMoFo.EndUpdate();
				listBoPoMoFo.Visible = true;
		}

		private void listBoPoMoFo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (WorkChinese.Text.Length == 0)
			{
				listPinyin.Items.Clear();
				listPinyin.Visible = false;

				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;

				return;
			}

			_current = Cursor.Position;
			IList<string> checkPin;
			string stringBoPoMoFo = listBoPoMoFo.SelectedItem.ToString();

			bool boUsit = _diction.TryGetBoPin(stringBoPoMoFo, out checkPin);

			if (!boUsit)
			{
				Status.Text = @"BoPoMoFo To Pinyin: Table problem. Selected BoPoMoFo not found!";
				return;
			}

			if (checkPin.Count == 1)
			{
				WriteBoPoMoFo.Text += listBoPoMoFo.SelectedItem;
				textBopo.Text = "";
				textBopo.Text += listBoPoMoFo.SelectedItem;
				WorkBoPoMoFo.Text = "";

				WriteChinese.Text += WorkChinese.Text;

				WritePinyin.Text = WritePinyin.Text + checkPin[0] + @" ";
				WorkPinyin.Text = "";

				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;
				listPinyin.Items.Clear();
				listPinyin.Visible = false;
				//Status.Text = "";
				Cursor.Position = _current;

				try
				{
					char[] chinChars = WorkChinese.Text.ToCharArray();
					string uniHex = ExpandUnihex(chinChars);

					using (var ceDictionary = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
					{
						var definitions = from ed in ceDictionary.CeDicts
										  where ed.Char == WorkChinese.Text
										  where ed.Bopo == textBopo.Text
										  select ed;

						foreach (var definition in definitions)
						{
							textDefinition.Text = definition.English;
							break;
						}
					}

					WorkChinese.Text = "";

					using (var uniHan = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
					{
						var characters = from q in uniHan.UniHans
										 where q.cp == uniHex
										 select q;

						try
						{
							foreach (var character in characters)
							{
								textCangjie.Text = character.kCangjie;
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
				WorkPinyin.Text = "";
				listPinyin.BeginUpdate();

				listPinyin.Items.Clear();

				foreach (string t in checkPin)
				{
				    listPinyin.Items.Add(t);
				}
			    listPinyin.EndUpdate();
				listPinyin.Visible = true;
				listBoPoMoFo.Visible = false;
			}
			//SendKeys.Send("\t");
		}

		private void listPinyin_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (WorkChinese.Text.Length == 0)
			{
				listPinyin.Items.Clear();
				listPinyin.Visible = false;

				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;

				return;
			}

			_current = Cursor.Position;
			IList<string> checkBoPo;
			string workPin = listPinyin.SelectedItem.ToString();

			bool pinUsit = _diction.TryGetPinBo(workPin, out checkBoPo);

			if (!pinUsit)
			{
				Status.Text = @"Pinyin To PoPoMoFo: Table problem. Selected Pinyin not found!";
				return;
			}

			if (checkBoPo.Count == 1)
			{
				textBopo.Text = checkBoPo[0];
				WritePinyin.Text += listPinyin.SelectedItem;
				WritePinyin.Text += @" ";
				WorkPinyin.Text = "";

				WriteChinese.Text += WorkChinese.Text;

				WriteBoPoMoFo.Text = WriteBoPoMoFo.Text + checkBoPo[0];
				WorkPinyin.Text = "";

				listBoPoMoFo.Items.Clear();
				listBoPoMoFo.Visible = false;
				listPinyin.Items.Clear();
				listPinyin.Visible = false;
				//Status.Text = "";
				Cursor.Position = _current;

				try
				{
					char[] chinChars = WorkChinese.Text.ToCharArray();
					string uniHex = ExpandUnihex(chinChars);

					using (var ceDictionary = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
					{
						var definitions = from ed in ceDictionary.CeDicts 
										  where ed.Char == WorkChinese.Text
										  where ed.Bopo == checkBoPo[0]
										  select ed;

						foreach (var definition in definitions)
						{
							textDefinition.Text = definition.English;
							break;
						}
					}

					WorkChinese.Text = "";
					using (var uniHan = new CeDictDataContext(Properties.Settings.Default.ChineseStudyConnection))
					{
						var characters = from q in uniHan.UniHans
										 where q.cp == uniHex
										 select q;
						try
						{
							foreach (var character in characters)
							{
								textCangjie.Text = character.kCangjie;
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
				WorkBoPoMoFo.Text = "";
				listBoPoMoFo.BeginUpdate();

				listBoPoMoFo.Items.Clear();

				foreach (string t in checkBoPo)
				{
				    listBoPoMoFo.Items.Add(t);
				}
			    listBoPoMoFo.EndUpdate();
				listBoPoMoFo.Visible = true;
				listPinyin.Visible = false;
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
			if (e.KeyChar == '\r')
			{
				IList<string> foundBo;
				WorkBoPoMoFo.Text = "";
				bool pinUsit = _diction.TryGetPinBo(WorkPinyin.Text, out foundBo);
				if (pinUsit)
				{
					//if (FoundBo.Count == 1)
					{
						WorkBoPoMoFo.Text = foundBo[0];
						SendKeys.Send("\t");
					}
				}
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

		private string ExpandUnihex(char[] chinchars)
		{
			var nibble = new char[4];

		    uint charNo = chinchars[0];
		    for (int x = 0; x <= 3; x++)
			{
				uint uintNibble = charNo % 16;
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

			string uniHex = nibble[3].ToString(CultureInfo.InvariantCulture) + nibble[2].ToString(CultureInfo.InvariantCulture) + nibble[1].ToString(CultureInfo.InvariantCulture) + nibble[0].ToString(CultureInfo.InvariantCulture);

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

		private void Pusher(string wasInput, int position)
		{
			if (Variables.InputsBopo == null) Variables.InputsBopo = "xxxx";

            string holder = "";

            for (int nowWhat = 0; nowWhat <= 3; nowWhat++)
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

		private void Popper(int keycode)
		{
            if (Variables.InputsBopo == null) return;
            if (keycode == 27) { Variables.InputsBopo = null; return; } // escape key pressed
            if (keycode == 8)
            {
                string creation = "";
                bool found = false;

                for (int nowWhat = 3; nowWhat >= 0; nowWhat--)
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
		}

		private void WorkBoPoMoFo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				IList<string> foundPin;
				WorkPinyin.Text = "";
				bool bopoUsit = _diction.TryGetBoPin(WorkBoPoMoFo.Text, out foundPin);
				if (bopoUsit)
				{
					//if (FoundPin.Count == 1)
					{
						WorkPinyin.Text = foundPin[0];
					}
				}
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
            if (_outputLine != null)
            {
                _outputLine.Close();
                _outputLine = null;
                ChooseOutput.Enabled = true;
                OutputFileName.Enabled = true;
            }
        }
		
	}

	public static class Variables
	{
		public static Traditional Diction = new Traditional();
		public static string InputsBopo;
	}
}