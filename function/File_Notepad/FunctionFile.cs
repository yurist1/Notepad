﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YuristNotepad.Common;

namespace File_Notepad
{
    public class FunctionFile
    {
        private List<Button> _buttons;
        private Window _window;
        public FunctionFile()
        {
            _buttons = ct.CreateButtons(AllMenu());
            SetEvent();
        }
        public List<Button> GetLabels(Window window)
        {
            this._window = window;
            return _buttons;
        }
        CommonToolbar ct = new CommonToolbar();
        private string[] AllMenu()
        {
            //reflection으로 menu 다 담기
            var menu = new Constants.MENU();
            Type type = menu.GetType();
            FieldInfo[] name = type.GetFields();

            string[] result = new string[name.Length];
            for (int i = 0; i < name.Length; i++)
            {
                result[i] = name[i].GetValue(null).ToString();
            }

            return result;
        }

        private void SetEvent()
        {
            //((Button)_buttons.Where(d => d.Content.Equals("끝내기")).Select(d => d).FirstOrDefault()).Click += FunctionFile_Click; 
            //((Button)_buttons.Where(d => d.Content.Equals("새로 만들기")).Select(d => d).FirstOrDefault()).Click += FunctionFile_Click;
            foreach (var item in _buttons)
            {
                item.Click += FunctionFile_Click;
            }
        }

        private void FunctionFile_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "새로 만들기":
                    MakeNew(_window);
                    break;
                case "새 창":
                    NewWindow(_window);
                    break;
                case "열기":
                    break;
                case "저장":
                    break;
                case "다른 이름으로 저장":
                    break;
                case "페이지 설정":
                    break;
                case "인쇄":
                    break;
                case "끝내기":
                    Exit(_window);
                    break;
            }

        }

        private void Exit(object parm)
        {
            ((Window)parm).Close();
            //스레드가 안죽을 수도 있음
        }
        private void MakeNew(object parm)
        {
            dynamic mainViewModel = parm;
            string tempMessage = mainViewModel.DataContext.RichFullText;
            if (tempMessage != null && tempMessage.Length>0) 
            {
                //저장 다이얼로그
                showDialog(tempMessage);

            }
            mainViewModel.DataContext.RichFullText = "";
        }
        private void NewWindow(object parm) 
        {
            
        }

        private void showDialog(string msg) 
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveTxt(msg);

                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
                case MessageBoxResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    break;
            }
        }

        private void SaveTxt(string msg) 
        {
            using (StreamWriter saveTxt = new StreamWriter(@"..\..\New_TEXT_File.txt", true))
            {
                saveTxt.WriteLine(msg);
            }
        }
    }

}
